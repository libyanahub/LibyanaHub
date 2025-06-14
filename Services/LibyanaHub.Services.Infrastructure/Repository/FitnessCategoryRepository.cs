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

		public async Task Update(FitnessCategory fitnessCategory)
		{
			if (fitnessCategory == null)
			{
				throw new ArgumentNullException(nameof(fitnessCategory));
			}

			var existingCourse = _dbContext.FitnessCategories.FirstOrDefault(c => c.Id == fitnessCategory.Id);
			if (existingCourse != null)
			{
				existingCourse.Name = fitnessCategory.Name;
				existingCourse.Description = fitnessCategory.Description;
				existingCourse.IconUrl = fitnessCategory.IconUrl;
				existingCourse.ImageUrl = fitnessCategory.ImageUrl;

				
				_dbContext.FitnessCategories.Update(existingCourse);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
