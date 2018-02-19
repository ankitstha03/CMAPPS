using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LinqToTwitter;
using Xamarin.Forms;

namespace cmapp.Models
{
    public class TweetingViewModel : INotifyPropertyChanged
    {
        private List<Tweet> _tweets;
        public List<Tweet> Tweets
        {
            get { return _tweets; }
            set
            {
                if (_tweets == value) return;

                _tweets = value;
                OnPropertyChanged();
            }
        }

        public TweetingViewModel()
        {
            InitTweetViewModel();
        }

        public async Task InitTweetViewModel()
        {
            var auth = new ApplicationOnlyAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "31Gc1vHVfgb2Js2vhkJ9xBvnC",
                    ConsumerSecret = "c9Dj5KJkejj7guyIf6Ce2cY8Ogd164KboQF7mGFuDUNjVjLZB3",

                },
            };




            await auth.AuthorizeAsync();

            var ctx = new TwitterContext(auth);

            var tweets = await
                 (from tweet
                  in ctx.Status
                  where tweet.Type == StatusType.User
                         && tweet.ScreenName == "shankarpokhrel8"
                         && tweet.Count == 1000
                  select tweet
                 )
                 .ToListAsync();

            Tweets =
                (from tweet in tweets
                 select new Tweet
                 {
                     StatusID = tweet.StatusID,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text,
                     ImageUrl = tweet.User.ProfileImageUrl,
                     MediaUrl = tweet?.Entities?.MediaEntities?.FirstOrDefault()?.MediaUrl
                 })
                .ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException("Can't call OnPropertyChanged with a null property name.", propertyName);

            PropertyChangedEventHandler propChangedHandler = PropertyChanged;
            if (propChangedHandler != null)
                propChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
