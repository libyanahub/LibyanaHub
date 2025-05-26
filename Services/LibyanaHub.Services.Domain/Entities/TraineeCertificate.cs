using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class TraineeCertificate : BaseEntity
	{
		[ForeignKey("Trainee")]
		public Guid TraineeId { get; set; }
		public Trainee Trainee { get; set; }

		public string CertificateName { get; set; }
		public DateTime IssuedOn { get; set; }
		public bool IsApproved { get; set; }
	}
}
