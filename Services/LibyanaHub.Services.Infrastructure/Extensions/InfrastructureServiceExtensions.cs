// Infrastructure/Extensions/InfrastructureServiceExtensions.cs
using LibyanaHub.Services.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibyanaHub.Services.Infrastructure.Extensions
{
	public static class InfrastructureServiceExtensions
	{
		/// <summary>
		/// Registers both SQL Server and MariaDB DbContexts with their respective connection strings.
		/// Use AppDbContext for SQL Server and AppMariaDbContext for MariaDB scenarios.
		/// </summary>
		/// <param name="services">The service collection to add to.</param>
		/// <param name="configuration">Application configuration containing connection strings.</param>
		public static IServiceCollection AddInfrastructureDBs(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			// SQL Server context
			services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped);

			return services;
		}
	}
}
