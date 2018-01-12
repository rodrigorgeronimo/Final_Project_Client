using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class Users
    {
        public Users()
        {
            Auth = new HashSet<Auth>();
            Posts = new HashSet<Post>();
            Threads = new HashSet<Thread>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<Auth> Auth { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Thread> Threads { get; set; }
    }
}
