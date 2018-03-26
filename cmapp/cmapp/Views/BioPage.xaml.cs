using cmapp.Models;
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
        private string Url =Constants.ur+ "/api-auth/leader/";
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
                Leader asd = lead.First<Leader>();
                asd.description = Constants.ScrubHtml(asd.description);
                BindingContext = asd;
                desig.SetBinding(Label.TextProperty, "designate.name");
                await view.FadeTo(1, 1000, Easing.SpringIn);
            }
            catch
            {
            }
        }

    }
}
