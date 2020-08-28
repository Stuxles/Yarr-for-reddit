using System;
using System.Collections.Generic;
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

        public YarrDashboardView()
        {
            api.getApiData();
            InitializeComponent();
            CreatePost();
        }

        public async void CreatePost()
        {
            await api.getApiData();
            Image image = new Image();
            string uri;
            if (api.sub.data.children[1].data.url_overridden_by_dest != null)
            {
                uri = api.sub.data.children[1].data.url_overridden_by_dest;
            }
            else
            {
                uri = "https://cdn3.iconfinder.com/data/icons/abstract-1/512/no_image-512.png";
            }
            

            Label title = new Label();
            title.Content = api.sub.data.children[1].data.title;
            title.FontSize = 70;
            title.FontFamily = new FontFamily("Trebuchet MS");
            image.Source = new BitmapImage(new Uri(
             api.sub.data.children[1].data.url_overridden_by_dest));
            image.Width = 500;
            image.Height = 600;

            
            stacky.Children.Add(title);
            stacky.Children.Add(image);
        }

    }
}
