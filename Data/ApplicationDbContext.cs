using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.ApplicationUsers>().ToTable("Users","Security");
            builder.Entity<IdentityUserRole<String>>().ToTable("UsersRoles", "Security");
            builder.Entity<IdentityUserLogin<String>>().ToTable("UsersLogin", "Security");
            builder.Entity<IdentityUserToken<String>>().ToTable("UsersTokens", "Security");

        }
    }
   
}
