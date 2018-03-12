using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cmapp.Models
{
    class Constants
    {
        public static bool English = true;
        public static User currentuser;

        public static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            var step3 = Regex.Replace(step1, @"T\d+\:\d+\:\d+\+05\:45", "");

            return step3;
        }
    }
}
