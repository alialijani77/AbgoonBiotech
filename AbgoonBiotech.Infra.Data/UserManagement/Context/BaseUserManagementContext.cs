using AbgoonBiotech.Domain.Entities.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AbgoonBiotech.Infra.Data.UserManagement.Context
{
	public abstract class BaseUserManagementContext : IdentityDbContext<
   User, Role, int,
   IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
   IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		protected BaseUserManagementContext() { }

		public static BaseUserManagementContext CreateInstance(string connectionString, ILoggerFactory loggerFactory)
		{
			return new SqlServerUserManagementContext(connectionString, loggerFactory);
		}
	}
}