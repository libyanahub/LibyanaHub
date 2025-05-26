using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class CoachExperience : BaseEntity
	{
		[ForeignKey("Coach")]
		public Guid CoachId { get; set; }
		public Coach Coach { get; set; }

		public string OrganizationName { get; set; }
		public string RoleTitle { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Description { get; set; }
	}
}
