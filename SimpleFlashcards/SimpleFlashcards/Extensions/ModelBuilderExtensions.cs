using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data.Initializers;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.Ips;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Entities.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, IInitializer initializer)
        {
            initializer.Run(modelBuilder);
        }
        public static void AddIdentityNavigation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }
        public static void AddPrimaryKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIp>()
                .HasKey(ui => new { ui.UserId, ui.IpId });
            modelBuilder.Entity<FlashcardWord>()
                .HasKey(fw => new { fw.FlashcardId, fw.WordId });
            modelBuilder.Entity<Translation>()
                .HasKey(t => new { t.WordId1, t.WordId2 });
            modelBuilder.Entity<FlashcardSubtopic>()
                .HasKey(fs => new { fs.FlashcardId, fs.SubtopicId });

        }
        public static void AddForeignKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().HasMany(w => w.Translations1).WithOne(t => t.Word1)
                .HasForeignKey(t => t.WordId1).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Word>().HasMany(w => w.Translations2).WithOne(t => t.Word2)
                .HasForeignKey(t => t.WordId2).OnDelete(DeleteBehavior.Restrict);
        }
        public static void AddDefaultValues(this ModelBuilder modelBuilder)
        {
        }
    }
}
