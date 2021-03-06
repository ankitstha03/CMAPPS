﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cmapp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using MonkeyCache.FileStore;

namespace cmapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TalkPage : ContentPage
    {
        ObservableCollection<Notifications> NotiCollection;
        private string Url = Constants.ur + "/api-auth/mero-mat/";
        List<Notifications> notlist;
        App app = Application.Current as App;
        public TalkPage()
        {
            InitializeComponent();
            
            DataGet();

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected)
                {
                    DataGet();
                }
            };
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NotiCollection.Where(c => c.title.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            else
            {
                NotiCollection = new ObservableCollection<Notifications>(notlist);
                listView.ItemsSource = NotiCollection;
            }
        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Notifications;
            await Navigation.PushAsync(new NotifDetailPage(dataCard), true);

            listView.SelectedItem = null;
        }


        private async void DataGet()
        {
            if (string.IsNullOrWhiteSpace(Barrel.Current.Get(Url)) && !CrossConnectivity.Current.IsConnected)
            {
                XFToast.ShortMessage("No Previous data or Internet");
            }
            else
            {
                try
                {
                    notlist = await MoneyCache.GetAsync<List<Notifications>>(Url);
                    foreach (Notifications n in notlist)
                    {
                        n.desc = Constants.ScrubHtml(n.description);
                        n.desc = new String(n.desc.Take(200).ToArray()) + "...";
                    }
                    NotiCollection = new ObservableCollection<Notifications>(notlist);
                    listView.ItemsSource = NotiCollection;
                    listView.Opacity = 0;
                    await listView.FadeTo(1, 1000, Easing.SpringIn);
                }
                catch (Exception e)
                {
                }

            }

            listView.EndRefresh();
        }
    }
}