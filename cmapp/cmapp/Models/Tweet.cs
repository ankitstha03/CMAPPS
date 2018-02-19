﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cmapp.Models
{
    public class Tweet
    {
        public ulong StatusID { get; set; }

        public string ScreenName { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string MediaUrl { get; set; }
    }
}
