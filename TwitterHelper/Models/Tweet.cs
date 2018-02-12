using System;
using System.Runtime.Serialization;

namespace TwitterHelper.Models
{
    [DataContract]
    public class Tweet
    {
        // UTC time when this Tweet was created. 
        [DataMember(Name = "created_at")]
        public string CreatedAt;

        // Nullable. Indicates approximately how many times this Tweet has been liked by Twitter users. 
        [DataMember(Name = "favorite_count")]
        public Int64? FavoriteCount;

        [DataMember(Name = "id")]
        public Int64 Id;

        [DataMember(Name = "in_reply_to_screen_name")]
        public string ReplyToScreenName;

        // Nullable. If the represented Tweet is a reply, this field will contain the string representation of the original Tweet’s ID. 
        [DataMember(Name = "in_reply_to_status_id")]
        public Int64? ReplyToStatusId;

        // Nullable. If the represented Tweet is a reply, this field will contain the integer representation of the original Tweet’s author ID. This will not necessarily always be the user directly mentioned in the Tweet. 
        [DataMember(Name = "in_reply_to_user_id")]
        public Int64? ReplyToUserId;

        [DataMember(Name = "lang")]
        public string Language;

        [DataMember(Name = "retweet_count")]
        public Int64 RetweetCount;

        [DataMember(Name = "source")]
        public string Source;

        [DataMember(Name = "text")]
        public string Text;

        [DataMember(Name = "user")]
        public TwitterUser User;

        [IgnoreDataMember]
        public string RawJson;
    }
}
