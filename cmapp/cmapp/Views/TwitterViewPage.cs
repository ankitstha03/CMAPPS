using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using cmapp.Models;
using Xamarin.Forms;

namespace cmapp.Views
{


    public class  TwitterViewPage : ContentPage
    {
        public  TwitterViewPage()


        {

            var source = new HtmlWebViewSource();
            //source.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            //var assetManager = Xamarin.Forms.Forms.Context.Assets;
            //using (var streamReader = new StreamReader(assetManager.Open("local.html")))
            //{
            //    source.Html = streamReader.ReadToEnd();
            //}

            source.Html = @"<a class=""twitter - timeline"" href=""https://twitter.com/shankarpokhrel8"">Tweets by shankarpokhrel8</a> <script async src=""https://platform.twitter.com/widgets.js"" charset=""utf-8""></script>";

            var labelhtml = new Xamarin.Forms.Label
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Text = source.Html,
            };
            var webview = new WebView
            {
                Source = source,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var inMemoryScrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                IsClippedToBounds = true,
                Content = labelhtml
            };

            Content = new StackLayout
            {
                Children = { webview ,
        }
            };


        






    }

    }
}
