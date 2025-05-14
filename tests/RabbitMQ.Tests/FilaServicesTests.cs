using System;
using System.Text;
using System.Text.Json;
using FilaService;
using FilaService.Abstractions;
using Microsoft.Extensions.Configuration;
using Moq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Xunit;
using static FilaService.Abstractions.IFilaServices;

namespace RabbitMQ.Tests
{
    public class FilaServicesTests
    {
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly string _hostName = "localhost";
        private readonly string _userName = "guest";
        private readonly string _password = "guest";
        private readonly string _port = "5672";
        private readonly string _exchangeName = "test-exchange";
        private readonly string _queueName = "test-queue";
        private readonly string _dlxName = "dlx-exchange";
        private readonly string _dlqName = "dlq-queue";

        public FilaServicesTests()
        {
            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(c => c["Services:RabbitMQ:HostName"]).Returns(_hostName);
            _mockConfig.Setup(c => c["Services:RabbitMQ:UserName"]).Returns(_userName);
            _mockConfig.Setup(c => c["Services:RabbitMQ:Password"]).Returns(_password);
            _mockConfig.Setup(c => c["Services:RabbitMQ:Port"]).Returns(_port);
            _mockConfig.Setup(c => c["Services:RabbitMQ:ExchangeName"]).Returns(_exchangeName);
            _mockConfig.Setup(c => c["Services:RabbitMQ:QueueName"]).Returns(_queueName);
            _mockConfig.Setup(c => c["Services:RabbitMQ:DeadLetterExchangeName"]).Returns(_dlxName);
            _mockConfig.Setup(c => c["Services:RabbitMQ:DeadLetterQueueName"]).Returns(_dlqName);
        }

        //[Fact]
        //public void Constructor_ThrowsArgumentException_WhenConfigIsInvalid()
        //{
        //    var invalidConfig = new Mock<IConfiguration>();
        //    invalidConfig.Setup(c => c["Services:RabbitMQ:HostName"]).Returns((string)null);
        //    Assert.Throws<ArgumentException>(() => new FilaService(invalidConfig.Object));
        //}

        //[Fact]
        //public void RabbitMQEnabled_ReturnsTrue_WhenConnectionAndChannelAreOpen()
        //{
        //    var filaServices = new FilaServices(_mockConfig.Object);
        //    Assert.True(filaServices.RabbitMQEnabled);
        //}

        //[Fact]
        //public void SendMessage_PublishesMessage()
        //{
        //    var filaServices = new FilaServices(_mockConfig.Object);
        //    var testMessage = new { Text = "Hello" };
        //    Exception ex = Record.Exception(() => filaServices.SendMessage(testMessage));
        //    Assert.Null(ex);
        //}

        //[Fact]
        //public void SendToDeadLetterQueue_PublishesToDLQ()
        //{
        //    var filaServices = new FilaServices(_mockConfig.Object);
        //    var body = Encoding.UTF8.GetBytes("deadletter");
        //    var ea = new BasicDeliverEventArgs { Body = new ReadOnlyMemory<byte>(body) };
        //    Exception ex = Record.Exception(() => filaServices.SendToDeadLetterQueue(ea));
        //    Assert.Null(ex);
        //}

        //[Fact]
        //public void CreateNewConnection_ReturnsOpenConnection()
        //{
        //    var filaServices = new FilaServices(_mockConfig.Object);
        //    using var conn = filaServices.CreateNewConnection();
        //    Assert.True(conn.IsOpen);
        //}

        //[Fact]
        //public void CreateNewChannel_ReturnsOpenChannel()
        //{
        //    var filaServices = new FilaServices(_mockConfig.Object);
        //    using var channel = filaServices.CreateNewChannel();
        //    Assert.True(channel.IsOpen);
        //}
    }
}
