using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cmapp.Models
{
    class NotificationView
    {
        public string title { get; set; }
        public string description { get; set; }
        public string dates { get; set; }
        public string image { get; set; }
        public bool unread { get; set; }
        public Color color { get; set; }
    }
}
