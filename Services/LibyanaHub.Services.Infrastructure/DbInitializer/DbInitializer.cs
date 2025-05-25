using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Domain.StaticData;
using LibyanaHub.Services.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.DbInitializer
{
    public class DbInitializer : IDbInitializer
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly AppDbContext _db;

		public DbInitializer(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			AppDbContext db)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_db = db;
		}

		public void Initialize()
		{


			//migrations if they are not applied
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}
			}
			catch (Exception ex) { }



			//create roles if they are not created
			if (!_roleManager.RoleExistsAsync(SD.Roles.Trainee).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Roles.Trainee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Roles.Employee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Roles.Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Roles.Coach)).GetAwaiter().GetResult();


				//if roles are not created, then we will create admin user as well
				_userManager.CreateAsync(new ApplicationUser
				{
					UserName = "218947776156",
					Email = "m.shehob@libyana.ly",
					Name = "Mahmood Shehob",
					PhoneNumber = "218947776156",
					//StreetAddress = "Abu-Setta",
					//State = "YF",
					//PostalCode = "23422",
					//City = "Yefren"
				}, "ASDasd@123").GetAwaiter().GetResult();

				ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "m.shehob@libyana.ly");

				_userManager.AddToRoleAsync(user, SD.Roles.Admin).GetAwaiter().GetResult();
			}

			return;
		}
	}
}