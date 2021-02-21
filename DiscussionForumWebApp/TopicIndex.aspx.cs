using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class TopicIndex : System.Web.UI.Page
    {
        public List<ServiceReference.TopicIndex> topicIndices { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["DiscussionForum"];
            if(cookie == null)
            {
                Response.Redirect("/Index.aspx");
            }
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            topicIndices = client.getTopics().ToList<ServiceReference.TopicIndex>();
        }
    }
}