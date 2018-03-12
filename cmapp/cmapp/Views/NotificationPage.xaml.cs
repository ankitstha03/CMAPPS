using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cmapp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using MonkeyCache.FileStore;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationPage : ContentPage
	{
        
        ObservableCollection<Notifications> NotiCollection;
        private const string Url = "http://en.pradesh-5.com/api-auth/notices/";
        List<Notifications> notlist;
        App app = Application.Current as App;

        public NotificationPage ()
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

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Notifications;
            await Navigation.PushAsync(new NotifDetailPage(dataCard), true);

            listView.SelectedItem = null;
        }


        private async void DataGet()
        {
            if (string.IsNullOrWhiteSpace(Barrel.Current.Get(Url)) && !CrossConnectivity.Current.IsConnected)
            {
                XFToast.ShortMessage("No Previous data or Internet");
            }
            else
            {
                try
                {
                    notlist = await MoneyCache.GetAsync<List<Notifications>>(Url);
                    NotiCollection = new ObservableCollection<Notifications>(notlist);
                    listView.ItemsSource = NotiCollection.Reverse<Notifications>();
                    listView.Opacity = 0;
                    await listView.FadeTo(1, 1000, Easing.SpringIn);
                }
                catch(Exception e)
                {
                }
                
            }
                
            listView.EndRefresh();
        }

    }
}