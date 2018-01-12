using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime PostedOn { get; set; }

        public Thread Thread { get; set; }
        public Users User { get; set; }
    }
}
