var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapGet("/", () => "Esta � a aplica��o para testar RabbitMQ");

app.Run();

