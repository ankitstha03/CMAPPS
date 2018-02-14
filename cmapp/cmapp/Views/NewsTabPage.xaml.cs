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
                this.Children.Add(new NewsView() { Title = "Local" });
                this.Children.Add(new NewsView() { Title = "Media" });
            }
            else
            {
                this.Children.Add(new NepaliNewsView() { Title = "स्थानिय" });
                this.Children.Add(new NepaliNewsView() { Title = "मिडिया" });
            }
            
        }
    }
}