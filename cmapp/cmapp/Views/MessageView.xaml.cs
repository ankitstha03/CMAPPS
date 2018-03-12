using cmapp.Models;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
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
	public partial class MessageView : ContentPage
	{

        ObservableCollection<Message> NewsCollection;
        private const string Url = "http://en.pradesh-5.com/api-auth/messages/";
        List<Message> messagelist;
        App app = Application.Current as App;
        public MessageView ()
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
            if (Constants.English)
            {
                send.Text = "Send Message";
            }
            else
            {
                send.Text = "सन्देश पठाउनुहोस्";
            }
          
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Message;

            await Navigation.PushAsync(new MessageDetailPage(dataCard), true);
            listView.SelectedItem = null;
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NewsCollection.Where(c => c.subject.StartsWith(e.NewTextValue));
            }
            else
            {
                NewsCollection = new ObservableCollection<Message>(messagelist);
                listView.ItemsSource = NewsCollection.Reverse<Message>();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactUs(),true);
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
                    messagelist = await MoneyCache.GetAsync<List<Message>>(Url);
                    NewsCollection = new ObservableCollection<Message>(messagelist);
                    listView.ItemsSource = NewsCollection.Reverse<Message>();
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