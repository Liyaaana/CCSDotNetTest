using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddStates : Page
{
    SqlConnection con = new SqlConnection();

    public void get()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["Assembly2026"].ToString();
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get();
            data();
            con.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        if (TextBox1.Text != "")
        {
            string sql = "insert into StateMaster(Statename,Total_Seat) values (N'" +
                         TextBox1.Text + "','" + TextBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox2.Text = "";

            ScriptManager.RegisterClientScriptBlock(
                this, this.GetType(), "alertMessage", "alert('Done...')", true);

            data();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(
                this, this.GetType(), "alertMessage", "alert('Please Enter the name')", true);
        }

        con.Close();
    }

    public void data()
    {
        string sql = "select Id, Statename, Total_Seat from StateMaster";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        get();
        data();
        con.Close();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        get();

        string key = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string s_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string s_total = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

        string update =
            "update StateMaster set Statename=N'" + s_name +
            "', Total_Seat='" + s_total + "' where Id='" + key + "'";

        SqlCommand cmd = new SqlCommand(update, con);
        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;
        data();
        con.Close();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        get();
        data();
        con.Close();
    }
}
