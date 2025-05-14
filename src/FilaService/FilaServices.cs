using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using FilaService.Abstractions;
using Microsoft.Extensions.Configuration;

namespace FilaService
{
    internal sealed class FilaServices : IFilaServices
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IConfiguration _config;

        public bool RabbitMQEnabled
        {
            get
            {
                return _connection?.IsOpen == true && _channel?.IsOpen == true;
            }
        }



        public FilaServices(IConfiguration config)
        {
            _config = config;

            //Verificando se as configurações do RabbitMQ estão corretas
            if (string.IsNullOrEmpty(_config["Services:RabbitMQ:HostName"]) ||
                string.IsNullOrEmpty(_config["Services:RabbitMQ:UserName"]) ||
                string.IsNullOrEmpty(_config["Services:RabbitMQ:Password"]) ||
                string.IsNullOrEmpty(_config["Services:RabbitMQ:Port"]) ||
                !int.TryParse(_config["Services:RabbitMQ:Port"], out int port))
            {
                throw new ArgumentException("Configuração do RabbitMQ inválida");
            }

            //Criando a fábrica de conexões
            var factory = new ConnectionFactory()
            {
                HostName = _config["Services:RabbitMQ:HostName"],
                UserName = _config["Services:RabbitMQ:UserName"],
                Password = _config["Services:RabbitMQ:Password"],
                Port = port,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
            };

            // Criando a conexão e o canal
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declarando o exchange
            _channel.ExchangeDeclare(exchange: _config["Services:RabbitMQ:ExchangeName"], type: "fanout");

            // Declarando a fila
            _channel.QueueDeclare(queue: _config["Services:RabbitMQ:QueueName"], durable: false, exclusive: false, autoDelete: false, arguments: null);

            // Fazendo o bind da fila com o exchange
            _channel.QueueBind(queue: _config["Services:RabbitMQ:QueueName"], exchange: _config["Services:RabbitMQ:ExchangeName"], routingKey: "");
        }

        public void SendMessage<T>(T message)
        {
            // Criando as propriedades da mensagem
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            // Serializando a mensagem
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            // Publicando a mensagem
            _channel.BasicPublish(exchange: _config["Services:RabbitMQ:ExchangeName"], routingKey: "", basicProperties: properties, body: body);
        }

        public void SendToDeadLetterQueue(BasicDeliverEventArgs ea)
        {
            // Declarando o exchange e a fila da DLQ
            var deadLetterExchange = _config["Services:RabbitMQ:DeadLetterExchangeName"];
            var deadLetterQueue = _config["Services:RabbitMQ:DeadLetterQueueName"];

            // Inicializando a DLQ e fazendo o bind
            _channel.ExchangeDeclare(exchange: deadLetterExchange, type: "fanout");
            _channel.QueueDeclare(queue: deadLetterQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: deadLetterQueue, exchange: deadLetterExchange, routingKey: "");

            // Declaração das propriedades da mensagem
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            // Publicando a mensagem na DLQ
            _channel.BasicPublish(exchange: deadLetterExchange, routingKey: "", basicProperties: properties, body: ea.Body);
        }
        public IConnection CreateNewConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config["Services:RabbitMQ:HostName"],
                UserName = _config["Services:RabbitMQ:UserName"],
                Password = _config["Services:RabbitMQ:Password"],
                Port = Convert.ToInt32(_config["Services:RabbitMQ:Port"]),
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
            };

            return factory.CreateConnection();
        }

        public IModel CreateNewChannel()
        {
            IModel _channel;
            var _connection = this.CreateNewConnection();
            return _channel = _connection.CreateModel();
        }
    }
}
