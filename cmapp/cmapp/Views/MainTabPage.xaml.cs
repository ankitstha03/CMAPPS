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
                Title = "Shankar Pokhrel";
                this.Children.Add(new HomeView() { Title="Home"});
                this.Children.Add(new NewsTabPage() { Title = "News" });
                this.Children.Add(new EventSchedule() { Title = "Schedule" });
                this.Children.Add(new MessageView() { Title = "Suggestions" });

            }
            else
            {
                Title = "शंकर पोख्रेल";
                this.Children.Add(new HomeView() { Title= "प्रमुख" });
                this.Children.Add(new NewsTabPage() { Title = "समाचार" });
                this.Children.Add(new EventSchedule() { Title = "तलिका" });
                this.Children.Add(new MessageView() { Title = "सुझाव" });
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
            XFToast.LongMessage("Press back again to exit");
            await Task.Delay(1000);
            _canClose = false;
        }
    }
}
