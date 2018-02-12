using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cmapp.Models;
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
            BindingContext = news;
            Title= new string(news.title.Take(15).ToArray())+"...";
            Newsimage.SetBinding(Image.SourceProperty, "urlToImage");
            Newssource.SetBinding(Label.TextProperty, "source.name");
        }
	}
}