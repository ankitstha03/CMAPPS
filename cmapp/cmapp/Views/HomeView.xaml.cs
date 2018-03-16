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

        private string Url1 = Constants.ur + "/api-auth/press-news/";
        private string Url2 = Constants.ur + "/api-auth/news/";
        List<News> newlist1;
        List<NepNews> newlist2;
        App app = Application.Current as App;
        StackLayout sls = new StackLayout
        {
            Spacing = 10,
            Padding = new Thickness(3, 3, 3, 3),
            Orientation = StackOrientation.Vertical

        };

        public HomeView ()
		{
			InitializeComponent ();
		

            
                DataGet();

	CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected)
                {
                    DataGet();
                }
            };
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
                try
                {
                    newlist1 = await MoneyCache.GetAsync<List<News>>(Url1);
                    newlist2 = await MoneyCache.GetAsync<List<NepNews>>(Url2);
                    newlist1 = newlist1.Reverse<News>().ToList<News>();
                    newlist2 = newlist2.Reverse<NepNews>().ToList<NepNews>();
                    newlist1 = newlist1.Take(3).ToList();
                    newlist2 = newlist2.Take(3).ToList();
  		    foreach(NepNews n in newlist2){
		    	n.desc=n.description.Take(30)+"...";
		    }
                    NewsCollection1 = new ObservableCollection<News>(newlist1);
                    NewsCollection2 = new ObservableCollection<NepNews>(newlist2);


                    foreach (News n in newlist1)
                    {
                        Frame fram = new Frame
                        {
                            IsClippedToBounds = true,
                            CornerRadius = 12,
                            HasShadow = true,
                            BackgroundColor = Color.White,
                            OutlineColor = Color.Gray,
                            Margin = new Thickness(7),
                            Padding = new Thickness(5)
                        };

                        var slsins = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical
                        };

                        var abs = new AbsoluteLayout
                        {
                        };

                        var imag = new Image
                        {
                            Source = n.images,
                            Aspect = Aspect.AspectFill
                        };
                        AbsoluteLayout.SetLayoutBounds(imag, new Rectangle(0, 0, 1, 220));
                        AbsoluteLayout.SetLayoutFlags(imag, AbsoluteLayoutFlags.XProportional);
                        AbsoluteLayout.SetLayoutFlags(imag, AbsoluteLayoutFlags.WidthProportional);
                        Frame framer = new Frame
                        {
                            IsClippedToBounds = true,
                            CornerRadius = 5,
                            HasShadow = true,
                            BackgroundColor = Color.White,
                            OutlineColor = Color.Transparent,
                            Padding = new Thickness(3, 3, 3, 3),
                            Opacity = 0.7
                        };
                        AbsoluteLayout.SetLayoutBounds(framer, new Rectangle(1.05, 10, 0.35, 21));
                        AbsoluteLayout.SetLayoutFlags(framer, AbsoluteLayoutFlags.XProportional);
                        AbsoluteLayout.SetLayoutFlags(framer, AbsoluteLayoutFlags.WidthProportional);
                        Label lbl = new Label
                        {
                            Text = "Press news",
                            TextColor = Color.Black,
                            FontSize = 14
                        };
                        framer.Content = lbl;

                        abs.Children.Add(imag);
                        abs.Children.Add(framer);

                        slsins.Children.Add(abs);

                        var slslb = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10, 5, 10, 5)
                        };

                        Label title = new Label
                        {
                            Text = n.title,
                            FontSize = 16,
                            TextColor = Color.Black
                        };

                        Label desc = new Label
                        {
                            Text = n.description,
                            FontSize = 16,
                            TextColor = Color.Black
                        };

                        slslb.Children.Add(title);
                        slslb.Children.Add(desc);

                        slsins.Children.Add(slslb);

                        fram.Content = slsins;

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += async (s, e) =>
                        {
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

                    foreach (NepNews n2 in newlist2)
                    {
                        Frame fram2 = new Frame
                        {
                            IsClippedToBounds = true,
                            CornerRadius = 12,
                            HasShadow = true,
                            BackgroundColor = Color.White,
                            OutlineColor = Color.Gray,
                            Margin = new Thickness(7),
                            Padding = new Thickness(5)
                        };
                        var slsins = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical
                        };

                        var abs = new AbsoluteLayout
                        {
                        };

                        var imag = new Image
                        {
                            Source = n2.title_image,
                            Aspect = Aspect.AspectFill
                        };
                        AbsoluteLayout.SetLayoutBounds(imag, new Rectangle(0, 0, 1, 220));
                        AbsoluteLayout.SetLayoutFlags(imag, AbsoluteLayoutFlags.XProportional);
                        AbsoluteLayout.SetLayoutFlags(imag, AbsoluteLayoutFlags.WidthProportional);
                        Frame framer = new Frame
                        {
                            IsClippedToBounds = true,
                            CornerRadius = 5,
                            HasShadow = true,
                            BackgroundColor = Color.White,
                            OutlineColor = Color.Transparent,
                            Padding = new Thickness(3, 3, 3, 3),
                            Opacity = 0.7
                        };
                        AbsoluteLayout.SetLayoutBounds(framer, new Rectangle(1.05, 10, 0.35, 21));
                        AbsoluteLayout.SetLayoutFlags(framer, AbsoluteLayoutFlags.XProportional);
                        AbsoluteLayout.SetLayoutFlags(framer, AbsoluteLayoutFlags.WidthProportional);
                        Label lbl = new Label
                        {
                            Text = "Local news",
                            TextColor = Color.Black,
                            FontSize = 14
                        };
                        framer.Content = lbl;

                        abs.Children.Add(imag);
                        abs.Children.Add(framer);

                        slsins.Children.Add(abs);

                        var slslb = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10, 5, 10, 5)
                        };

                        Label title = new Label
                        {
                            Text = n2.title,
                            FontSize = 16,
                            TextColor = Color.Black
                        };

                        Label desc = new Label
                        {
                            Text = new String(n2.description.Take(200).ToArray())+"...",
                            FontSize = 16,
                            TextColor = Color.Black
                        };

                        slslb.Children.Add(title);
                        slslb.Children.Add(desc);

                        slsins.Children.Add(slslb);

                        fram2.Content = slsins;

                        var tapGestureRecognizer2 = new TapGestureRecognizer();
                        tapGestureRecognizer2.Tapped += async (s, e) =>
                        {
                            await Navigation.PushAsync(new NepaliNewsDetailPage(n2), true);
                        };

                        fram2.GestureRecognizers.Add(tapGestureRecognizer2);
                        sls.Children.Add(fram2);
                    }
                    view.Content = sls;
                    view.Opacity = 0;
                    await view.FadeTo(1, 1000, Easing.SpringIn);
                }catch(Exception ex)
                {

                }
            }

        }

    }
}
