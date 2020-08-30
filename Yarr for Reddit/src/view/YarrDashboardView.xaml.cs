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
        TextBlock selftext = new TextBlock();
        Image image = new Image();
        string subredditName = "Pictures";

        public YarrDashboardView()
        {
            InitializeComponent();
            CreatePost();
            t.Text = subredditName;
        }

        public async void CreatePost()
        {
            await api.GetApiData(subredditName);
         
            //title
            title.Content = api.sub.data.children[postId].data.title;
            title.FontSize = 28;
            title.FontFamily = new FontFamily("Trebuchet MS");

            //selftext
            selftext.Text = api.sub.data.children[postId].data.selftext;
            selftext.FontSize = 12;
            selftext.FontFamily = new FontFamily("Trebuchet MS");
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
            image.Width = 600;
            image.Height = 500;

            //update view
            Stack.Children.Clear();
            Stack.Children.Add(title);
            Stack.Children.Add(selftext);
            Stack.Children.Add(image);
            currentPageTextBlock.Text = "Page : "+ postId.ToString();
            PreviousPostButtonEnabler();
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            SubredditNameTextBlock.Text = "Name : " + api.sub.data.children[postId].data.subreddit_name_prefixed;
            SubredditSubscribersTextBlock.Text = "Subscribers : " + api.sub.data.children[postId].data.subreddit_subscribers;

            authorTextBlock.Text = "Author : " + api.sub.data.children[postId].data.author;
            upvotesTextBlock.Text = "Upvotes : " + api.sub.data.children[postId].data.ups;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(api.sub.data.children[postId].data.created_utc));
            createdUTCTextBlock.Text ="Created at : " + dateTimeOffset;
        }

        public void NextPost()
        {
            postId++;
            CreatePost();
        }

        public void PreviousPost()
        {
            if (postId > 0)
            {
                postId--;
            }
            CreatePost();
        }

        public void PreviousPostButtonEnabler()
        {
            if (postId == 0)
            {
                PreviousPostButton.IsEnabled = false;
                PreviousPostButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                PreviousPostButton.IsEnabled = true;
                PreviousPostButton.Visibility = Visibility.Visible;
            }
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

        private void gamingSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Gaming";
            CreatePost();
        }

        private void TheNetherlandsSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "TheNetherlands";
            CreatePost();
        }

        private void AjaxAmsterdamSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "AjaxAmsterdam";
            CreatePost();
        }

        private void FunnySubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Funny";
            CreatePost();
        }

        private void AskRedditSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "AskReddit";
            CreatePost();
        }

        private void PicsSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Pics";
            CreatePost();
        }
    }
}
