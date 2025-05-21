using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.Infrastructure.IRepository
{
    public interface IFitnessCategoryRepository : IRepository<FitnessCategory>
	{
		void Update(FitnessCategory fitnessCategory);
	}
}
