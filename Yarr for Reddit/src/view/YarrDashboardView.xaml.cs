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
        int postId = 1;
        Label title = new Label();
        Image image = new Image();
        string subredditName = "picture";

        public YarrDashboardView()
        {
            _ = api.getApiData(subredditName);
            InitializeComponent();
            CreatePost(postId);
        }

        public async void CreatePost(int postId)
        {
            await api.getApiData(subredditName);
         
            string uri;
            if (api.sub.data.children[postId].data.url_overridden_by_dest != null)
            {
                uri = api.sub.data.children[postId].data.url_overridden_by_dest;
            }
            else
            {
                uri = "https://cdn3.iconfinder.com/data/icons/abstract-1/512/no_image-512.png";
            }
            

            
            title.Content = api.sub.data.children[postId].data.title;
            title.FontSize = 70;
            title.FontFamily = new FontFamily("Trebuchet MS");
            //TODO afvangen dat uri string soms null is, geeft nu nog een error
            image.Source = new BitmapImage(new Uri(
             api.sub.data.children[postId].data.url_overridden_by_dest));
            image.Width = 250;
            image.Height = 300;

            stacky.Children.Add(title);
            stacky.Children.Add(image);
        }

        public void nextPost()
        {
            stacky.Children.Remove(title);
            stacky.Children.Remove(image);

            postId++;
            CreatePost(postId);
        }

        public void previousPost()
        {
            stacky.Children.Remove(title);
            stacky.Children.Remove(image);

            if (postId > 1)
            {
                postId--;
            }
            CreatePost(postId);
        }

        // Loads the next post.
        private void NextPostButton_Click(object sender, RoutedEventArgs e)
        {
            nextPost();
        }
        // Loads the previous post.
        private void PreviousPostButton_Click(object sender, RoutedEventArgs e)
        {
            previousPost();
        }

    }
}
