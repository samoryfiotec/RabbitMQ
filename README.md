# Exemplo de RabbitMQ para .NET 8 Applications

Este repositório contém um exemplo de uso do RabbitMQ em uma aplicação .NET 8 utilizando C#. O objetivo é demonstrar como configurar um produtor e um consumidor para troca de mensagens.

[![Fiotec](https://img.shields.io/badge/Fundação-Fiotec-skyblue)](https://www.fiotec.fiocruz.br/)
[![RabbitMQ](https://img.shields.io/badge/RabbitMQ-4.0.6-FF6600)](https://www.rabbitmq.com/)
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-20.10-blue)](https://www.docker.com/)

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [RabbitMQ](https://www.rabbitmq.com/download.html) instalado e em execução
- [Docker](https://www.docker.com/)  (opcional, para executar o RabbitMQ em um container)

## Configuração do RabbitMQ

Se você não possui o RabbitMQ configurado ou disponível, pode usar o Docker para iniciar rapidamente:

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
```

Acesse o painel de administração em [http://localhost:15672](http://localhost:15672) (usuário: `guest`, senha: `guest`).

## Estrutura do Projeto

- **Producer**: Envia mensagens para a fila.
- **Consumer**: Consome mensagens da fila.

<!-- ## Código de Exemplo

### Producer

```csharp
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "example-queue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

string message = "Hello RabbitMQ!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "",
                     routingKey: "example-queue",
                     basicProperties: null,
                     body: body);

Console.WriteLine($"[x] Sent: {message}");
```

### Consumer

```csharp
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "example-queue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"[x] Received: {message}");
};

channel.BasicConsume(queue: "example-queue",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
```

## Como Executar

1. Clone este repositório.
2. Configure o RabbitMQ conforme descrito acima.
3. Execute o **Producer** para enviar mensagens.
4. Execute o **Consumer** para consumir mensagens. -->

## Referências

- [Documentação do RabbitMQ](https://www.rabbitmq.com/documentation.html)
- [Documentação do .NET](https://learn.microsoft.com/dotnet/)

## Licença

Este projeto é licenciado sob a [Apache License 2.0 License](LICENSE).