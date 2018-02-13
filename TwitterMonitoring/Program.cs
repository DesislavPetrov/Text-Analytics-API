using System.Reactive.Linq;
using TwitterHelper;

namespace TwitterMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitterObserver = new TwitterObserver();
            var twitterConfig = new TwitterConfig(Constants.TwitterConsumerKey, Constants.TwitterConsumerSecret, Constants.TwitterAccessToken, Constants.TwitterTokenSecret);
            Services.StreamStatuses(twitterConfig, "Microsoft").ToObservable().Subscribe(twitterObserver);

        }
    }
}