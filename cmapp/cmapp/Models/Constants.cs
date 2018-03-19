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
        public static bool English = false;
        public static User currentuser;
        public static string ur= "http://pradesh-5.com";
        public static string ScrubHtml2(string value)
        {
            var step1 = Regex.Replace(value, @"\\", "").Trim();
            var step2 = Regex.Replace(step1, @"<iframe[^s]+src\=[^h]", "").Trim();
            var step3 = Regex.Replace(step2, @"[^a-z][^a-z]frameborder\=[^>]+><[^>]+>", "").Trim();
            return step3;
        }

public static string ScrubHtml(string value2)
        {
            var step1 = Regex.Replace(value2, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ").Trim();
            var step3 = Regex.Replace(step2, @"T\d+\:\d+\:\d+\+05\:45", "").Trim();
            var step4 = Regex.Replace(step3, @"T\d+\:\d+\:\d+Z", "").Trim();
            return step4;
        }
    }
}
