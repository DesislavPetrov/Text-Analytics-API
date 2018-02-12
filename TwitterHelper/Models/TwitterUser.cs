using System.Runtime.Serialization;

namespace TwitterHelper.Models
{
    [DataContract]
    public class TwitterUser
    {
        [DataMember(Name = "location")]
        public string Location;

        [DataMember(Name = "time_zone")]
        public string TimeZone;

        [DataMember(Name = "verified")]
        public bool Verified;

        [DataMember(Name = "name")]
        public string Name;
        
        [DataMember(Name = "screen_name")]
        public string ScreenName;
    }
}
