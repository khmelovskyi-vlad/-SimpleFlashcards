using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities
{
    public class RolePermissions
    {
        public string RoleName { get; set; }
        public List<ClaimModel> Permissions { get; set; }
    }
}
