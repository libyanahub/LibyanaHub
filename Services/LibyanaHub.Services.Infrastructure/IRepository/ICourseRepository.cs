using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.IRepository
{
	public interface ICourseRepository : IRepository<Course>
	{
		public Task Update(Course course);
	}
}
