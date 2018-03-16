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
    public partial class KnowCmPage : TabbedPage
    {
        public KnowCmPage ()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Red;
            if (Constants.English)
            {
               
                this.Children.Add(new Tweetpage() { Title = "Twitter" });
                this.Children.Add(new VideoView() { Title = "My Say" });
                this.Children.Add(new BioPage() { Title = "Biography" });
                Title= "Know CM";
            }
            else
            {
                
                this.Children.Add(new Tweetpage() { Title = "ट्वितर" });
                this.Children.Add(new VideoView() { Title = "मेरो भनाइ" });
                this.Children.Add(new BioPage() { Title = "जीवनी" });
                Title = "चिन्नुहोस";
            }
        }

    }
}