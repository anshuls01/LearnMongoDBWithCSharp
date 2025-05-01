using FluentValidation;
using Todo.Application.Interfaces;
using Todo.Application.Services;
using Todo.Application.Validators;
using Todo.Infrastructure.Extensions;
namespace Todo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<TodoItemDtoValidator>();
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
