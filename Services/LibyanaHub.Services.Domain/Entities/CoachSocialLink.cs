using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class CoachSocialLink : BaseEntity
	{
		[ForeignKey("Coach")]
		public Guid CoachId { get; set; }
		public Coach Coach { get; set; }

		public string PlatformName { get; set; }
		public string ProfileUrl { get; set; }
	}
}
