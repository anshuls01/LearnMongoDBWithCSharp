using Moq;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Application.Services;
using Todo.Core.Entities;

namespace Todo.Application.Tests.Services
{
    public class TodoServiceTest
    {
        [Fact]
        public async Task GetAllAsync_ReturnsListOfTodos()
        {
            //setup
            var mockRepo = new Mock<ITodoRepository>();
            mockRepo.Setup(x => x.GetAllAsync(new CancellationToken())).ReturnsAsync(new List<TodoItem> { new TodoItem() { IsCompleted = false, Title = "Read Book", CreatedAt = DateTime.Now, Id = "1" } });

            //Act
            var service = new TodoService(mockRepo.Object);
            IEnumerable<TodoItemDto>? todos = await service.GetAllTodosAsync();

            //Assert
            Assert.NotNull(todos);
            Assert.Single(todos);
            Assert.Equal("Read Book", todos.First().Title);
        }
    }
}
