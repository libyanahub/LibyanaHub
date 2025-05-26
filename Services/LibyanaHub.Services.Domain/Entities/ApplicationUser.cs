using Microsoft.AspNetCore.Identity;

namespace LibyanaHub.Services.Domain.Entities.Identity
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public string Name { get; set; }

		/// <summary>Profile data for trainees</summary>
		public Trainee? TraineeProfile { get; set; }

		/// <summary>Profile data for coaches</summary>
		public Coach? CoachProfile { get; set; }

		/// <summary>Domain application requests</summary>
		public ICollection<UserDomain>? DomainApplications { get; set; } = new List<UserDomain>();
	}
}
