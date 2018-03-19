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
    public partial class Ptalk : TabbedPage
    {
        public Ptalk ()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Red;
            if (Constants.English)
            {
                this.Children.Add(new TalkPage() { Title = "Article" });
                this.Children.Add(new VideoView() { Title = "Video" });
            }
            else
            {
                this.Children.Add(new TalkPage() { Title = "लिखित" });
                this.Children.Add(new VideoView() { Title = "भिडियो " });
            }
        }
    }
}