using System;

namespace ElectionExample1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vote.aspx");
        }
    }
}
