using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DiscussionForum.Models
{
    [DataContract]
    public class Topic
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Discussion { get; set; }
    }
}