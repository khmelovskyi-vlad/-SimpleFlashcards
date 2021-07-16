using SimpleFlashcards.Entities.Identities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Identities.Ips
{
    public class UserIp
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid IpId { get; set; }
        public Ip Ip { get; set; }
    }
}
