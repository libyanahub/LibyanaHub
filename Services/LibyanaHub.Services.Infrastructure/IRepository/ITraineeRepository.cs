using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.IRepository
{
	public interface ITraineeRepository : IRepository<Trainee>
	{
		public Task Update(Trainee trainee);
	}
}
