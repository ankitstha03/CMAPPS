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
    public partial class MainTabPage : TabbedPage
    {
        private bool _canClose = true;
        public MainTabPage ()
        {
            InitializeComponent();
            this.Children.Add(new NewsView());
            this.Children.Add(new NewsTabPage());
            this.Children.Add(new NewsView());
            this.Children.Add(new NewsView());

        }

        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            await DisplayAlert("Exit", "Press back again to exit", "Ok");
            _canClose = false;
            this.OnBackButtonPressed();
        }
    }
}