using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class CoachCertificate : BaseEntity
	{
		[ForeignKey("Coach")]
		public Guid CoachId { get; set; }
		public Coach Coach { get; set; }

		public string CertificateName { get; set; }
		public string IssuingOrganization { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string CertificateFileUrl { get; set; }
	}
}
