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

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationPage : ContentPage
	{
        
        ObservableCollection<Notifications> NotiCollection;
        private const string Url = "https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=92348f99d6004ff2b789dd74af818e16";
        private HttpClient _client = new HttpClient();
        Newlist newlist;
        News newse;
        App app = Application.Current as App;

        public NotificationPage ()
		{
			InitializeComponent ();
		}

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Notifications;

            await Navigation.PushAsync(new NewsDetailPage(newse), true);
            listView.SelectedItem = null;
        }

        private void Onrefresh(object sender, EventArgs e)
        {
            foreach (Notifications n in Constants._notification)
            {
                n.unread = false;
                n.color = Color.White;
            }
            NotiCollection = new ObservableCollection<Notifications>(Constants._notification);
            listView.ItemsSource = NotiCollection.Reverse<Notifications>();
            listView.EndRefresh();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var content = await _client.GetStringAsync(Url);
            newlist = JsonConvert.DeserializeObject<Newlist>(content);
            newse = newlist.articles.First<News>();
            NotiCollection = new ObservableCollection<Notifications>(Constants._notification);
            listView.ItemsSource = NotiCollection.Reverse<Notifications>();
            view.Margin = new Thickness(-200, 0, 200, 0);
            view.TranslateTo(200, 0, 1000, Easing.SpringIn);
            listView.Opacity = 0;
            listView.FadeTo(1, 1000, Easing.SpringIn);
          
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            foreach (Notifications n in Constants._notification)
            {
                n.unread = false;
                n.color = Color.White;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            foreach (Notifications n in Constants._notification)
            {
                n.unread = false;
                n.color = Color.White;
            }
            return false;
        }
    }
}