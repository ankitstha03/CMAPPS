using System;
using System.Collections.Generic;
using System.Text;

namespace cmapp.Models
{
    class News
    {
        public Sources source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
    }
}
