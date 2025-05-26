using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.Entities
{
	public class Course : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
