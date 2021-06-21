using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data.Initializers;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFlashcards.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ip> Ips { get; set; }
        public DbSet<UserIp> UserIps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddPrimaryKeys();
            modelBuilder.AddIdentityNavigation();
        }
    }
}
