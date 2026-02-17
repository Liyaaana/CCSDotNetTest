using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Candidate_insertion : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    // ================= CONNECTION =================
    public void get()
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["Assembly2026"].ToString();
        con.Open();
    }

    // ================= PAGE LOAD =================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get();
            LoadState();
            LoadParty();
            con.Close();
        }
    }

    // ================= LOAD STATE =================
    public void LoadState()
    {
        string sql = "SELECT Id, Statename FROM StateMaster";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Statename";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "-- Select State --");
    }

    // ================= LOAD DISTRICT =================
    public void LoadDistrict()
    {
        string sql = "SELECT Id, Districtname FROM DistrictMaster WHERE Stateid=" + DropDownList1.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "-- Select District --");
    }

    // ================= LOAD CONSTITUENCY =================
    public void LoadConstituency()
    {
        string sql = "SELECT Id, constituencyname FROM ConstituencyFive WHERE Districtid=" + DropDownList2.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "constituencyname";
        DropDownList3.DataValueField = "Id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, "-- Select Constituency --");
    }

    // ================= LOAD PARTY =================
    public void LoadParty()
    {
        string sql = "SELECT Id, partyname FROM PartyMasterN";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList4.DataSource = dt;
        DropDownList4.DataTextField = "partyname";
        DropDownList4.DataValueField = "Id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, "-- Select Party --");
    }

    // ================= EVENTS =================

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadDistrict();
        con.Close();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadConstituency();
        con.Close();
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadGrid();
        con.Close();
    }

    // ================= INSERT =================
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0 ||
            DropDownList2.SelectedIndex == 0 ||
            DropDownList3.SelectedIndex == 0 ||
            DropDownList4.SelectedIndex == 0 ||
            TextBox1.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(),
                "alert", "alert('Please fill all fields');", true);
            return;
        }

        get();

        string sql = "INSERT INTO CandidateDetailsN(Stateid, Districtid, Constituencyid, Partyid, CantiName, Isvip) VALUES(" +
                     DropDownList1.SelectedValue + "," +
                     DropDownList2.SelectedValue + "," +
                     DropDownList3.SelectedValue + "," +
                     DropDownList4.SelectedValue + ",N'" +
                     TextBox1.Text.Trim() + "'," +
                     (CheckBox1.Checked ? 1 : 0) + ")";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        TextBox1.Text = "";

        ScriptManager.RegisterClientScriptBlock(this, GetType(),
            "alert", "alert('Candidate inserted successfully');", true);

        LoadGrid();
        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string id = GridView1.DataKeys[i].Value.ToString();

            FileUpload fuImage = (FileUpload)GridView1.Rows[i].FindControl("FileUpload3");
            FileUpload fuLogo = (FileUpload)GridView1.Rows[i].FindControl("FileUpload4");
            FileUpload fuColor = (FileUpload)GridView1.Rows[i].FindControl("FileUpload5");

            if (fuImage != null && fuImage.HasFile)
            {
                byte[] img = fuImage.FileBytes;
                string sql = "UPDATE candi_five_image SET image=@img WHERE candidateid=" + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.ExecuteNonQuery();
            }

            if (fuLogo != null && fuLogo.HasFile)
            {
                byte[] logo = fuLogo.FileBytes;
                string sql = "UPDATE candi_five_image SET logo=@logo WHERE candidateid=" + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@logo", logo);
                cmd.ExecuteNonQuery();
            }

            if (fuColor != null && fuColor.HasFile)
            {
                byte[] color = fuColor.FileBytes;
                string sql = "UPDATE candi_five_image SET partycolor=@color WHERE candidateid=" + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.ExecuteNonQuery();
            }
        }

        LoadGrid(); // or getdata()
        con.Close();

        ScriptManager.RegisterClientScriptBlock(this, GetType(),
            "alert", "alert('Images updated successfully');", true);
    }

    // ================= GRID LOAD =================
    public void LoadGrid()
    {
        string sql =
        "SELECT CandidateDetailsN.Id, " +
        "CandidateDetailsN.CantiName, " +
        "PartyMasterN.partyname " +
        "FROM CandidateDetailsN " +
        "INNER JOIN PartyMasterN ON CandidateDetailsN.Partyid = PartyMasterN.Id " +
        "WHERE CandidateDetailsN.Constituencyid=" + DropDownList3.SelectedValue;

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    // ================= GRID EDIT =================
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        get();
        GridView1.EditIndex = e.NewEditIndex;
        LoadGrid();
        con.Close();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        get();
        GridView1.EditIndex = -1;
        LoadGrid();
        con.Close();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        get();

        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

        string sql = "UPDATE CandidateDetailsN SET CantiName=N'" + name + "' WHERE Id=" + id;

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;
        LoadGrid();
        con.Close();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        get();

        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string sql = "DELETE FROM CandidateDetailsN WHERE Id=" + id;

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        LoadGrid();
        con.Close();
    }
}
