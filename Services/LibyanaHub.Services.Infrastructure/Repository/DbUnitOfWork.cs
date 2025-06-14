using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;

namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class DbUnitOfWork : IDbUnitOfWork
	{
		private AppDbContext _db;

		public IApplicationUserRepository ApplicationUser { get; private set; }

		public ICourseRepository Course { get; private set; }

		public IFitnessCategoryRepository FitnessCategory { get; private set; }

		public DbUnitOfWork(AppDbContext db)
		{
			_db = db;

			ApplicationUser = new ApplicationUserRepository(_db);
			
			Course = new CourseRepository(_db);
			
			FitnessCategory = new FitnessCategoryRepository(_db);
		}
	}
}