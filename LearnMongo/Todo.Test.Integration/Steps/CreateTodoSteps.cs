using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Todo.Infrastructure.Context;
using Todo.WebApi;

namespace Todo.Test.Integration.Steps
{
    [Binding]
    public class CreateTodoSteps
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private HttpResponseMessage? _response;
        private string? _title;

        public CreateTodoSteps(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Given(@"I have a todo with title ""(.*)""")]
        public void GivenIHaveATodoWithTitle(string title)
        {
            _title = title;
        }

        [When(@"I send a Post request to ""(.*)""")]
        public async Task WhenISendAPostRequestTo(string url)
        {
            var dto = new { Title = _title, IsCompleted = false };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _response = await _client.PostAsync(url, content);
        }

        [Then(@"the response should be sucessful")]
        public void ThenTheResponseShouldBeSucessful()
        {
            _response.Should().NotBeNull();
            _response.EnsureSuccessStatusCode();
            _response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Then(@"the todo should exist in the database")]
        public async Task ThenTheTodoShouldExistInTheDatabase()
        {
            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var exists = await dbContext.TodoItems.AnyAsync(x => x.Title == _title);
            exists.Should().BeTrue();

        }

        [Then(@"the response should be bad request")]
        public void ThenTheResponseShouldBeBadRequest()
        {
            _response.Should().NotBeNull();
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
        
        [Then(@"the todo should contain error ""(.*)""")]
        public async Task ThenTheTodoShouldContainError(string expectedMessage)
        {
            var content = await _response!.Content.ReadAsStringAsync();
            content.Should().Contain(expectedMessage);
        }

    }
}
