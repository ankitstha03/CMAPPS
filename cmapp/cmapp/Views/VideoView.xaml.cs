using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

using MonkeyCache.FileStore;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace cmapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoView : ContentPage
    {
        ObservableCollection<Video> NewsCollection;
        private string Url = Constants.ur + "/api-auth/videos/";
        List<Video> videolist;
        App app = Application.Current as App;
        public VideoView()
        {
            InitializeComponent();

            DataGet();

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected)
                {
                    DataGet();
                }
            };
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NewsCollection.Where(c => c.title.StartsWith(e.NewTextValue));
            }
            else
            {
                NewsCollection = new ObservableCollection<Video>(videolist);
                listView.ItemsSource = NewsCollection.Reverse<Video>();
            }
        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Video;
            //await Navigation.PushAsync(new NepaliNewsDetailPage(dataCard), true);
            listView.SelectedItem = null;
        }



        private async void DataGet()
        {
            if (string.IsNullOrWhiteSpace(Barrel.Current.Get(Url)) && !CrossConnectivity.Current.IsConnected)
            {
                XFToast.ShortMessage("No Previous data or Internet");
                searbar.IsVisible = false;
            }
            else
            {
                try
                {
                    searbar.IsVisible = true;
                    videolist = await MoneyCache.GetAsync2<List<Video>>(Url);
                    foreach (Video n in videolist)
                    {
                        n.link = Constants.ScrubHtml2(n.link);
                    }
                    NewsCollection = new ObservableCollection<Video>(videolist);
                    listView.ItemsSource = NewsCollection.Reverse<Video>();
                    listView.Opacity = 0;
                    await listView.FadeTo(1, 1000, Easing.SpringIn);


                }
                catch (Exception ex)
                {
                }
            }
            listView.EndRefresh();

        }
    }
}