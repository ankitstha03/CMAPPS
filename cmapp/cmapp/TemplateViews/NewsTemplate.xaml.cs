using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.TemplateViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsTemplate : ContentView
	{
		public NewsTemplate ()
		{
			InitializeComponent ();
            Newsimage.SetBinding(Image.SourceProperty, "images");
            //Newssource.SetBinding(Label.TextProperty, "source.name");
        }
	}
}