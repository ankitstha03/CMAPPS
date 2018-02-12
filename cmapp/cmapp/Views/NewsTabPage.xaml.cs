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
    public partial class NewsTabPage : TabbedPage
    {
        public NewsTabPage ()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Gray;
            this.Children.Add(new NewsView());
            this.Children.Add(new NewsView());
        }
    }
}