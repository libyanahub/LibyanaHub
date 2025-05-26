using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Shared.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibyanaHub.Services.Infrastructure.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole<Guid>> _roleManager;
		private readonly AppDbContext _db;

		public DbInitializer(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole<Guid>> roleManager,
			AppDbContext db)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_db = db;
		}

		public void Initialize()
		{
			// 1) apply any pending migrations
			if (_db.Database.GetPendingMigrations().Any())
				_db.Database.Migrate();

			// 2) seed roles
			var roles = new[] {
				SD.Roles.Admin,
				SD.Roles.Employee,
				SD.Roles.Commercial,
				SD.Roles.Coach,
				SD.Roles.Trainee
			};
			foreach (var roleName in roles)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					var role = new IdentityRole<Guid>(roleName)
					{
						Id = Guid.NewGuid(),
						NormalizedName = roleName.ToUpperInvariant()
					};
					_roleManager.CreateAsync(role).GetAwaiter().GetResult();
				}
			}

			// 3) seed default admin user
			const string adminEmail = "m.shehob@libyana.ly";
			if (_userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult() == null)
			{
				var adminUser = new ApplicationUser
				{
					Id = Guid.NewGuid(),
					UserName = "218947776156",
					Email = adminEmail,
					NormalizedEmail = adminEmail.ToUpperInvariant(),
					Name = "Mahmood Shehob",
					PhoneNumber = "218947776156"
				};
				_userManager.CreateAsync(adminUser, "ASDasd@123").GetAwaiter().GetResult();
				_userManager.AddToRoleAsync(adminUser, SD.Roles.Admin).GetAwaiter().GetResult();
			}
		}
	}
}
