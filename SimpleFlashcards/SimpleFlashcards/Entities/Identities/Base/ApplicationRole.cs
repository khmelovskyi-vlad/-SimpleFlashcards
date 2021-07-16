using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Identities.Base
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }

        public List<ApplicationUserRole> UserRoles { get; set; }
        public List<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
