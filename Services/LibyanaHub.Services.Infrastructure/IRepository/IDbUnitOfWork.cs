namespace LibyanaHub.Services.Infrastructure.IRepository
{
    public interface IDbUnitOfWork
    {
		IFitnessCategoryRepository FitnessCategory { get; }

		IApplicationUserRepository ApplicationUser { get; }

		ICourseRepository Course { get; }


		ICoachRepository Coach { get; }
		ITraineeRepository Trainee { get; }
		IUserDomainRepository UserDomain { get; }
	}
}
