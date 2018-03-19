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
            Title = new string(news.title.Take(40).ToArray()) + "...";
            var browser = new WebView
            {
                Source = news.url
            };
            Content = browser;
        }


    }
}