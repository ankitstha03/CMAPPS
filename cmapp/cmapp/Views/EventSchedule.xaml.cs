using cmapp.Models;
using MonkeyCache.FileStore;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventSchedule : ContentPage
	{
        ObservableCollection<Notifications> NewsCollection;
        private const string Url = "http://en.pradesh-5.com/api-auth/events/";
        List<Notifications> messagelist;
        App app = Application.Current as App;
        public EventSchedule ()
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
                    messagelist = await MoneyCache.GetAsync<List<Notifications>>(Url);
                    NewsCollection = new ObservableCollection<Notifications>(messagelist);
                    timelineListView.ItemsSource = NewsCollection;
                    timelineListView.Opacity = 0;
                    await timelineListView.FadeTo(1, 1000, Easing.SpringIn);
                }catch(Exception ex)
                {
                }
            }
            timelineListView.EndRefresh();

        }
        private async void timelineListView_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Notifications;
            await Navigation.PushAsync(new NotifDetailPage(dataCard), true);

            timelineListView.SelectedItem = null;
        }

    }
}
