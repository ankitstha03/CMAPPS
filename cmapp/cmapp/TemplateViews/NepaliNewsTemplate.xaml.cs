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
	public partial class NepaliNewsTemplate : ContentView
	{
		public NepaliNewsTemplate ()
		{
			InitializeComponent ();
            Newsimage.SetBinding(Image.SourceProperty, "image_url");
            Newssource.SetBinding(Label.TextProperty, "category_name");
        }
	}
}