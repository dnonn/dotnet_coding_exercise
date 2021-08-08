using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Contacts.Domain.Repositories;
using Contacts.Infrastructure.Repositories;

namespace Contacts.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationAssembly = typeof(ContactContext).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ContactContext>(
                options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                sqlite => sqlite.MigrationsAssembly(migrationAssembly)));

            services.AddTransient<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
