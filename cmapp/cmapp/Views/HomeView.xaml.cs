﻿using cmapp.Models;
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


            try
            {
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

            }catch(Exception ex)
            {

            }
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
                    sls.Children.Clear();
                    newlist1 = await MoneyCache.GetAsync<List<News>>(Url1);
                    newlist2 = await MoneyCache.GetAsync<List<NepNews>>(Url2);
                    activi.IsRunning = false;
                    activi.IsVisible = false;
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



                        var imag = new Image
                        {
                            Source = n.images,
                            Aspect = Aspect.AspectFill,
                            HorizontalOptions=LayoutOptions.FillAndExpand,
                            VerticalOptions=LayoutOptions.Start
                        };
                    
                       

                        slsins.Children.Add(imag);

                        var slslb = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10, 5, 10, 5)
                        };

                        Label title = new Label
                        {
                            Text = n.title,
                            FontSize = 18,
                            FontAttributes=FontAttributes.Bold,
                            TextColor = Color.Black
                        };

                        Label desc = new Label
                        {
                            Text = n.description,
                            FontSize = 18,
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


                        var imag = new Image
                        {
                            Source = n2.title_image,
                            Aspect = Aspect.AspectFill,
                            HorizontalOptions=LayoutOptions.FillAndExpand,
                            VerticalOptions=LayoutOptions.Start
                        };

                        slsins.Children.Add(imag);

                        var slslb = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Padding = new Thickness(10, 5, 10, 5)
                        };

                        Label title = new Label
                        {
                            Text = n2.title,
                            FontSize = 18,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Color.Black
                        };
                        n2.desc = Constants.ScrubHtml(n2.description);

                        Label desc = new Label
                        {
                            Text = new String(n2.desc.Take(200).ToArray())+"...",
                            FontSize = 18,
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
