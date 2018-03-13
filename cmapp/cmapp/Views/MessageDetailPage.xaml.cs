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
	public partial class MessageDetailPage : ContentPage
	{
		public MessageDetailPage (Message msg)
		{
			InitializeComponent ();
            BindingContext = msg;
            Title = new string(msg.subject.Take(15).ToArray()) + "...";

        }
    }
}