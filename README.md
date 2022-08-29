# sample-rabbitmq-netcore6
Exemplo de uso de fila de mensagens com RabbitMQ e .Net Core 6 Web API

# Execução
Para executar a API de produtos (Producer) e suas aplicações dependetes (MS Sql e RabbitMQ)

    docker compose up --build

Para exutar o aplicação console (Consumer)

    dotnet run RabbitMQProduct.ConsoleApplication/RabbitMQProduct.ConsoleApplication.csproj

### Baseado no artigo

[RabbitMQ Message Queue Using .NET Core 6 Web API](https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/)