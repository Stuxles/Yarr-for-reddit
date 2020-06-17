using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Yarr_for_Reddit.src.viewmodel
{
    class SubredditViewModel
    {
        private String subredditTitle;
        public String SubredditTitle
        {
            get => subredditTitle;

            set
            {
                subredditTitle = value;
            }
        }

        //icon moet denk ik weg is visueel
        public Image SubredditIcon { get; set; }

        public List<PostViewModel> PostThread { get; }

        public SubredditViewModel()
        {
            PostThread = new List<PostViewModel>();
        }
    }
}
