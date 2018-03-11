using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeyCache.FileStore;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
        ObservableCollection<News> NewsCollection1;
        ObservableCollection<NepNews> NewsCollection2;

        private const string Url1 = "http://pradesh-5.com/api-auth/press-news/";
        private const string Url2 = "http://pradesh-5.com/api-auth/news/";
        List<News> newlist1;
        List<NepNews> newlist2;
        App app = Application.Current as App;

        public HomeView ()
		{
			InitializeComponent ();
			StackLayout sls = new StackLayout
			{
			    Spacing = 10,
			    Padding = new Thickness(3, 3, 3, 3),
			    Orientation = StackOrientation.Vertical

			};

            
                DataGet();
            //view.Margin = new Thickness(-200, 0, 200, 0);
            //view.TranslateTo(200, 0, 1000, Easing.SpringIn);


        }



        private async void DataGet()
        {

            if (string.IsNullOrWhiteSpace(Barrel.Current.Get(Url1)) && !CrossConnectivity.Current.IsConnected)
            {
                XFToast.LongMessage("No Previous data or Internet");
            }
            else
            {
                newlist1 = await MoneyCache.GetAsync<List<News>>(Url1);
                newlist2 = await MoneyCache.GetAsync<List<NepNews>>(Url2);
                newlist1 = newlist1.Take(3).ToList();
                newlist2 = newlist2.Take(3).ToList();

                NewsCollection1 = new ObservableCollection<News>(newlist1);
                NewsCollection2 = new ObservableCollection<NepNews>(newlist2);

                foreach(News n in newlist1){
			Frame fram= new Frame
			{
			    IsClippedToBounds = true,
			    CornerRadius=12,
			    HasShadow = true,
			    BackgroundColor = Color.White,
			    OutlineColor = Color.Gray,
			    Margin = new Thickness(7),
			    Padding = new Thickness(5)
			};
			
			var tapGestureRecognizer = new TapGestureRecognizer();
             		tapGestureRecognizer.Tapped += async (s, e) => {
                  		if (CrossConnectivity.Current.IsConnected)
			    {
				await Navigation.PushAsync(new NewsDetailPage(n), true);
			    }
			    else
			    {
				XFToast.LongMessage("No Internet Connection");
			    }
		 	 };

               		 fram.GestureRecognizers.Add(tapGestureRecognizer);
			 sls.Children.Add(fram);
		}
		
		foreach(NepNews n2 in newlist2){
			Frame fram2= new Frame
			{
			    IsClippedToBounds = true,
			    CornerRadius=12,
			    HasShadow = true,
			    BackgroundColor = Color.White,
			    OutlineColor = Color.Gray,
			    Margin = new Thickness(7),
			    Padding = new Thickness(5)
			};
			
			var tapGestureRecognizer2 = new TapGestureRecognizer();
             		tapGestureRecognizer2.Tapped += async (s, e) => {
				await Navigation.PushAsync(new NepaliNewsDetailPage(n2), true);
		 	 };

               		 fram2.GestureRecognizers.Add(tapGestureRecognizer2);
			 sls.Children.Add(fram2);
		}
		view.Content=sls;
                view.Opacity = 0;
                await view.FadeTo(1, 1000, Easing.SpringIn);
            }

        }

    }
}
