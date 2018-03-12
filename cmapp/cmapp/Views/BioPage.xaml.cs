﻿using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonkeyCache.FileStore;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BioPage : ContentPage
	{
        private const string Url = "http://en.pradesh-5.com/api-auth/leader/";
        List<Leader> lead;
        public BioPage ()
		{
			InitializeComponent ();
            view.Opacity = 0;
            if(string.IsNullOrWhiteSpace(Barrel.Current.Get(Url)) && !CrossConnectivity.Current.IsConnected)
            {
                XFToast.ShortMessage("No Previous data or Internet");
            }
            else
                DataGet();

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected)
                {
                    DataGet();
                }
            };
        }

        private async void DataGet()
        {
            try
            {
                lead = await MoneyCache.GetAsync<List<Leader>>(Url);
                BindingContext = lead.First<Leader>();
                desig.SetBinding(Label.TextProperty, "designate.name");
                await view.FadeTo(1, 1000, Easing.SpringIn);
            }
            catch
            {
            }
        }

    }
}