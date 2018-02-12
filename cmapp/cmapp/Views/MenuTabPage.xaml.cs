using cmapp.Models;
using cmapp.Views;
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
    public partial class MenuTabPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MenuTabPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() { Title = "Home", Icon = "ic_apps_black_24dp.png", id=0 };
            var page2 = new MasterPageItem() { Title = "News", Icon = "ic_apps_black_24dp.png", id=1 };
            var page3 = new MasterPageItem() { Title = "Schedule", Icon = "ic_apps_black_24dp.png", id=2 };
            var page4 = new MasterPageItem() { Title = "Biography", Icon = "ic_apps_black_24dp.png", id=3 };
            var page5 = new MasterPageItem() { Title = "Logout ", Icon = "ic_apps_black_24dp.png", id = 4 };


            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage(new MainTabPage(0));
            usname.Text = Constants.currentuser.first_name + " " + Constants.currentuser.last_name;
            this.BindingContext = Constants.currentuser;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            if (item.id <= 3)
            {
                Detail = new NavigationPage(new MainTabPage(item.id));
            }
            else
                Application.Current.MainPage = new NavigationPage(new LoginPage());

            IsPresented = false;
        }

    }
}