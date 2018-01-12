using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class ForumModel
    {
        public ForumModel()
        {
            Thread = new HashSet<Thread>();
        }

        public ICollection<Thread> Thread { get; set; }
    }
}
