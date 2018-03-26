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
	public partial class NepaliNewsDetailPage : ContentPage
	{
		public NepaliNewsDetailPage (NepNews news)
		{
			InitializeComponent ();
            BindingContext =news;
            Title = new string(news.title.Take(40).ToArray()) + "...";
            string temp;
            if (news.title_image == "" || news.title_image == null)
            {
                temp = "<html><body style=\"width:100%;\"><h1 style=\"text-align:center;\"> " + news.title + "</h1><br><p>" + news.date + "</p><br><p style=\"text-align:justify!important;\">" + news.description + "</p></body></html> ";

            }
            else
            {
                temp = "<html><body style=\"width:100%;\"><h1 style=\"text-align:center;\"> " + news.title + "</h1><br><img style=\"width:100%; object-fit:contain;\" src=\"" + news.title_image + "\"><br><p>" + news.date + "</p><br><p style=\"text-align:justify!important;\">" + news.description + "</p></body></html> ";
            }
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = temp;
            browser.Source = htmlSource;
            Content = browser;
        }

    }
}