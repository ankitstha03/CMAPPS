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
        public static string ur= "http://en.pradesh-5.com";
        public static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ").Trim();
            var step3 = Regex.Replace(step2, @"T\d+\:\d+\:\d+\+05\:45", "").Trim();
            var step4 = Regex.Replace(step3, @"T\d+\:\d+\:\d+Z", "");
            return step4;
        }
    }
}
