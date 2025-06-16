using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class CourseRepository : Repository<Course>, ICourseRepository
	{
		private readonly AppDbContext _dbContext;


		public CourseRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;

		}

		public async Task Update(Course course)
		{
			if (course == null)
			{
				throw new ArgumentNullException(nameof(course));
			}

			var existingCourse = _dbContext.Courses.FirstOrDefault(c => c.Id == course.Id);
			if (existingCourse != null)
			{
				existingCourse.Title = course.Title;
				existingCourse.Description = course.Description;
				_dbContext.Courses.Update(existingCourse);
				await _dbContext.SaveChangesAsync(); // Fix: Use await instead of return for async method  
			}
		}
	}
}
