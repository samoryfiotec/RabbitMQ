﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FilaService.Abstractions
{
    public interface IFilaServices
    {
        bool RabbitMQEnabled { get; }

        public interface IFilaServices
        {
            void SendMessage<T>(T message);

            void SendToDeadLetterQueue(BasicDeliverEventArgs ea);

            IConnection CreateNewConnection();

            IModel CreateNewChannel();

            bool RabbitMQEnabled { get; }
        }
    }
}
