using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DiscussionForum.Models
{
    [DataContract]
    public class Registration
    {
        [DataMember]
        public String UserName { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Password { get; set; }
    }
}