using AbgoonBiotech.Domain.Entities.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace AbgoonBiotech.Infra.Data.UserManagement.Context
{
	public class SqlServerUserManagementContext : BaseUserManagementContext
	{
		private readonly string _connectionstring;
		private readonly ILoggerFactory _loggerFactory;
		private static int _commandTimeout;

		public SqlServerUserManagementContext(string connectionstring, ILoggerFactory loggerFactory, int commandTimeout = 60)
		{
			_connectionstring = connectionstring;
			_loggerFactory = loggerFactory;
			_commandTimeout = commandTimeout;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored))
				.UseSqlServer(
					_connectionstring,
					options =>
					{
						options.CommandTimeout(_commandTimeout);
						options.MigrationsHistoryTable("A0_MIGRATIONS_HISTORY", "ABGOONBIOTECH");
					}
				 ).UseUpperCaseNamingConvention();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.HasDefaultSchema("ABGOONBIOTECH");
			modelBuilder.Entity<User>(b =>
			{
				b.HasMany(e => e.UserRoles)
					.WithOne(e => e.User)
					.HasForeignKey(ur => ur.UserId)
					.IsRequired();

			});
			modelBuilder.Entity<User>().Property(s => s.ConcurrencyStamp).HasMaxLength(2000);
			modelBuilder.Entity<User>().Property(s => s.PasswordHash).HasColumnType("NVARCHAR(max)");
			modelBuilder.Entity<User>().Property(s => s.SecurityStamp).HasColumnType("NVARCHAR(max)");
			modelBuilder.Entity<User>().Property(s => s.PhoneNumber).HasColumnType("NVARCHAR(max)");
			modelBuilder.Entity<User>().Property(p => p.JoinDate).HasColumnType("TIMESTAMP").HasMaxLength(6).IsRequired();


			modelBuilder.Entity<IdentityUserClaim<int>>().Property(s => s.ClaimValue).HasMaxLength(2000);
			modelBuilder.Entity<IdentityUserClaim<int>>().Property(s => s.ClaimType).HasMaxLength(2000);


			modelBuilder.Entity<Role>(b =>
			{
				b.HasMany(e => e.UserRoles)
					.WithOne(e => e.Role)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();
			});
			modelBuilder.Entity<Role>().Property(s => s.ConcurrencyStamp).HasMaxLength(2000);
			modelBuilder.Entity<Role>().Property(s => s.Access).HasColumnType("NVARCHAR(max)");
			modelBuilder.Entity<Role>().Property(s => s.Description).HasColumnType("NVARCHAR(max)");

			modelBuilder.Entity<IdentityRoleClaim<int>>().Property(s => s.ClaimValue).HasMaxLength(2000);
			modelBuilder.Entity<IdentityRoleClaim<int>>().Property(s => s.ClaimType).HasMaxLength(2000);


			modelBuilder.Entity<IdentityUserLogin<int>>().Property(s => s.ProviderDisplayName).HasColumnType("NVARCHAR(max)");

			modelBuilder.Entity<IdentityUserToken<int>>().Property(s => s.Value).HasColumnType("NVARCHAR(max)");

			modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("ID").ValueGeneratedNever();
			modelBuilder.Entity<Role>().Property(p => p.Id).HasColumnName("ID").ValueGeneratedNever();
			modelBuilder.Entity<IdentityRoleClaim<int>>().Property(p => p.Id).HasColumnName("ID").ValueGeneratedNever();
			modelBuilder.Entity<IdentityUserClaim<int>>().Property(p => p.Id).HasColumnName("ID").ValueGeneratedNever();
			modelBuilder.Entity<IdentityUserClaim<int>>().Property(p => p.Id).HasColumnName("ID").ValueGeneratedNever();

			modelBuilder.Entity<User>().ToTable("ASP_NET_USERS");
			modelBuilder.Entity<Role>().ToTable("ASP_NET_ROLES");
			modelBuilder.Entity<UserRole>().ToTable("ASP_NET_USER_ROLES");
			modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("ASP_NET_USER_CLAIMS");
			modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("ASP_NET_ROLE_CLAIMS");
			modelBuilder.Entity<IdentityUserToken<int>>().ToTable("ASP_NET_USER_TOKENS");
			modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("ASP_NET_USER_LOGINS");
		}
	}
}