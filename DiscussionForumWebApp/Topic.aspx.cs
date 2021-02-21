using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class Topic : System.Web.UI.Page
    {
        string token;
        int Id;
        public ServiceReference.TopicPage topicPage { get; set; }
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
            Id = Int32.Parse(Request.QueryString["Id"]);
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            try
            {
                topicPage = client.getTopicPage(Id);
                if (topicPage == null)
                {
                    Response.Redirect("/Error.aspx");
                }
                Label3.Text = "Title: " + topicPage.Name;
                Label4.Text = "Description: " + topicPage.Discussion;
                Label5.Text = "By: " + topicPage.Author;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            ServiceReference.Comment comment = new ServiceReference.Comment();
            comment.TopicId = Id;
            comment.token = token;
            comment.Comments = TextBox1.Text;
            try
            {
                client.addComment(comment);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (TimeoutException exception)
            {
                Label2.Text = "Timeout";
            }
            catch (FaultException<ServiceReference.ForumException> exception)
            {
                Label2.Text = "Try chaging values";
            }
            catch (FaultException exception)
            {
                Label2.Text = "Try changing value";
            }
            catch (CommunicationException exception)
            {
                Label2.Text = "Try changing value";
            }
        }
    }
}