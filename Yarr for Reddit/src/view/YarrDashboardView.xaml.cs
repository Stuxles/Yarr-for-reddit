using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Yarr_for_Reddit.src;

namespace Yarr_for_Reddit.src.view
{
    /// <summary>
    /// Interaction logic for YarrDashboardView.xaml
    /// </summary>
    public partial class YarrDashboardView : Window
    {
        ApiHandler api = new ApiHandler();
        int postId = 0;
        Label title = new Label();
        Image image = new Image();
        string subredditName = "picture";

        public YarrDashboardView()
        {
            _ = api.GetApiData(subredditName);
            InitializeComponent();
            CreatePost();
            t.Text = subredditName;
        }

        public async void CreatePost()
        {
            await api.GetApiData(subredditName);
         
            
            //title
            title.Content = api.sub.data.children[postId].data.title;
            title.FontSize = 42;
            title.FontFamily = new FontFamily("Trebuchet MS");

            //image
            string uriString;
            if (api.sub.data.children[postId].data.url_overridden_by_dest != null)
            {
                uriString = api.sub.data.children[postId].data.url_overridden_by_dest;
            }
            else
            {
                uriString = "https://cdn3.iconfinder.com/data/icons/abstract-1/512/no_image-512.png";
            }
            image.Source = new BitmapImage(new Uri(uriString));
            image.Width = 250;
            image.Height = 300;

            stacky.Children.Clear();
            stacky.Children.Add(title);
            stacky.Children.Add(image);

        }

        public void NextPost()
        {
            postId++;
            CreatePost();
        }

        public void PreviousPost()
        {
            if (postId > 1)
            {
                postId--;
            }
            CreatePost();
        }

        // Loads the next post.
        private void NextPostButton_Click(object sender, RoutedEventArgs e)
        {
            NextPost();
        }
        // Loads the previous post.
        private void PreviousPostButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousPost();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            subredditName = t.Text;
        }

        private void GoToSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            postId = 0;
            CreatePost();
        }
    }
}
