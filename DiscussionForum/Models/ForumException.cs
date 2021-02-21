using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DiscussionForum.Models
{
    [DataContract]
    public class ForumException
    {
        [DataMember]
        public int ErrorCode;
        [DataMember]
        public string Message;
    }
}