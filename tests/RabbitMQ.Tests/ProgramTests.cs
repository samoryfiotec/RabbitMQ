using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace APIEnvio.Tests
{
    // Fix for CS0051: Ensure WebApplicationFactory<Program> is public
    public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        // Constructor updated to match accessibility of WebApplicationFactory<Program>
        public ProgramTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnsExpectedMessage()
        {
            // Arrange
            var client = _factory.CreateClient(); // This method is now valid with the correct WebApplicationFactory

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Esta é a aplicação para testar RabbitMQ", content);
        }
    }
}

// Fix for CS0051: Ensure WebApplicationFactory<Program> is public
public class WebApplicationFactory<T>
{
}
