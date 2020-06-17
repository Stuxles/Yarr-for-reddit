using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarr_for_Reddit.src.model
{
    class CommentModel
    {
        public String CommentText { get; set; }
        public  int Upvote { get; set; }

        public int Downvote { get; set; }
    }
}
