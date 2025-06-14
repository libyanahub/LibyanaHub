using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Models.FitnessCategory
{
	public class Output : BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }
		public string ImageUrl { get; set; }
	}
}
