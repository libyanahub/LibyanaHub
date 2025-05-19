using LibyanaHub.Services.DataAccess.Data;
using LibyanaHub.Services.DataAccess.IRepository;
using LibyanaHub.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.DataAccess.Repository
{
	public class DbUnitOfWork : IDbUnitOfWork
	{
		private AppDbContext _db;
		public ITestRepository Test { get; private set; }


		public DbUnitOfWork(AppDbContext db)
		{
			_db = db;

			Test = new TestRepository(_db);
		}
	}
}