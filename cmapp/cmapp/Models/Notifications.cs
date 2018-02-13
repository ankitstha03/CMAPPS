using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cmapp.Models
{
    class Notifications
    {
        public string title { get; set; }
        public string description { get; set; }
        public string dates { get; set; }
        public string image { get; set; }
        public bool unread { get; set; }
        public Color color { get; set; }

        public Notifications(string title, string description, string dates, string image, bool unread)
        {
            this.title = title;
            this.description = description;
            this.dates = dates;
            this.image = image;
            this.unread = unread;
            if (this.unread)
            {
                this.color = Color.Gray;
            }
            else
            {
                this.color = Color.White;
            }
        }
    }
}
