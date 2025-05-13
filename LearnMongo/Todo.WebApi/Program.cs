using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection.Metadata;
using Todo.Application.Interfaces;
using Todo.Application.Services;
using Todo.Application.Todos.Commands.CreateTodo;
using Todo.Application.Validators;
using Todo.Infrastructure.Extensions;
using Todo.Infrastructure.Settings;
namespace Todo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //configuration
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional:true,reloadOnChange:true)
                                .AddUserSecrets<Program>()
                                .AddEnvironmentVariables();


            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            // Add services to the container.
            builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<TodoItemDtoValidator>();
                });

            builder.Services.AddMediatR(typeof(AssemblyReference).Assembly, 
                                        typeof(CreateTodoCommandHandler).Assembly);
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddPersistence(builder.Configuration);
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
