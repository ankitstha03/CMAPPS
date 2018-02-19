using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cmapp.Models
{
    class MoneyCache
    {
        public static async Task<T> GetAsync<T>(string url, int days = 100, bool forceRefresh = false)
        {
            var json = string.Empty;
            HttpClient client = new HttpClient();

            //check if we are connected, else check to see if we have valid data
            if (CrossConnectivity.Current.IsConnected)
            {
                json = await client.GetStringAsync(url);
                Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
            }
            else if (!forceRefresh && !Barrel.Current.IsExpired(url))
                json = Barrel.Current.Get(url);

            try
            {
                //skip web request because we are using cached data
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await client.GetStringAsync(url);
                    Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
                }
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to get information from server {ex}");
                //probably re-throw here :)
            }

            return default(T);
        }
    }
}
