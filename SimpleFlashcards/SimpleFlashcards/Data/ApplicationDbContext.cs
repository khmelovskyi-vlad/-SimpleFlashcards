using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data.Initializers;
using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.Ips;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Entities.Words;
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
        public DbSet<Language> Languages { get; set; }

        public DbSet<FileInfoWordImage> FileInfoWordImages { get; set; }
        public DbSet<FileInfoWordPronunciation> FileInfoWordPronunciations { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<FlashcardTopic> FlashcardTopics { get; set; }
        public DbSet<Subtopic> Subtopics { get; set; }
        public DbSet<FlashcardSubtopic> FlashcardSubtopics { get; set; }

        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardWord> FlashcardWords { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translation> Translations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddPrimaryKeys();
            modelBuilder.AddForeignKeys();
            modelBuilder.AddIdentityNavigation();
            modelBuilder.AddDefaultValues();
            modelBuilder.Seed(new FirstInitializer());
        }
    }
}
