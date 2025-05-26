using System.ComponentModel.DataAnnotations;

namespace LibyanaHub.Services.Domain.Entities
{
	public abstract class BaseEntity
	{
		public Guid Id { get; protected set; } = Guid.NewGuid();
		public DateTime CreateDate { get; private set; }
		public DateTime UpdateDate { get; private set; }

		public void SetCreated()
		{
			if (CreateDate == default)
				CreateDate = DateTime.UtcNow;
		}

		public void SetUpdated()
		{
			UpdateDate = DateTime.UtcNow;
		}
	}
}