using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference.DiscussionForumServiceClient client = new ServiceReference.DiscussionForumServiceClient();
            ServiceReference.Registration registration = new ServiceReference.Registration();
            if(TextBox3.Text != TextBox4.Text)
            {
                Label5.Text = "Password and confirm password not matching.";
                return;
            }
            registration.UserName = TextBox1.Text;
            registration.Email = TextBox2.Text;
            registration.Password = TextBox3.Text;
            if (client.registerUser(registration))
            {
                Response.Redirect("/Index.aspx");
            }
            else
            {
                Label5.Text = "Try changing value";
            }
        }
    }
}