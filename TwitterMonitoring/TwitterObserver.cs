using System;
using TwitterHelper.Models;

namespace TwitterMonitoring
{
    public class TwitterObserver : IObserver<Tweet>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Done");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(String.Format("Error: ", error.ToString()));
        }

        public void OnNext(Tweet value)
        {
            throw new NotImplementedException();
        }
    }
}
