using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Todo.Application.Interfaces;
using Todo.Infrastructure.Context;
using Todo.Infrastructure.Repositories;
using Todo.Infrastructure.Settings;

namespace Todo.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var appSettings = config.GetSection("AppSettings").Get<AppSettings>();

            var mode = appSettings.PersistenceMode;

            switch (mode)
            {
                case "mongo":
                    services.AddSingleton<IMongoClient>(_ => new MongoClient(appSettings.MongoDb));
                    services.AddScoped<ITodoRepository, MongoDbTodoRepository>();
                    break;
                case "sqlite":
                    services.AddDbContext<AppDbContext>(options => options.UseSqlite(appSettings.DefaultConnection));
                    services.AddScoped<ITodoRepository, EfCoreTodoRepository>();
                    break;
                case "inmemory":
                    services.AddScoped<ITodoRepository, InMemoryTodoRepository>();
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported persistence mode: {mode}");
            }
            return services;
        }
    }
}
