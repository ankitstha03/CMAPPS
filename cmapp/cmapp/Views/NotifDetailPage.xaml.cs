using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotifDetailPage : ContentPage
	{
		public NotifDetailPage (Notifications notific)
		{
			InitializeComponent ();
            BindingContext = notific;
            Title = new string(notific.title.Take(40).ToArray()) + "...";
            string temp = "<html><body><h1 style=\"text-align:center;\"> " + notific.title + "</h1><br><img style=\"size:cover;\" src=\"" + notific.title_image + "\"><br><p>" + notific.start_date + "</p><br><p style=\"text-align:justify!important;;\">" + notific.description + "</p></body></html> ";
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = temp;
            browser.Source = htmlSource;
            Content = browser;
        }
	}
}