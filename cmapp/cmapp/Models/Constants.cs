using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace cmapp.Models
{
    class Constants
    {
        public static bool IsDev = true;
        public static User currentuser;
        public static List<Notifications> _notification = new List<Notifications>()
        {
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", true),
            new Notifications("The title of notication is here", "the description of notification is here", "12th Jan 2017", "http://markinternational.info/data/out/332/221663298-wallpaper-photos.jpg", false),
        };
    }
}
