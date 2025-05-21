using System.ComponentModel.DataAnnotations;

namespace LibyanaHub.Services.Domain.Entities
{
	public abstract class BaseModel
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.UtcNow;

		public DateTimeOffset? UpdateDate { get; set; }
	}
}