using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class Thread
    {
        public Thread()
        {
            Posts = new HashSet<Post>();
        }
        public Guid ThreadId { get; set; }
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public DateTime PostedOn { get; set; }

        public Users User { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
