using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data.Initializers;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.Ips;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
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


        public DbSet<FileInfo> FileInfos { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardTranslation> FlashcardTranslations { get; set; }
        public DbSet<FlashcardWord> FlashcardWords { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddPrimaryKeys();
            modelBuilder.AddIdentityNavigation();
        }
    }
}
