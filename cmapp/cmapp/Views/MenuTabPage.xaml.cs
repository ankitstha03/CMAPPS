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

            var page1 = new MasterPageItem() { Title = "1111", Icon = "ic_apps_black_24dp.png", id=0 };
            var page2 = new MasterPageItem() { Title = "2222", Icon = "ic_apps_black_24dp.png", id=1 };
            var page3 = new MasterPageItem() { Title = "3333", Icon = "ic_apps_black_24dp.png", id=2 };
            var page4 = new MasterPageItem() { Title = "4444 ", Icon = "ic_apps_black_24dp.png", id=3 };

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage(new MainTabPage(0));

            this.BindingContext = Constants.currentuser;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Detail = new NavigationPage(new MainTabPage(item.id));

        }

    }
}