using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LibyanaHub.Services.Infrastructure.Data
{
	public class AppDbContext
		: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{

		// Design-time constructor
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var currentUser = Environment.UserName;

				if (currentUser.ToLower() == "MAHMO".ToLower())
				{
					optionsBuilder.UseSqlServer("Server=localhost\\mshehobsql,1433;Database=LibyanaHubTest;User ID=vs_shehob;Password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");
				}
				else if (currentUser.ToLower() == "HQB-L3-18101974".ToLower())
				{
					optionsBuilder.UseSqlServer("Server=HQB-L3-18101974\\SHEHOBSQLSER;Database=LibyanaHubTest;User ID=vs_shehob;Password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");
				}
				else
				{
					optionsBuilder.UseSqlServer("Server=localhost\\mshehobsql,1433;Database=LibyanaHubProd;User ID=vs_shehob;Password=vs_sh123;TrustServerCertificate=true;Encrypt=false;MultipleActiveResultSets=true");
				}
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// any further Fluent API goes here
		}

		// ==============================================
		// DbSets (alphabetical)
		// ==============================================
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Coach> Coaches { get; set; }
		public DbSet<CoachCertificate> CoachCertificates { get; set; }
		public DbSet<CoachExperience> CoachExperiences { get; set; }
		public DbSet<CoachSocialLink> CoachSocialLinks { get; set; }
		public DbSet<CoachSpecialization> CoachSpecializations { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseCompletion> CourseCompletions { get; set; }
		public DbSet<FitnessCategory> FitnessCategories { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<TraineeCertificate> TraineeCertificates { get; set; }
		public DbSet<UserDomain> UserDomains { get; set; }
	}
}
