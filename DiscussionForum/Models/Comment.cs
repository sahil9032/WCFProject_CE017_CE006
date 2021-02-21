using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DiscussionForum.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public int TopicId { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}