using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Firebase.Iid;
using Plugin.HtmlLabel.Android;

namespace cmapp.Droid
{
    [Activity(Label = "Shankar Pokhrel", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            HtmlLabelRenderer.Initialize();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            if (!GetString(Resource.String.google_app_id).Equals("1:958413425957:android:8056ae34f2d8a115"))
                throw new System.Exception("Invalid Json File");

            Task.Run(() =>
            {
                var instantId = FirebaseInstanceId.Instance;
                instantId.DeleteInstanceId();
                Android.Util.Log.Debug("TAG", "{0} {1}", instantId.Token, instantId.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));
            });
        }
    }
}

