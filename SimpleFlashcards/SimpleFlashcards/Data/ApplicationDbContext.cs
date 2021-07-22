using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.Ips;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Extensions;
using System;

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

        public DbSet<Country> Countries { get; set; }

        public DbSet<FileInfoWordImage> FileInfoWordImages { get; set; }
        public DbSet<FileInfoWordPronunciation> FileInfoWordPronunciations { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }

        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardWord> FlashcardWords { get; set; }
        public DbSet<Word> Words { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddPrimaryKeys();
            modelBuilder.AddIdentityNavigation();
        }
    }
}
