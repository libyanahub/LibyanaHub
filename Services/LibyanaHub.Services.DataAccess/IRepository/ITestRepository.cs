using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.DataAccess.IRepository
{
    public class ITestRepository : IRepository<Test>
	{
		Task Update(Test test);
	}
}
