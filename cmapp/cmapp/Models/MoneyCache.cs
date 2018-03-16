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
            try
            {
                //check if we are connected, else check to see if we have valid data
                if (CrossConnectivity.Current.IsConnected)
            {
                json = await client.GetStringAsync(url);
                    if (string.IsNullOrWhiteSpace(json)){
                        json = Barrel.Current.Get(url);
                    }
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        json = Constants.ScrubHtml(json);
                        Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
                    }

                    
            }
            else if (!forceRefresh && !Barrel.Current.IsExpired(url))
                json = Barrel.Current.Get(url);

                
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }
            catch (Exception ex)
            {
                XFToast.ShortMessage("Couldn't retrieve data");
                json = Barrel.Current.Get(url);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
                }
                else
                {
                    return default(T);
                }
            }

        }
        public static async Task<T> GetAsync2<T>(string url, int days = 100, bool forceRefresh = false)
        {
            var json = string.Empty;
            HttpClient client = new HttpClient();
            try
            {
                //check if we are connected, else check to see if we have valid data
                if (CrossConnectivity.Current.IsConnected)
                {
                    json = await client.GetStringAsync(url);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        json = Barrel.Current.Get(url);
                    }
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                     
                        Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
                    }


                }
                else if (!forceRefresh && !Barrel.Current.IsExpired(url))
                    json = Barrel.Current.Get(url);


                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }
            catch (Exception ex)
            {
                XFToast.ShortMessage("Couldn't retrieve data");
                json = Barrel.Current.Get(url);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
                }
                else
                {
                    return default(T);
                }
            }

        }
    }
}
