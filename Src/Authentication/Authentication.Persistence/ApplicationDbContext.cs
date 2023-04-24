using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain.Entities.ApplicationUser;

using Microsoft.EntityFrameworkCore;
using Authentication.Domain.Entities.ApplicationUser.Enums;
using Microsoft.AspNetCore.Identity;
using Authentication.Domain.Entities.ApplicationRole;

namespace Authentication.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;database=LeqaaAuthentication;Uid=root;pwd=2510203121";
                optionsBuilder.UseMySql(connectionString,
                                  ServerVersion.AutoDetect(connectionString))
                                  .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<ApplicationUser>();
            var seedAdminRole = new ApplicationRole
            {
                Id = "a746c47a-da6d-45ad-910f-257aad147375",
                Name = "admin",
                NormalizedName = "ADMIN",
            };
            var seedUserRole = new ApplicationRole
            {
                Id = "a746c47a-da6d-45ad-910f-257aad147376",
                Name = "user",
                NormalizedName = "USER",
            };
            modelBuilder.Entity<ApplicationRole>().HasData(seedAdminRole, seedUserRole);
            var seedApplicationUser = new ApplicationUser
            {
                Id = "a746c47a-da6d-45ad-910f-257aad147375",
                Name = "Leqaa",
                Email = "Leqaa.Technical@gmail.com",
                Gender = Gender.Female,
                EmailConfirmed = true,
                NormalizedEmail = "LEQAA.TECHNICAL@GMAIL.COM",
                UserName = "Leqaa",
                NormalizedUserName = "LEQAA",
                PasswordHash = hasher.HashPassword(null!, "P@ssw0rd123")
            };
            var seedIdentityAdminRole = new IdentityUserRole<string>
            {
                RoleId = "a746c47a-da6d-45ad-910f-257aad147375",
                UserId = "a746c47a-da6d-45ad-910f-257aad147375"
            };
            var seedIdentityUserRole = new IdentityUserRole<string>
            {
                RoleId = "a746c47a-da6d-45ad-910f-257aad147376",
                UserId = "a746c47a-da6d-45ad-910f-257aad147375"
            };

            modelBuilder.Entity<ApplicationUser>().HasData(seedApplicationUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(seedIdentityAdminRole, seedIdentityUserRole);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
