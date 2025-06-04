using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManagementSystem.Infrastructure.Seeders;

namespace TaskManagementSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //rejestracja DbContextu w ramach metody rozszerzającej do AddInfrastructure
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TaskManagementSystem")));

            //Rejestracja seedera TaskManagementSystemSeeder dla długości życia Scoped
            services.AddScoped<TaskManagementSystemSeeder>();
        }

        
    }
}
