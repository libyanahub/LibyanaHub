using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class CoachSpecialization : BaseEntity
	{
		[ForeignKey("Coach")]
		public Guid CoachId { get; set; }
		public Coach Coach { get; set; }

		[ForeignKey("FitnessCategory")]
		public Guid FitnessCategoryId { get; set; }
		public FitnessCategory FitnessCategory { get; set; }

		public string SpecializationNote { get; set; }
		public int ExperienceYears { get; set; }
	}
}
