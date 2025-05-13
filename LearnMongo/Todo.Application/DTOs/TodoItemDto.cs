namespace Todo.Application.DTOs
{
    public class TodoItemDto
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
