using SimpleFlashcards.Entities;
using SimpleFlashcards.Entities.Identities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Admin
{
    public class UserBanModel
    {
        public List<ApplicationUser> BannedUsers { get; set; }
        public List<ApplicationUser> NoBannedUsers { get; set; }
    }
}
