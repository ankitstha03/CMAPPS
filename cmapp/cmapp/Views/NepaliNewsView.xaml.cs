using cmapp.Models;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NepaliNewsView : ContentPage
	{
        ObservableCollection<NepNews> NewsCollection;
        private string Url = Constants.ur + "/api-auth/news/";
        List<NepNews> newlist;
        App app = Application.Current as App;
        public NepaliNewsView ()
		{
			InitializeComponent ();
            
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
                NewsCollection = new ObservableCollection<NepNews>(newlist);
                listView.ItemsSource = NewsCollection.Reverse<NepNews>();
            }
        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as NepNews;
            await Navigation.PushAsync(new NepaliNewsDetailPage(dataCard), true);
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
                    newlist = await MoneyCache.GetAsync<List<NepNews>>(Url);
		            foreach(NepNews n in newlist)
                    {
		    	        n.desc= new String(n.description.Take(200).ToArray()) + "...";
                    }
                    NewsCollection = new ObservableCollection<NepNews>(newlist);
                    listView.ItemsSource = NewsCollection.Reverse<NepNews>();
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
