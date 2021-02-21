using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussionForumWebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("DiscussionForum");
            Response.Cookies["myCookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);
            Response.Redirect("/Index.aspx");
        }
    }
}