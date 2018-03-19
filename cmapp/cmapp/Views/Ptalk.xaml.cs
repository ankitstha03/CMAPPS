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
    public partial class Ptalk : TabbedPage
    {
        public Ptalk ()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Red;
            if (Constants.English)
            {
                this.Children.Add(new TalkPage() { Title = "My Say" });
                this.Children.Add(new VideoView() { Title = "Video" });
                Title = "Prosperity Talks";
            }
            else
            {
                this.Children.Add(new TalkPage() { Title = "मेरो भनाइ" });
                this.Children.Add(new VideoView() { Title = "भिडियो " });
                Title = "समृद्धि";
            }
        }
    }
}