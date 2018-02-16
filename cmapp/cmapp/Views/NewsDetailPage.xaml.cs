using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cmapp.Models;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsDetailPage : ContentPage
	{
		public NewsDetailPage (News news)
		{
			InitializeComponent ();
            if (CrossConnectivity.Current.IsConnected) { 
                var browser = new WebView
            {
                Source = news.url
            };
            Content = browser;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("No Internet", "Please connect to the internet to view this page", "OK");
                await Navigation.PopAsync(true);
            }
        }

    }
}