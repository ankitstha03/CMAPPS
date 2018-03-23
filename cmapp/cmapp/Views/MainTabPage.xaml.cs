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
            try
            {
                if (Constants.English)
                {
                    this.Children.Add(new NavigationPage(new HomeView() { Title = "Home" }) { Title = "Home" });
                    this.Children.Add(new NavigationPage(new NewsTabPage() { Title = "News" }) { Title = "News" });
                    this.Children.Add(new NavigationPage(new EventSchedule() { Title = "Schedule" }) { Title = "Schedule" });
                    this.Children.Add(new NavigationPage(new MessageView() { Title = "Suggestions" }) { Title = "Suggestions" });
                    this.Children.Add(new NavigationPage(new Ptalk() { Title = "Prosperity Talks" }) { Title = "Prosperity Talks" });

                }
                else
                {
                    this.Children.Add(new NavigationPage(new HomeView() { Title = "प्रमुख" }) { Title = "प्रमुख" });
                    this.Children.Add(new NavigationPage(new NewsTabPage() { Title = "समाचार" }) { Title = "समाचार" });
                    this.Children.Add(new NavigationPage(new EventSchedule() { Title = "तालिका" }) { Title = "तालिका" });
                    this.Children.Add(new NavigationPage(new MessageView() { Title = "सुझाव" }) { Title = "सुझाव" });
                    this.Children.Add(new NavigationPage(new Ptalk() { Title = "समृद्धि संबाद" }) { Title = "समृद्धि संबाद" });

                }


                CurrentPage = Children[id];
            }
            catch(Exception ex)
            {
            }
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
