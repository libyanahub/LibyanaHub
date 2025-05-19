using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.DataAccess.IRepository
{
    public interface ITestRepository : IRepository<Test>
	{
		void Update(Test test);
	}
}
