using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
		ITestRepository Test { get; }

		void Save();
	}
}
