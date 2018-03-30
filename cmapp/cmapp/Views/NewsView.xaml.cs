using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonkeyCache.FileStore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using cmapp.Models;
using Plugin.Connectivity;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsView : ContentPage
	{
        ObservableCollection<News> NewsCollection;
        private string Url ;
        List<News> newlist;
        App app = Application.Current as App;

        public NewsView(string url)
		{
			InitializeComponent ();
            Url = url;
            
                DataGet();

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected)
                {
                    DataGet();
                }
            };
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as News;
            if (CrossConnectivity.Current.IsConnected)
            {
                await Navigation.PushAsync(new NewsDetailPage(dataCard), true);
            }
            else
            {
                XFToast.ShortMessage("No Internet Connection");
            }
            listView.SelectedItem = null;
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {

                if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NewsCollection.Where(c => c.title.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            else
            {
                NewsCollection = new ObservableCollection<News>(newlist);
                listView.ItemsSource = NewsCollection;
            }
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
                    newlist = await MoneyCache.GetAsync<List<News>>(Url);
                    NewsCollection = new ObservableCollection<News>(newlist);
                    listView.ItemsSource = NewsCollection;
                    listView.Opacity = 0;
                    await listView.FadeTo(1, 1000, Easing.SpringIn);
                }catch(Exception ex)
                {
                }
            }

            listView.EndRefresh();

        }

    }
}
