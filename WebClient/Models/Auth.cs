using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class Auth
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
