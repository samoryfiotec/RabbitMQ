var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapGet("/", () => "Esta é a aplicação para testar RabbitMQ");

app.Run();

