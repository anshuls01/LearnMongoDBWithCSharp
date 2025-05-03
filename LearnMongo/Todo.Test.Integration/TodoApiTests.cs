using System.Net.Http.Json;
using Todo.WebApi;

namespace Todo.Test.Integration
{
    public class TodoApiTests :IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public TodoApiTests(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }
        [Fact]
        public async Task PostTodo_ShouldReturnCreated()
        {
            var dto = new { Title = "Integration Test" };
            var response = await _httpClient.PostAsJsonAsync("/api/todo", dto);

            response.EnsureSuccessStatusCode(); // 200-299
        }
    }
}
