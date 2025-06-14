using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.Infrastructure.IRepository
{
    public interface IFitnessCategoryRepository : IRepository<FitnessCategory>
	{
		Task Update(FitnessCategory fitnessCategory);
	}
}
