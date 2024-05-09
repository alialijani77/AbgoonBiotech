namespace AbgoonBiotech.Domain.Entities.Common
{
	public interface IBaseEntity
	{
		DateTime CreatedAt { get; set; }

		DateTime UpdatedAt { get; set; }

		int CreatedBy { get; set; }

		int UpdatedBy { get; set; }

		int Version { get; set; }
	}

	public abstract class BaseEntity : IBaseEntity
	{
		public virtual DateTime CreatedAt { get; set; }

		public virtual DateTime UpdatedAt { get; set; }

		public virtual int CreatedBy { get; set; }

		public virtual int UpdatedBy { get; set; }

		public virtual int Version { get; set; }
	}
}