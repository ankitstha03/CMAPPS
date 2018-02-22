using cmapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BioPage : ContentPage
	{
        private const string Url = "http://pradesh-5.com/api-auth/leader/";
        List<Leader> lead;
        public BioPage ()
		{
			InitializeComponent ();
            desig.SetBinding(Label.TextProperty, "designate.name");
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lead = await MoneyCache.GetAsync<List<Leader>>(Url);
            BindingContext = lead.First<Leader>();
        }
    }
}