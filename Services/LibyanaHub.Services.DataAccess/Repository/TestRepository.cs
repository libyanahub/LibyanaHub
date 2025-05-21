using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.Repository
{
    public class TestRepository : Repository<Test>, ITestRepository
	{
		private readonly AppDbContext _dbContext;

		public TestRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;

		}

		public void Update(Test test)
		{
			_dbContext.Tests.Update(test);
		}
	}
}
