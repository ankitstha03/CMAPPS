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
    public partial class NewsTabPage : TabbedPage
    {
        public NewsTabPage ()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Red;
            if (Constants.English)
            {
                this.Children.Add(new NepaliNewsView() { Title = "Local" });
                this.Children.Add(new NewsView("http://pradesh-5.com/api-auth/press-news/") { Title = "Media" });
            }
            else
            {
                this.Children.Add(new NepaliNewsView() { Title = "स्थानिय" });
                this.Children.Add(new NewsView("http://en.pradesh-5.com/api-auth/press-news/") { Title = "मिडिया" });
            }
            
        }
    }
}