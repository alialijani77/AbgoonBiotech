namespace AbgoonBiotech.Domain.Entities.UserManagement
{
	public class ControllerInfo
	{
		#region Properties
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public IEnumerable<ActionInfo> Actions { get; set; }
		#endregion
	}
}