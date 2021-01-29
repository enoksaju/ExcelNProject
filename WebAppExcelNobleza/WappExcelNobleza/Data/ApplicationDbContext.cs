using excelnobleza.shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WappExcelNobleza.Data.Models.Identity;

namespace WappExcelNobleza.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			ConfigureIdentity(builder);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole("Admin") { Id = "e6ba880d-864f-4d16-9ee2-225f7af5788f" },
				new IdentityRole("Systems") { Id= "7bda7324-b6ba-41f7-b78b-305feabb5e1f" },
				new IdentityRole("Developer") { Id= "c95a97cc-99f5-458f-b714-aecc3389f830" },
                new IdentityRole("Generic") { Id= "e96df311-2a07-4757-beff-1878c9823093" },
                new IdentityRole("User") { Id= "5aed0bf0-0e3e-423f-bd6f-cd2083f041ba" }
                ); ;
		}

		private void ConfigureIdentity(ModelBuilder builder)
		{
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

			builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
			builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));
		}

		public static implicit operator ApplicationDbContext(ApplicationDbContextCore v)
		{
			throw new NotImplementedException();
		}
	}
}
