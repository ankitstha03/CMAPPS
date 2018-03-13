using cmapp.Models;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactUs : ContentPage
	{
        private const string Url = "http://en.pradesh-5.com/api-auth/messages/";
        private HttpClient _client = new HttpClient();

        public ContactUs ()
		{
			InitializeComponent ();
            if (Constants.English)
            {
                Title = "Contact Us";
                connect.Text = "Connect with us";
                enUser.Placeholder = "Your Full Name";
                enEmail.Placeholder = "Your Email";
                enPhone.Placeholder = "Your Phone Number";
                enSub.Placeholder = "Subject";
                enDesc.Placeholder = "Body";
                btnmessage.Text = "Send Suggestion";
            }
            else
            {
                Title = "सन्देश पठाउनुहोस्";
                connect.Text = "हामीलाई सम्पर्क गर्नुहोस्";
                enUser.Placeholder = "हजुरको पुरा नाम";
                enEmail.Placeholder = "हजुरको इमेल";
                enPhone.Placeholder = "हजुरको फोन नम्बर";
                enSub.Placeholder = "विषय";
                enDesc.Placeholder = "विश्लेशन";
                btnmessage.Text = "सुझाव पठाउनुहोस्";
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                XFToast.ShortMessage("No Internet Connection");
            }
            else
            {
                try
                {
                    var msg = new Message { full_name = enUser.Text, email = enEmail.Text, contact_no = enPhone.Text, subject = enSub.Text, body = enDesc.Text, status = "Sent" };
                    var content = JsonConvert.SerializeObject(msg);
                    var response = await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));

                    if ((int)response.StatusCode >= 200 && (int)response.StatusCode <= 299)
                    {
                        XFToast.ShortMessage("Message Sent");
                        await Navigation.PopAsync(true);
                    }
                    else
                    {
                        XFToast.ShortMessage("Please fill all the fields");
                    }
                }catch(Exception ex)
                {
                    XFToast.ShortMessage("Internet cut-off while sending");
                }
            }
        }
    }
}
