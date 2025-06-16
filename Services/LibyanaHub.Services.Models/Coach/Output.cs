using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Models.Coach
{
	public class Output
	{
		public Guid Id { get; set; }
		public Guid ApplicationUserId { get; set; }
		public string PassportNumber { get; set; }
		public string NationalId { get; set; }
		public string SelfieImageUrl { get; set; }
		public string IntroVideoUrl { get; set; }
		public string Bio { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
