using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.Infrastructure.IRepository
{
    public interface ITestRepository : IRepository<Test>
	{
		void Update(Test test);
	}
}
