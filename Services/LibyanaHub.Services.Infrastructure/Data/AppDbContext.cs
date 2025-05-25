using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Domain.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibyanaHub.Services.Infrastructure.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
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

						//optionsBuilder.UseSqlServer("Server=GECOL-SQL.libyana.ly;Database=GecolDB;User ID=gecol_user0;Password=JOe7Zsx7lRzcUUv;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");

						optionsBuilder.UseSqlServer("Server=localhost\\mshehobsql,1433;Database=LibynaHubDB_Test;User Id=vs_shehob;password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");
					}
					else
					{
						optionsBuilder.UseSqlServer("Server=localhost\\mshehobsql,1433;Database=LibynaHubDB_Pro;User Id=vs_shehob;password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");
					}
				}
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//// Seed IdentityRole entries from SD.Roles
			//builder.Entity<IdentityRole>().HasData(
			//	new IdentityRole
			//	{
			//		Name = SD.Roles.Admin,
			//		NormalizedName = SD.Roles.Admin.ToUpper()
			//	},
			//	new IdentityRole
			//	{
			//		Name = SD.Roles.Employee,
			//		NormalizedName = SD.Roles.Employee.ToUpper()
			//	},
			//	new IdentityRole
			//	{
			//		Name = SD.Roles.Commercial,
			//		NormalizedName = SD.Roles.Commercial.ToUpper()
			//	},
			//	new IdentityRole
			//	{
			//		Name = SD.Roles.Coach,
			//		NormalizedName = SD.Roles.Coach.ToUpper()
			//	},
			//	new IdentityRole
			//	{
			//		Name = SD.Roles.Trainee,
			//		NormalizedName = SD.Roles.Trainee.ToUpper()
			//	}
			//);
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		public DbSet<FitnessCategory> FitnessCategories { get; set; }
	}
}