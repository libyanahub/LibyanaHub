using LibyanaHub.Services.DataAccess.Data;
using LibyanaHub.Services.DataAccess.IRepository;
using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.DataAccess.Repository
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
