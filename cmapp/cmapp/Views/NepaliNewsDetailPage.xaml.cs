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
	public partial class NepaliNewsDetailPage : ContentPage
	{
		public NepaliNewsDetailPage (NepNews news)
		{
			InitializeComponent ();
            BindingContext = news;
            Title = new string(news.title.Take(15).ToArray()) + "...";
            Newsimage.SetBinding(Image.SourceProperty, "image_url");
            Newssource.SetBinding(Label.TextProperty, "category_name");
        }
	}
}