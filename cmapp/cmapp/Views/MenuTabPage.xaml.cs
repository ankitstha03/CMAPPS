﻿using cmapp.Models;
using cmapp.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuTabPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MenuTabPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Icon.Icon = "Noticonwhite";
            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() {  Icon = "ic_apps_black_24dp.png", id=0 };
            var page2 = new MasterPageItem() { Icon = "ic_apps_black_24dp.png", id=1 };
            var page3 = new MasterPageItem() {  Icon = "ic_apps_black_24dp.png", id=2 };
            var page4 = new MasterPageItem() {  Icon = "ic_apps_black_24dp.png", id=3 };

            if (Constants.English)
            {
                usname.Text = "Shankar Pokhrel";
                page1.Title = "Home";
                page2.Title = "News";
                page3.Title = "Schedule";
                page4.Title = "Message";
            }
            else
            {
                usname.Text = "शंकर पोख्रेल";
                page1.Title = "प्रमुख";
                page2.Title = "समाचार";
                page3.Title = "तलिका";
                page4.Title = "सन्देश";
            }

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {
                await Navigation.PushAsync(new KnowCmPage(),true);
            };

            stck1.GestureRecognizers.Add(tapGestureRecognizer);
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage(new MainTabPage(0));
            
            this.BindingContext = Constants.currentuser;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Detail = new NavigationPage(new MainTabPage(item.id));
            IsPresented = false;
        }

        private void Icon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotificationPage(), true);
        }
        private void Icon2_Clicked(object sender, EventArgs e)
        {
            Constants.English = !Constants.English;
            Application.Current.MainPage= new NavigationPage(new MenuTabPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            int count = 0;

            if (Constants.English)
            {
                Icon2.Text = "EN";
            }
            else
            {
                Icon2.Text = "NP";
            }
        }

    }
}

