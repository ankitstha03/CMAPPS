using System;
using System.Collections.Generic;
using System.Text;
using cmapp.Models;
using Xamarin.Forms;

namespace cmapp.Views
{
    public class TwitterViewPage : ContentPage
    {
        public TwitterViewPage()
        {
            BackgroundColor = Color.White;

            var twitterViewModel = new TweetingViewModel();

            BindingContext = twitterViewModel;

            var dataTemplate = new DataTemplate(() =>
            {
                var screenNameLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 22
                };

                var textLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 18
                };

                var image = new Image
                {
                    WidthRequest = 60,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start
                };

                var mediaImage = new Image();

                screenNameLabel.SetBinding(Label.TextProperty, new Binding("ScreenName"));
                textLabel.SetBinding(Label.TextProperty, new Binding("Text"));
                image.SetBinding(Image.SourceProperty, new Binding("ImageUrl"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("MediaUrl"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 5),
                        Children =
                        {
                            image,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    screenNameLabel,
                                    textLabel,
                                    mediaImage
                                }
                            }
                        }
                    }
                };

            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "Tweets");
            listView.ItemTemplate = dataTemplate;

            Content = new StackLayout
            {
                Padding = new Thickness(5, 10),
                Children =
                {
                    listView

                }
            };

        }
    }
}
