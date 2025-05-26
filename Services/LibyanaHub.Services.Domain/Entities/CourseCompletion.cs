using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class CourseCompletion : BaseEntity
	{
		[ForeignKey("Trainee")]
		public Guid TraineeId { get; set; }
		public Trainee Trainee { get; set; }

		[ForeignKey("Course")]
		public Guid CourseId { get; set; }
		public Course Course { get; set; }

		public DateTime CompletedAt { get; set; }
	}
}
