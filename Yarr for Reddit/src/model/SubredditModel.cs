using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Yarr_for_Reddit.src.model
{
    class SubredditModel
    {
        public String SubredditTitle { get; set; }

        public Image SubredditIcon { get; set; }

        public List<PostModel> PostThread { get; }

        public SubredditModel()
        {
            PostThread = new List<PostModel>();
        }

        public void FillPostThread(PostModel model)
        {
            PostThread.Add(model);
        }
    }
}
