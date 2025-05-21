using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.Repository
{
    public class FitnessCategoryRepository : Repository<FitnessCategory>, IFitnessCategoryRepository
	{
		private readonly AppDbContext _dbContext;

		public FitnessCategoryRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;

		}

		public void Update(FitnessCategory fitnessCategory)
		{
			_dbContext.FitnessCategories.Update(fitnessCategory);
		}
	}
}
