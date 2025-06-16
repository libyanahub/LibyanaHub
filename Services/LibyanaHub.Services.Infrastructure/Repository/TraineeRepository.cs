using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;


namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class TraineeRepository : Repository<Trainee>, ITraineeRepository
	{
		private readonly AppDbContext _dbContext;

		public TraineeRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Update(Trainee trainee)
		{
			if (trainee == null)
			{
				throw new ArgumentNullException(nameof(trainee));
			}

			var existingTrainee = await _dbContext.Trainees.FirstOrDefaultAsync(t => t.Id == trainee.Id);
			if (existingTrainee != null)
			{
				// The Trainee entity itself has no properties to update besides the BaseEntity ones.
				// If you add properties later, update them here.

				_dbContext.Trainees.Update(existingTrainee);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}