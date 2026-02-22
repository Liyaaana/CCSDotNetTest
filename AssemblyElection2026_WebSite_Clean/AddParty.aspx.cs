using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AddParty : Page
{
    SqlConnection con = new SqlConnection();

    // Open Connection
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

    // ================= STATE DROPDOWN =================

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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        district();
        data();
        con.Close();
    }

    // ================= DISTRICT DROPDOWN =================

    public void district()
    {
        if (DropDownList1.SelectedIndex > 0)
        {
            string sql =
                "select Id, Districtname from DistrictMaster " +
                "where Stateid='" + DropDownList1.SelectedValue + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Districtname";
            DropDownList2.DataValueField = "Id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "-- Select --");
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        data();
        con.Close();
    }

    // ================= INSERT PARTY =================

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        string waspPath = "";

        if (FileUpload1.HasFile)
        {
            waspPath = @"X:\2024\ELECTION\PARTY_COLOR\" +
                        Path.GetFileName(FileUpload1.FileName);
        }

        if (DropDownList1.SelectedIndex > 0 &&
            DropDownList2.SelectedIndex > 0 &&
            TextBox1.Text != "")
        {
            string sql =
                "insert into StateSeat(Stateid,Districtid,PartyName,PartycolorWASP,Pre_yr_seat,New_seat,Difference) " +
                "values('" + DropDownList1.SelectedValue + "','" +
                DropDownList2.SelectedValue + "',N'" + TextBox1.Text + "','" +
                waspPath + "',0,0,0)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            TextBox1.Text = "";

            ScriptManager.RegisterClientScriptBlock(
                this, this.GetType(), "alertMessage",
                "alert('Party Added Successfully...')", true);

            data();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(
                this, this.GetType(), "alertMessage",
                "alert('Please select State, District & Enter Party Name')", true);
        }

        con.Close();
    }

    // ================= GRID DATA =================

    public void data()
    {
        if (DropDownList1.SelectedIndex > 0 &&
            DropDownList2.SelectedIndex > 0)
        {
            string sql =
                "select Id, PartyName from StateSeat " +
                "where Stateid='" + DropDownList1.SelectedValue + "' " +
                "and Districtid='" + DropDownList2.SelectedValue + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    // ================= GRID EDIT =================

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
        string p_name = ((TextBox)GridView1.Rows[e.RowIndex]
                        .Cells[0].Controls[0]).Text;

        string update =
            "update StateSeat set PartyName=N'" + p_name +
            "' where Id='" + key + "'";

        SqlCommand cmd = new SqlCommand(update, con);
        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;

        ScriptManager.RegisterClientScriptBlock(
            this, this.GetType(), "alertMessage",
            "alert('Updated Successfully')", true);

        data();
        con.Close();
    }

    // ================= GRID DELETE =================

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        get();

        string key = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from StateSeat where Id='" + key + "'";

        SqlCommand cmd = new SqlCommand(del, con);
        cmd.ExecuteNonQuery();

        ScriptManager.RegisterClientScriptBlock(
            this, this.GetType(), "alertMessage",
            "alert('Deleted Successfully')", true);

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
