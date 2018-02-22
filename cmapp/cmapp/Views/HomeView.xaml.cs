﻿using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
   
            DataGet();
            //view.Margin = new Thickness(-200, 0, 200, 0);
            //view.TranslateTo(200, 0, 1000, Easing.SpringIn);
            
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView1.ItemsSource = NewsCollection1.Where(c => c.title.StartsWith(e.NewTextValue));
                listView2.ItemsSource = NewsCollection2.Where(c => c.title.StartsWith(e.NewTextValue));
            }
            else
            {
                NewsCollection1 = new ObservableCollection<News>(newlist1);
                NewsCollection2 = new ObservableCollection<NepNews>(newlist2);

                listView1.ItemsSource = NewsCollection1.Reverse<News>();
                listView2.ItemsSource = NewsCollection2.Reverse<NepNews>();

            }
        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as News;
            await Navigation.PushAsync(new NewsDetailPage(dataCard), true);
            listView1.SelectedItem = null;
        }

        private async void listView_ItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as NepNews;
            await Navigation.PushAsync(new NepaliNewsDetailPage(dataCard), true);
            listView2.SelectedItem = null;
        }

        private async void Onrefresh(object sender, EventArgs e)
        {
            newlist1 = await MoneyCache.GetAsync<List<News>>(Url1);
            newlist2 = await MoneyCache.GetAsync<List<NepNews>>(Url2);
            newlist1 = newlist1.Take(1).ToList();
            newlist2 = newlist2.Take(1).ToList();

            NewsCollection1 = new ObservableCollection<News>(newlist1);
            NewsCollection2 = new ObservableCollection<NepNews>(newlist2);

            listView1.ItemsSource = NewsCollection1.Reverse<News>();
            listView2.ItemsSource = NewsCollection2.Reverse<NepNews>();

            listView1.EndRefresh();

        }

        private async void DataGet()
        {
            newlist1 = await MoneyCache.GetAsync<List<News>>(Url1);
            newlist2 = await MoneyCache.GetAsync<List<NepNews>>(Url2);
            newlist1 = newlist1.Take(1).ToList();
            newlist2 = newlist2.Take(1).ToList();

            NewsCollection1 = new ObservableCollection<News>(newlist1);
            NewsCollection2 = new ObservableCollection<NepNews>(newlist2);

            listView1.ItemsSource = NewsCollection1.Reverse<News>();
            listView2.ItemsSource = NewsCollection2.Reverse<NepNews>();
            view.Opacity = 0;
            await view.FadeTo(1, 1000, Easing.SpringIn);
        }

    }
}