using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace UsersApi.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //set default application admin user
            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            //generate admin password
            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            //entity with admin data
            builder.Entity<IdentityUser<int>>().HasData(admin);

            //create role
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> {
                    Id = 99999,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );

            //bind between user and role
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> {
                    RoleId = 99999,
                    UserId = 99999
                }
            );

        }
    }

}