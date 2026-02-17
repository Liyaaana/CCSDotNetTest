using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Constituency_insertion : System.Web.UI.Page
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
            con.Close();
        }
    }

    public void state()
    {
        string sql = "select * from StateMaster";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Statename";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void district()
    {
        if (DropDownList1.SelectedValue == "0")
            return;

        string sql = "select * from DistrictMaster where Stateid=" + DropDownList1.SelectedValue;

        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("-- Select --", "0"));
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        district();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "0" ||
            DropDownList2.SelectedValue == "0" ||
            TextBox1.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(),
                "alert", "alert('Please select State & District');", true);
            return;
        }

        get();

        string sql = "insert into ConstituencyFive (stateid,districtid,constituencyname) values(" +
                     DropDownList1.SelectedValue + "," +
                     DropDownList2.SelectedValue + ",N'" +
                     TextBox1.Text + "')";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        TextBox1.Text = "";

        // ✅ IMPORTANT: Reload Grid
        data();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Done...')", true);

        con.Close();
    }


    public void data()
    {
        if (DropDownList2.SelectedValue == "0")
            return;

        string sql1 = "SELECT ConstituencyFive.Id, StateMaster.Statename, ConstituencyFive.Constituencyname " +
                      "FROM ConstituencyFive INNER JOIN StateMaster ON ConstituencyFive.Stateid = StateMaster.Id " +
                      "WHERE ConstituencyFive.Districtid=" + DropDownList2.SelectedValue;

        SqlCommand cmd2 = new SqlCommand(sql1, con);
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);

        GridView1.DataSource = dt2;
        GridView1.DataBind();
    }


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
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
        string c_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string update = "update constituencyfive set Constituencyname=N'" + c_name + "' where id='" + key + "'";
        SqlCommand updatee = new SqlCommand(update, con);
        updatee.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated successfully..')", true);
        data();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        get();
        GridView1.EditIndex = -1;
        data();
        con.Close();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        get();
        string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string update = "delete from ConstituencyFive where Id='" + key + "'";
        SqlCommand updatee = new SqlCommand(update, con);
        updatee.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted successfully..')", true);
        data();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
    {

    }
}



