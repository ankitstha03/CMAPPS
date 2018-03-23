using cmapp.Models;
using cmapp.Views;
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
    public partial class MenuTabPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MenuTabPage()
        {
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                InitializeComponent();
                try
                {
                    Icon.Icon = "Noticonwhite";
                    if (Constants.English)
                    {
                        Constants.ur = "http://en.pradesh-5.com";
                        Icon2.Text = "NP";
                    }
                    else
                    {
                        Constants.ur = "http://pradesh-5.com";
                        Icon2.Text = "EN";
                    }
                    menuList = new List<MasterPageItem>();

                    var page1 = new MasterPageItem() { Icon = "icons8home24.png", id = 0 };
                    var page2 = new MasterPageItem() { Icon = "icons8news24.png", id = 1 };
                    var page3 = new MasterPageItem() { Icon = "icons8calendar24.png", id = 2 };
                    var page4 = new MasterPageItem() { Icon = "icons8chat24.png", id = 3 };
                    var page5 = new MasterPageItem() { Icon = "icons8administratormale48.png", id = 4 };

                    if (Constants.English)
                    {
                        usname.Text = "Shankar Pokhrel";
                        page1.Title = "Home";
                        page2.Title = "News";
                        page3.Title = "Schedule";
                        page4.Title = "Message";
                        page5.Title = "Know CM";
                    }
                    else
                    {
                        usname.Text = "शंकर पोख्रेल";
                        page1.Title = "प्रमुख";
                        page2.Title = "समाचार";
                        page3.Title = "तालिका";
                        page4.Title = "सन्देश";
                        page5.Title = "चिन्नुहोस";
                    }

                    menuList.Add(page1);
                    menuList.Add(page2);
                    menuList.Add(page3);
                    menuList.Add(page4);
                    menuList.Add(page5);


                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        await Navigation.PushAsync(new KnowCmPage(), true);
                    };

                    stck1.GestureRecognizers.Add(tapGestureRecognizer);
                    // Setting our list to be ItemSource for ListView in MainPage.xaml
                    navigationDrawerList.ItemsSource = menuList;
                    // Initial navigation, this can be used for our home page
                    Detail = new MainTabPage(0);

                    this.BindingContext = Constants.currentuser;
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                    return;

                var item = (MasterPageItem)e.SelectedItem;
                if (item.id == 4)
                {
                    Navigation.PushAsync(new KnowCmPage());
                }
                else
                {
                    Detail =new MainTabPage(item.id);
                }
                IsPresented = false;
                navigationDrawerList.SelectedItem = null;
            }catch(Exception ex)
            {
                XFToast.ShortMessage(ex.Message);
            }
        }

        private void Icon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotificationPage(), true);
        }
        private void Icon2_Clicked(object sender, EventArgs e)
        {
            try
            {
                Constants.English = !Constants.English;
                Application.Current.MainPage = new NavigationPage(new MenuTabPage());
            }catch(Exception ex)
            {

            }
        }
    

    }
}

