
using LibyanaHub.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LibyanaHub.Services.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{

		private IConfiguration _config;

		public AppDbContext(IConfiguration config, DbContextOptions<AppDbContext> options)
			: base(options)
		{
			_config = config;
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Use the connection string from appsettings.json
				{
					if (_config.GetSection("ASPNETCORE_ENVIRONMENT").Value == "Development")
					{
						//optionsBuilder.UseSqlServer("Server=localhost\\mshehobsql,1433;Database=GecolDB;User Id=vs_shehob;password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");

						optionsBuilder.UseSqlServer("Server=GECOL-SQL.libyana.ly;Database=GecolDB;User ID=gecol_user0;Password=JOe7Zsx7lRzcUUv;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");

					}
					else
					{
						optionsBuilder.UseSqlServer("Server=GECOL-SQL.libyana.ly;Database=GecolDB;User ID=gecol_user;Password=JOe7Zsx7lRzcUUv;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");


					}



				}
			}
		}

		public virtual DbSet<Test>? Tests { get; set; } = null;

	}
}