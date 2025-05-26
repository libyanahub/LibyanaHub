using LibyanaHub.Services.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class Trainee : BaseEntity
	{
		[ForeignKey("ApplicationUser")]
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		/// <summary>Courses completed by the trainee</summary>
		public ICollection<CourseCompletion> CourseCompletions { get; set; } = new List<CourseCompletion>();

		/// <summary>Certificates earned by the trainee</summary>
		public ICollection<TraineeCertificate> Certificates { get; set; } = new List<TraineeCertificate>();
	}
}
