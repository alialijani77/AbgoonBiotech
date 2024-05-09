namespace AbgoonBiotech.Domain.Entities.Common
{
	public class History
	{
		public History()
		{
			if (Id == Guid.Empty)
				Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

		public string EntityType { get; set; }

		public string EntityId { get; set; }

		public string ReferenceId { get; set; }

		public string Action { get; set; }

		public int? UserId { get; set; }

		public string NewData { get; set; }

		public string OldData { get; set; }

		public DateTime? Date { get; set; }
	}
}
