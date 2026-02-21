using System;

namespace ElectionExample1
{
    public partial class Vote : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rblCandidates.SelectedItem != null)
            {
                lblResult.Text = "You voted for: " + rblCandidates.SelectedItem.Text;
            }
            else
            {
                lblResult.Text = "Please select a candidate.";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
