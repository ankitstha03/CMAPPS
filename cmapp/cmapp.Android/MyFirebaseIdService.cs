using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cmapp.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using System.Net.Http;
using Newtonsoft.Json;

namespace cmapp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class MyFirebaseIdService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        private string myUrl = Constants.ur + "/api-auth/reg_id/" + FirebaseInstanceId.Instance.Token;
        public override void OnTokenRefresh()
        {

            base.OnTokenRefresh();

            String refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug(TAG, "Refreshed token: " + refreshedToken); ;
            SendRegistrationToServerAsync(refreshedToken);
        }
        async System.Threading.Tasks.Task SendRegistrationToServerAsync(string token)
        {
            HttpClient oHttpClient = new HttpClient();
            string sContentType = "application/json";
            var json = JsonConvert.SerializeObject(token);
            HttpResponseMessage request = await oHttpClient.PostAsync(myUrl, new StringContent(json, Encoding.UTF8, sContentType));
        }
    }
}