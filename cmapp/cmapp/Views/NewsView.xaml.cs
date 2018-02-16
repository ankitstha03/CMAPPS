using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using cmapp.Models;


namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsView : ContentPage
	{
        ObservableCollection<News> NewsCollection;
        private const string Url = "https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=92348f99d6004ff2b789dd74af818e16";
        Newlist newlist;
        App app = Application.Current as App;

        public NewsView ()
		{
			InitializeComponent ();
		}

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as News;

            await Navigation.PushAsync(new NewsDetailPage(dataCard),true);
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