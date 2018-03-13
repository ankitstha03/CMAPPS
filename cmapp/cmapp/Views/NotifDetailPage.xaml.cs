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
	public partial class NotifDetailPage : ContentPage
	{
		public NotifDetailPage (Notifications notific)
		{
			InitializeComponent ();
            BindingContext = notific;
            Title = new string(notific.title.Take(15).ToArray()) + "...";
        }
	}
}