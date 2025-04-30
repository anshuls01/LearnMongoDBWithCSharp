using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Interfaces;
using Todo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Context;

namespace Todo.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(ConnectionString));
            services.AddScoped<ITodoRepository, EfCoreTodoRepository>();
            return services;
        }
    }
}
