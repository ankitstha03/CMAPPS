using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cmapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabPage : TabbedPage
    {
        private bool _canClose = true;
        public MainTabPage (int id)
        {
            InitializeComponent();
            if (Constants.English)
            {
                this.Children.Add(new NewsView() { Title="Home"});
                this.Children.Add(new NewsTabPage() { Title = "News" });
                this.Children.Add(new EventSchedule() { Title = "Schedule" });
                this.Children.Add(new MessageView() { Title = "Message" });
                this.Children.Add(new BioPage() { Title = "Biography" });
            }
            else
            {
                this.Children.Add(new NepaliNewsView() { Title= "प्रमुख" });
                this.Children.Add(new NewsTabPage() { Title = "समाचार" });
                this.Children.Add(new EventSchedule() { Title = "तलिका" });
                this.Children.Add(new MessageView() { Title = "सन्देश" });
                this.Children.Add(new BioPage() { Title = "जिवनी" });
            }
            

            CurrentPage = Children[id];
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