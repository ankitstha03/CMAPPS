using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using cmapp.Views;
using MonkeyCache.FileStore;
using Plugin.Connectivity;

namespace cmapp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            Barrel.ApplicationId = "cmapp";
			MainPage = new NavigationPage(new SplashPage());
		}

        protected override void OnStart()
        {

        }


        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
