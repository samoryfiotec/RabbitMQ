# Exemplo de como usar o RabbitMQ

Este repositório contém um exemplo de uso do RabbitMQ em uma aplicação .NET 8 utilizando C#. O objetivo é demonstrar como configurar um produtor e um consumidor para troca de mensagens.

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

## Referências

- [Documentação do RabbitMQ](https://www.rabbitmq.com/documentation.html)
- [Documentação do .NET](https://learn.microsoft.com/dotnet/)

## Licença

Este projeto é licenciado sob a [Apache License 2.0 License](LICENSE)