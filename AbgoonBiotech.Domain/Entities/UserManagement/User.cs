using Microsoft.AspNetCore.Identity;

namespace AbgoonBiotech.Domain.Entities.UserManagement
{
	public class User : IdentityUser<int>
	{
		#region Properties
		public bool Enable { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsAccessToConfigOperation { get; set; }
		public DateTime JoinDate { get; set; }
		public int? ParentUserId { get; set; }
		#endregion
		#region Relation
		public virtual ICollection<UserRole> UserRoles { get; set; }
		#endregion
	}
}