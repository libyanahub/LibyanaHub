using LibyanaHub.Services.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.IRepository
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
		public void Update(ApplicationUser applicationUser);
	}
}