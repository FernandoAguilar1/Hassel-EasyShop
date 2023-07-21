using EasyShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitialSeed(builder);
        }

        private void InitialSeed(ModelBuilder builder)
        {
            //ROLES
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "Customer" }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            //USERS
            List<IdentityUser> users = new List<IdentityUser>() {
                new IdentityUser() {
                    UserName = "admin@easyshop.com",
                    NormalizedUserName = "ADMIN@EASYSHOP.COM",
                    Email = "admin@easyshop.com",
                    NormalizedEmail = "ADMIN@EASYSHOP.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };
            builder.Entity<IdentityUser>().HasData(users);

            //ADMIN PASSWORD
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            users[0].PasswordHash = ph.HashPassword(users[0], "Admin.easy.1");

            //ADMIN ROLE
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}