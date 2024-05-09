using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbgoonBiotech.Infra.Data.UserManagement.Context
{
	public class SqlServerUserManagementDesignTimeFactory : IDesignTimeDbContextFactory<SqlServerUserManagementContext>
	{
		public SqlServerUserManagementContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, false)
				.Build();

			return new SqlServerUserManagementContext(configuration.GetConnectionString("UserManagement"), null);
		}
	}
}
