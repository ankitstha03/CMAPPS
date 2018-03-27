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
            string temp;
            if (notific.title_image == "" || notific.title_image == null)
            {
                temp = "<html><body style=\"width:95%;\"><h1 style=\"text-align:center;\"> " + notific.title + "</h1><br><p>" + notific.start_date + "</p><br><p style=\"text-align:justify!important;\">" + notific.description + "</p></body></html> ";

            }
            else
            {
                temp = "<html><body style=\"width:95%;\"><h1 style=\"text-align:center;\"> " + notific.title + "</h1><br><img style=\"width:100%; object-fit:contain;\" src=\"" + notific.title_image + "\"><br><p>" + notific.start_date + "</p><br><p style=\"text-align:justify!important;\">" + notific.description + "</p></body></html> ";
            }
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = temp;
            browser.Source = htmlSource;
            browser.Margin = new Thickness(5);
            browser.HorizontalOptions = LayoutOptions.Center;
            Content = browser;
        }
	}
}