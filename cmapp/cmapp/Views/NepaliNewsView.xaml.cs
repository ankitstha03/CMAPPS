using cmapp.Models;
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
        private const string Url = "http://pradesh-5.com/api-auth/news/";
        List<NepNews> newlist;
        App app = Application.Current as App;
        public NepaliNewsView ()
		{
			InitializeComponent ();
            DataGet();
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
            newlist = await MoneyCache.GetAsync<List<NepNews>>(Url);
            NewsCollection = new ObservableCollection<NepNews>(newlist);
            listView.ItemsSource = NewsCollection.Reverse<NepNews>();
            listView.EndRefresh();
        }

        private async void DataGet()
        {
            newlist = await MoneyCache.GetAsync<List<NepNews>>(Url);
            NewsCollection = new ObservableCollection<NepNews>(newlist);
            listView.ItemsSource = NewsCollection.Reverse<NepNews>();
            listView.Opacity = 0;
            await listView.FadeTo(1, 1000, Easing.SpringIn);
        }

    }
}