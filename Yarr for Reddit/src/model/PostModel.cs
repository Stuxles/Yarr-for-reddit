using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;

namespace Yarr_for_Reddit.src.model
{
    class PostModel
    {
        public String Title { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }

        public Image Picture { get; set; }

        public List<CommentModel> CommentThread { get; }

        public PostModel()
        {
            CommentThread = new List<CommentModel>();
            
        }

        public void FillCommentThread(CommentModel model) {
            CommentThread.Add(model);
        }
    }
}
