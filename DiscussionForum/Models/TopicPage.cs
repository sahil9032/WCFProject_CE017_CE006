using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DiscussionForum.Models
{
    [DataContract]
    public class TopicPage
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Discussion { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public List<CommentPage> comments { get; set; }
    }
}