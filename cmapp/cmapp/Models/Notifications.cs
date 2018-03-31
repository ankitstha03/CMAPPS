using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cmapp.Models
{
    public class Notifications
    {
        public string title { get; set; }
        public string description { get; set; }
        public string desc { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string location { get; set; }
        public string title_image { get; set; }
        public DateTime temp { get; set; }
    }
}
