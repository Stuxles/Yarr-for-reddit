using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Yarr_for_Reddit.src.view
{
    /// <summary>
    /// Interaction logic for YarrDashboardView.xaml
    /// </summary>
    public partial class YarrDashboardView : Window
    {
        private readonly ApiHandler api = new ApiHandler();
        readonly Label title = new Label();
        readonly TextBlock selftext = new TextBlock();
        readonly Image image = new Image();
        string subredditName = "Pics";
        private int postId = 0;

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
            PreviousPostButtonEnabler();
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            var Page = (postId + 1).ToString();
            currentPageTextBlock.Text = "Page : " + Page;

            SubredditNameTextBlock.Text = "Name : " + api.sub.data.children[postId].data.subreddit_name_prefixed;
            SubredditSubscribersTextBlock.Text = "Subscribers : " + api.sub.data.children[postId].data.subreddit_subscribers;

            authorTextBlock.Text = "Author : " + api.sub.data.children[postId].data.author;
            upvotesTextBlock.Text = "Upvotes : " + api.sub.data.children[postId].data.ups;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(api.sub.data.children[postId].data.created_utc));
            createdUTCTextBlock.Text ="Created at : " + dateTimeOffset;
        }
        /// <summary>
        /// Go to next post in subreddit
        /// </summary>
        public void NextPost()
        {
            postId++;
            CreatePost();
        }
        /// <summary>
        /// Go to previous post in subreddit
        /// </summary>
        public void PreviousPost()
        {
            if (postId > 0)
            {
                postId--;
            }
            CreatePost();
        }
        /// <summary>
        /// Disables Previous post button if there is no previous post available
        /// </summary>
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

        private void NextPostButton_Click(object sender, RoutedEventArgs e)
        {
            NextPost();
        }
      
        private void PreviousPostButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousPost();
        }

        private void GoToSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = t.Text;
            postId = 0;
            CreatePost();
        }

        //Popular subreddit shortcuts
        /// <summary>
        /// Go to r/Gaming button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamingSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Gaming";
            postId = 0;
            CreatePost();
        }
        /// <summary>
        /// Go to r/TheNetherlands button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheNetherlandsSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "TheNetherlands";
            postId = 0;
            CreatePost();
        }
        /// <summary>
        /// Go to r/AjaxAmsterdam button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjaxAmsterdamSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "AjaxAmsterdam";
            postId = 0;
            CreatePost();
        }
        /// <summary>
        /// Go to r/Funny button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunnySubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Funny";
            postId = 0;
            CreatePost();
        }
        /// <summary>
        /// Go to r/AskReddit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AskRedditSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "AskReddit";
            postId = 0;
            CreatePost();
        }
        /// <summary>
        /// Go to r/Pics button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicsSubredditButton_Click(object sender, RoutedEventArgs e)
        {
            subredditName = "Pics";
            postId = 0;
            CreatePost();
        }
    }
}
