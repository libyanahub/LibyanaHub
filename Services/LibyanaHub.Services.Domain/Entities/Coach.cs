using LibyanaHub.Services.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class Coach : BaseEntity
	{
		[ForeignKey("ApplicationUser")]
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public string PassportNumber { get; set; }
		public string NationalId { get; set; }
		public string SelfieImageUrl { get; set; }
		public string IntroVideoUrl { get; set; }
		public string Bio { get; set; }

		public ICollection<CoachSpecialization> Specializations { get; set; } = new List<CoachSpecialization>();
		public ICollection<CoachCertificate> CoachCertificates { get; set; } = new List<CoachCertificate>();
		public ICollection<CoachExperience> Experiences { get; set; } = new List<CoachExperience>();
		public ICollection<CoachSocialLink> SocialLinks { get; set; } = new List<CoachSocialLink>();
	}
}
