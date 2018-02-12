using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace cmapp.Views
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

           
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "ssss.png",
                WidthRequest = 150,
                HeightRequest = 150
            };
            var labelFormatted = new Label();
            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Shankhar", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = "Pokhrel ", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.None });
            labelFormatted.FormattedText = fs;

            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.4, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(labelFormatted,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelFormatted,
             new Rectangle(0.5, 0.6, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(splashImage);
            sub.Children.Add(labelFormatted);
            this.BackgroundColor = Color.FromHex("#448AFF");
            this.Content = sub;

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await labelFormatted.ScaleTo(0.9, 1000, Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new LoginPage());    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}