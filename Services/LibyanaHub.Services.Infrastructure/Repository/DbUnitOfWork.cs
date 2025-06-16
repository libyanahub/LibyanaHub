using LibyanaHub.Services.Domain.Entities;
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


		public ICoachRepository Coach { get; private set; }
		public ITraineeRepository Trainee { get; private set; }
		public IUserDomainRepository UserDomain { get; private set; }

		public DbUnitOfWork(AppDbContext db)
		{
			_db = db;

			ApplicationUser = new ApplicationUserRepository(_db);
			
			Course = new CourseRepository(_db);
			
			FitnessCategory = new FitnessCategoryRepository(_db);


			Coach = new CoachRepository(_db);
			Trainee = new TraineeRepository(_db);
			UserDomain = new UserDomainRepository(_db);
		}
	}
}