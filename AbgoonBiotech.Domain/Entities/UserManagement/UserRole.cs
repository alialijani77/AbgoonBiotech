using Microsoft.AspNetCore.Identity;

namespace AbgoonBiotech.Domain.Entities.UserManagement
{
	public class UserRole : IdentityUserRole<int>
	{
		#region Relation
		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
		#endregion
	}
}