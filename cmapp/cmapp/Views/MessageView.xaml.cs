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
	public partial class MessageView : ContentPage
	{
        ObservableCollection<News> NewsCollection;
        private const string Url = "https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=92348f99d6004ff2b789dd74af818e16";
        Newlist newlist;
        App app = Application.Current as App;
        public MessageView ()
		{
			InitializeComponent ();
            send.Text = "Send Message";
		}

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as News;

            await Navigation.PushAsync(new NewsDetailPage(dataCard), true);
            listView.SelectedItem = null;
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NewsCollection.Where(c => c.title.StartsWith(e.NewTextValue));
            }
            else
            {
                NewsCollection = new ObservableCollection<News>(newlist.articles);
                listView.ItemsSource = NewsCollection.Reverse<News>();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactUs(),true);
        }
        private async void Onrefresh(object sender, EventArgs e)
        {
            newlist = await MoneyCache.GetAsync<Newlist>(Url);
            NewsCollection = new ObservableCollection<News>(newlist.articles);
            listView.ItemsSource = NewsCollection.Reverse<News>();
            listView.EndRefresh();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            newlist = await MoneyCache.GetAsync<Newlist>(Url);
            NewsCollection = new ObservableCollection<News>(newlist.articles);
            listView.ItemsSource = NewsCollection.Reverse<News>();
            view.Margin = new Thickness(-200, 0, 200, 0);
            view.TranslateTo(200, 0, 1000, Easing.SpringIn);
            listView.Opacity = 0;
            listView.FadeTo(1, 1000, Easing.SpringIn);
        }
    }
}