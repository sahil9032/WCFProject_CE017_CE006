using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DiscussionForum.Models
{
    [DataContract]
    public class CommentPage
    {
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Timestamp { get; set; }
    }
}