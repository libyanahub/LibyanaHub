using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Models.UserDomain
{
	public class Output
	{
		public Guid Id { get; set; }
		public Guid ApplicationUserId { get; set; }
		public string DomainType { get; set; }
		public string Status { get; set; }
		public DateTime AppliedAt { get; set; }
		public DateTime? ApprovedAt { get; set; }
		public DateTime? RejectedAt { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
