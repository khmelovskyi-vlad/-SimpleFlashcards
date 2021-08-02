using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data.Initializers;
using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Identities.Ips;
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
            //modelBuilder.Entity<Word>().HasOne(x => x.TParent)
            //        .WithMany(x => x.Translations)
            //        .HasForeignKey(x => x.TParentId)
            //        .IsRequired(false)
            //        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Translation>()
                .HasKey(t => new { t.WordId1, t.WordId2 });
            modelBuilder.Entity<Word>().HasMany(h => h.Translations1).WithOne(h => h.Word1)
                .HasForeignKey(p => p.WordId1);
            modelBuilder.Entity<Word>().HasMany(h => h.Translations2).WithOne(h => h.Word2)
                .HasForeignKey(p => p.WordId2);

        }
    }
}
