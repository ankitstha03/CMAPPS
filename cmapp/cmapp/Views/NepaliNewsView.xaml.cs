using cmapp.Models;
using Newtonsoft.Json;
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
        private const string Url = "http://ratopati.com/jsonapi/wow-request/";
        private HttpClient _client = new HttpClient();
        Nepali newlist;
        App app = Application.Current as App;
        public NepaliNewsView ()
		{
			InitializeComponent ();
		}

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as NepNews;

            await Navigation.PushAsync(new NepaliNewsDetailPage(dataCard), true);
            listView.SelectedItem = null;
        }

   

        private async void Onrefresh(object sender, EventArgs e)
        {
            var content = await _client.GetStringAsync(Url);
            newlist = JsonConvert.DeserializeObject<Nepali>(content);
            var temp = newlist.news_categories.SingleOrDefault(c => c.News_type.Equals("Latest news"));
            NewsCollection = new ObservableCollection<NepNews>(temp.links);
            listView.EndRefresh();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var content = await _client.GetStringAsync(Url);
            newlist = JsonConvert.DeserializeObject<Nepali>(content);
            var temp = newlist.news_categories.SingleOrDefault(c => c.News_type.Equals("Latest news"));
            NewsCollection = new ObservableCollection<NepNews>(temp.links);
            listView.ItemsSource = NewsCollection.Reverse<NepNews>();
            view.Margin = new Thickness(-200, 0, 200, 0);
            view.TranslateTo(200, 0, 1000, Easing.SpringIn);
            listView.Opacity = 0;
            listView.FadeTo(1, 1000, Easing.SpringIn);
        }
    }
}