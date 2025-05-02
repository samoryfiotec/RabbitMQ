# Exemplo de como usar o RabbitMQ

Este repositório contém um exemplo de uso do RabbitMQ em uma aplicação .NET 8 utilizando C#. O objetivo é demonstrar como configurar um produtor e um consumidor para troca de mensagens.

[![RabbitMQ](https://img.shields.io/badge/RabbitMQ-4.0.6-FF6600)](https://www.rabbitmq.com/){:target="_blank"}
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/){:target="_blank"}
[![Docker](https://img.shields.io/badge/Docker-20.10-blue)](https://www.docker.com/){:target="_blank"}

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0){:target="_blank"}
- [RabbitMQ](https://www.rabbitmq.com/download.html){:target="_blank"} instalado e em execução
- [Docker](https://www.docker.com/){:target="_blank"} (opcional, para executar o RabbitMQ em um container)

## Configuração do RabbitMQ

Se você não possui o RabbitMQ configurado ou disponível, pode usar o Docker para iniciar rapidamente:

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
```

Acesse o painel de administração em [http://localhost:15672](http://localhost:15672){:target="_blank"} (usuário: `guest`, senha: `guest`).

## Estrutura do Projeto

- **APIEnvio**: Envia mensagens para a fila.
- **RabbitMQ**: Cria a fila de mensagens.
- **WorkerConsumidor**: Consome mensagens da fila.

## Referências

- [Documentação do RabbitMQ](https://www.rabbitmq.com/documentation.html){:target="_blank"}
- [Documentação do .NET](https://learn.microsoft.com/dotnet/){:target="_blank"}

## Licença

Este projeto é licenciado sob a [Apache License 2.0 License](LICENSE)