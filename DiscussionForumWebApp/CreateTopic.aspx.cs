using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class CreateTopic : System.Web.UI.Page
    {
        string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["DiscussionForum"];
            if (cookie != null)
            {
                token = cookie["token"].ToString();
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            ServiceReference.Topic topic = new ServiceReference.Topic();
            topic.Name = TextBox1.Text;
            topic.Discussion = TextBox2.Text;
            topic.token = token;
            try
            {
                client.createTopic(topic);
                Response.Redirect("/TopicIndex.aspx");
            }
            catch (TimeoutException exception)
            {
                Label3.Text = "Timeout";
            }
            catch (FaultException<ServiceReference.ForumException> exception)
            {
                Label3.Text = "Try changing value";
            }
            catch (FaultException exception)
            {
                Label3.Text = "Try changing value";
            }
            catch (CommunicationException exception)
            {
                Label3.Text = "Try changing value";
            }
        }
    }
}