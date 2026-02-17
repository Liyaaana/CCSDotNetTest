using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddDistricts : Page
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
            state();
            data();
            con.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        if (DropDownList1.SelectedIndex > 0 && TextBox1.Text != "")
        {
            string sql =
                "insert into DistrictMaster(Stateid,Districtname,Total_Seat) values ('" +
                DropDownList1.SelectedValue + "',N'" + TextBox1.Text + "','" + TextBox2.Text + "')";

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

    public void state()
    {
        string sql = "select Id, Statename from StateMaster";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Statename";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "-- Select --");
    }

    public void data()
    {
        string sql =
            "select s.Statename, d.Districtname, d.Total_Seat, d.Id as id " +
            "from DistrictMaster d inner join StateMaster s on d.Stateid=s.Id";

        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        data();
        con.Close();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        get();
        GridView1.EditIndex = e.NewEditIndex;
        data();
        con.Close();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        get();
        string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string d_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        //string s_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string s_total = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string update = "update DistrictMaster set Districtname=N'" + d_name + "', Total_Seat=N'" + s_total + "' where id='" + key + "'";
        SqlCommand updatee = new SqlCommand(update, con);
        updatee.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        data();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        get();
        GridView1.EditIndex = -1;
        data();
        con.Close();
    }
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    get();
    //    string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
    //    string update = "delete from StateMaster where id='" + key + "'";
    //    SqlCommand updatee = new SqlCommand(update, con);
    //    updatee.ExecuteNonQuery();
    //    con.Close();
    //    GridView1.EditIndex = -1;
    //    data();
    //}
}

