using Microsoft.AspNetCore.Identity;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Identities.Ips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Identities.Base
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsInBan { get; set; }

        public List<UserIp> UserIps { get; set; }

        public List<ApplicationUserClaim> Claims { get; set; }
        public List<ApplicationUserLogin> Logins { get; set; }
        public List<ApplicationUserToken> Tokens { get; set; }
        public List<ApplicationUserRole> UserRoles { get; set; }
        //public List<Flashcard> Flashcards { get; set; }
    }
}
