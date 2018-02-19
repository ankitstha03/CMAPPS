using cmapp.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cmapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessageView : ContentPage
	{
        ObservableCollection<Message> NewsCollection;
        private const string Url = "http://pradesh-5.com/api-auth/messages/";
        List<Message> messagelist;
        App app = Application.Current as App;
        public MessageView ()
		{
			InitializeComponent ();
            send.Text = "Send Message";
		}

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var dataCard = e.SelectedItem as Message;

            await Navigation.PushAsync(new MessageDetailPage(dataCard), true);
            listView.SelectedItem = null;
        }

        private void Onchange(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = NewsCollection.Where(c => c.subject.StartsWith(e.NewTextValue));
            }
            else
            {
                NewsCollection = new ObservableCollection<Message>(messagelist);
                listView.ItemsSource = NewsCollection.Reverse<Message>();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactUs(),true);
        }
        private async void Onrefresh(object sender, EventArgs e)
        {
            messagelist = await MoneyCache.GetAsync<List<Message>>(Url);
            NewsCollection = new ObservableCollection<Message>(messagelist);
            listView.ItemsSource = NewsCollection.Reverse<Message>();
            listView.EndRefresh();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
             
            messagelist = await MoneyCache.GetAsync<List<Message>>(Url);
            NewsCollection = new ObservableCollection<Message>(messagelist);
            listView.ItemsSource = NewsCollection.Reverse<Message>();
            view.Margin = new Thickness(-200, 0, 200, 0);
            view.TranslateTo(200, 0, 1000, Easing.SpringIn);
            listView.Opacity = 0;
            listView.FadeTo(1, 1000, Easing.SpringIn);
        }
    }
}