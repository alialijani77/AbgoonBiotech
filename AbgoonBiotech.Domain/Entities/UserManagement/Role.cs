using Microsoft.AspNetCore.Identity;

namespace AbgoonBiotech.Domain.Entities.UserManagement
{
	public class Role : IdentityRole<int>
	{
		#region Properties
		public string Description { get; set; }
		public string Access { get; set; }
		#endregion
		#region Relation
		public virtual ICollection<UserRole> UserRoles { get; set; }
		#endregion
	}
}
