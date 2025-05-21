using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class DbUnitOfWork : IDbUnitOfWork
	{
		private AppDbContext _db;
		public IFitnessCategoryRepository Test { get; private set; }


		public DbUnitOfWork(AppDbContext db)
		{
			_db = db;

			Test = new FitnessCategoryRepository(_db);
		}
	}
}