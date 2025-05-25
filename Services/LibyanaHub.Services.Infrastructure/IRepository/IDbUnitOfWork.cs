using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.IRepository
{
    public interface IDbUnitOfWork
    {
		IFitnessCategoryRepository FitnessCategoryRepository { get; }


		IApplicationUserRepository ApplicationUserRepository { get; }
	}
}
