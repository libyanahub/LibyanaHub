using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.IRepository
{
	public interface ICoachRepository : IRepository<Coach>
	{
		public Task Update(Coach coach);
	}
}
