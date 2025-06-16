using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Models.UserDomain
{
	public class Input
	{
		public Guid Id { get; set; }
		public Guid ApplicationUserId { get; set; }
		public string DomainType { get; set; }
		public string Status { get; set; }
	}
}
