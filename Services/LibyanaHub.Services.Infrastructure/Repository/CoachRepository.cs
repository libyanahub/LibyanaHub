using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class CoachRepository : Repository<Coach>, ICoachRepository
	{
		private readonly AppDbContext _dbContext;

		public CoachRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Update(Coach coach)
		{
			if (coach == null)
			{
				throw new ArgumentNullException(nameof(coach));
			}

			var existingCoach = await _dbContext.Coaches.FirstOrDefaultAsync(c => c.Id == coach.Id);
			if (existingCoach != null)
			{
				// Update all relevant properties
				existingCoach.PassportNumber = coach.PassportNumber;
				existingCoach.NationalId = coach.NationalId;
				existingCoach.SelfieImageUrl = coach.SelfieImageUrl;
				existingCoach.IntroVideoUrl = coach.IntroVideoUrl;
				existingCoach.Bio = coach.Bio;

				_dbContext.Coaches.Update(existingCoach);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}