using LibyanaHub.Services.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class UserDomain : BaseEntity
	{
		[ForeignKey("ApplicationUser")]
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		/// <summary>
		/// E.g. “BodyBuilding”, “CrossFit”, “Computer Science”, “Mathematics”
		/// </summary>
		public string DomainType { get; set; }

		/// <summary>
		/// Application status if you ever need approval workflow
		/// (“Pending”, “Approved”, “Rejected”)
		/// </summary>
		public string Status { get; set; }

		public DateTime AppliedAt { get; set; }
		public DateTime? ApprovedAt { get; set; }
		public DateTime? RejectedAt { get; set; }
	}
}
