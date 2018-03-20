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
                    Title = "Shankar Pokhrel";
                    this.Children.Add(new HomeView() { Title = "Home" });
                    this.Children.Add(new NepaliNewsView() { Title = "Local News" });
                    this.Children.Add(new NewsView("http://en.pradesh-5.com/api-auth/press-news/") { Title = "Press News" });
                    this.Children.Add(new EventSchedule() { Title = "Schedule" });
                    this.Children.Add(new MessageView() { Title = "Suggestions" });
                    this.Children.Add(new TalkPage() { Title = "Article Prosperity Talks" });
                    this.Children.Add(new VideoView() { Title = "Video Prosperity Talks" });

                }
                else
                {
                    Title = "शंकर पोख्रेल";
                    this.Children.Add(new HomeView() { Title = "प्रमुख" });
                    this.Children.Add(new NepaliNewsView() { Title = "स्थानिय समाचार" });
                    this.Children.Add(new NewsView("http://pradesh-5.com/api-auth/press-news/") { Title = "संचार समाचार" });
                    this.Children.Add(new EventSchedule() { Title = "तालिका" });
                    this.Children.Add(new MessageView() { Title = "सुझाव" });
                    this.Children.Add(new TalkPage() { Title = "लिखित समृद्धि संबाद" });
                    this.Children.Add(new VideoView() { Title = "भिडियो समृद्धि संबाद" });

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
