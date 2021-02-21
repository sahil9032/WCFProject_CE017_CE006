using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            ServiceReference.Login login = new ServiceReference.Login();
            login.Email = TextBox1.Text;
            login.Password = TextBox2.Text;
            string token = client.login(login);
            if (token != "")
            {
                HttpCookie discussionForum = new HttpCookie("DiscussionForum");
                discussionForum["token"] = token;
                discussionForum.Expires.Add(new TimeSpan(0, 30, 0));
                Response.Cookies.Add(discussionForum);
                Response.Redirect("/TopicIndex.aspx");
            }
            else
            {
                Label3.Text = "Failed";
            }

        }
    }
}