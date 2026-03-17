using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
        DropDownList1.Items.Insert(0, new ListItem("-- Select State --", "0"));
    }

    // ================= LOAD DISTRICT =================
    public void LoadDistrict()
    {
        if (DropDownList1.SelectedIndex == 0 || DropDownList1.SelectedValue == "")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Insert(0, new ListItem("-- Select District --", "0"));
            return;
        }
        string sql = "SELECT Id, Districtname FROM DistrictMaster WHERE Stateid=" + DropDownList1.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }

    // ================= LOAD CONSTITUENCY =================
    public void LoadConstituency()
    {
        if (DropDownList2.SelectedIndex == 0)
            return;

        string sql = "SELECT Id, constituencyname FROM ConstituencyFive WHERE Districtid=" + DropDownList2.SelectedValue;

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "constituencyname";
        DropDownList3.DataValueField = "Id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("-- Select Constituency --", "0"));
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
        DropDownList4.Items.Insert(0, new ListItem("-- Select Party --", "0"));
    }

    // ================= LOAD SUB PARTY =================
    public void LoadSubParty()
    {
        if (DropDownList4.SelectedIndex == 0)
        {
            DropDownList5.Items.Clear();
            DropDownList5.Items.Insert(0, new ListItem("-- Select Sub Party --", "0"));
            return;
        }

        string sql = "SELECT Id, SubPartyName FROM SubPartyMaster WHERE PartyId=" + DropDownList4.SelectedValue;

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList5.Items.Clear();

        DropDownList5.DataSource = dt;
        DropDownList5.DataTextField = "SubPartyName";
        DropDownList5.DataValueField = "Id";
        DropDownList5.DataBind();

        DropDownList5.Items.Insert(0, new ListItem("-- Select Sub Party --", "0"));
    }

    // ================= EVENTS =================
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadDistrict();

        DropDownList3.Items.Clear();
        GridView1.DataSource = null;
        GridView1.DataBind();

        con.Close();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadConstituency();

        GridView1.DataSource = null;
        GridView1.DataBind();

        con.Close();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadGrid();
        con.Close();
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadSubParty();
        con.Close();
    }

    // ================= INSERT =================
    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        string sql1 = "";
        byte[] arr = FileUpload1.FileBytes;
        byte[] arr1 = FileUpload2.FileBytes;
        byte[] arr2 = FileUpload3.FileBytes;

        string imagepath = "";
        string logopath = "";
        string partycolorPath = "";
        string images = "";

        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentLength > 1048576)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Image should not exceed 1 MB')", true);
                return;
            }
            imagepath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        }

        if (FileUpload2.HasFile)
        {
            if (FileUpload2.PostedFile.ContentLength > 1048576)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Logo should not exceed 1 MB')", true);
                return;
            }
            logopath = Path.GetFullPath(FileUpload2.PostedFile.FileName);
        }

        if (FileUpload3.HasFile)
        {
            if (FileUpload3.PostedFile.ContentLength > 1048576)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Party colour should not exceed 1 MB')", true);
                return;
            }
            partycolorPath = Path.GetFullPath(FileUpload3.PostedFile.FileName);
        }

        // IMAGE
        string image = Path.GetFileName(imagepath);
        string waspimagePath = Path.Combine(@"X:\2025\ELECTION\CANDIDATE_IMAGE\", image);
        string brainimagePath = Path.Combine(@"Y:\Election\CANDIDATE_IMAGE\", image);

        // LOGO
        string logo = Path.GetFileName(logopath);
        string waspLogoPath = Path.Combine(@"X:\2025\ELECTION\SYMBOLS\", logo);
        string brainLogoPath = Path.Combine(@"Y:\Election\SYMBOLS\", logo);

        // PARTY COLOR
        string pcolor = Path.GetFileName(partycolorPath);
        string waspColorPath = Path.Combine(@"X:\2025\ELECTION\PARTY_COLOR\", pcolor);
        string brainColorPath = Path.Combine(@"Y:\Election\PARTY_COLOR\", pcolor);

        int vipcheck = 0;
        if (CheckBox1.Checked == true)
            vipcheck = 1;

        string subparty = "NULL";
        if (DropDownList5.SelectedIndex > 0)
            subparty = DropDownList5.SelectedValue;

        if (DropDownList1.SelectedIndex > 0 &&
            DropDownList2.SelectedIndex > 0 &&
            DropDownList3.SelectedIndex > 0 &&
            DropDownList4.SelectedIndex > 0 &&
            TextBox1.Text != "")
        {

            sql1 =
            "INSERT INTO CandidateDetailsN(Stateid,Districtid,Constituencyid,Partyid,SubPartyId,CantiName,Image_WASP,Image_BRAIN,Logo_WASP,Logo_BRAIN,Isvip,Partycolor_WASP,Partycolor_BRAIN,Arrow_WASP,Arrow_BRAIN,Lead,Total_vote,Status,Statusid,Voteshare,Pievalue,Arrowcolor,Arrowcolor_brain,Pollingonair,Onair,Onairvip,Totalvote1,Viponair,Image_fullfigure,Exit_poll) VALUES(" +
            "'" + DropDownList1.SelectedValue + "'," +
            "'" + DropDownList2.SelectedValue + "'," +
            "'" + DropDownList3.SelectedValue + "'," +
            "'" + DropDownList4.SelectedValue + "'," +
            subparty + "," +
            "N'" + TextBox1.Text + "'," +
            "'" + waspimagePath + "'," +
            "'" + brainimagePath + "'," +
            "'" + waspLogoPath + "'," +
            "'" + brainLogoPath + "'," +
            "'" + vipcheck + "'," +
            "'" + waspColorPath + "'," +
            "'" + brainColorPath + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0); select @@identity";

            SqlCommand cmd = new SqlCommand(sql1, con);

            object ob = cmd.ExecuteScalar();

            images = "insert into candi_five_image values(@img,@logo,@partycolor,'" + Convert.ToInt32(ob) + "')";

            SqlCommand cmdd = new SqlCommand(images, con);
            cmdd.Parameters.AddWithValue("@img", arr);
            cmdd.Parameters.AddWithValue("@logo", arr1);
            cmdd.Parameters.AddWithValue("@partycolor", arr2);
            cmdd.ExecuteNonQuery();

            LoadGrid();

            TextBox1.Text = "";
            CheckBox1.Checked = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "alertMessage", "alert('Candidate inserted successfully')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "alertMessage", "alert('Please fill all fields')", true);
        }

        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        get();

        DataTable dt = (DataTable)Session["data"];
        if (dt == null)
        {
            LoadGrid();
            dt = (DataTable)Session["data"];
        }
        Session["data"] = dt;

        for (int j = 0; j < dt.Rows.Count; j++)
        {
            string id = GridView1.DataKeys[j].Value.ToString();

            FileUpload fuImage = (FileUpload)GridView1.Rows[j].FindControl("FileUpload4");
            FileUpload fuLogo = (FileUpload)GridView1.Rows[j].FindControl("FileUpload5");
            FileUpload fuColor = (FileUpload)GridView1.Rows[j].FindControl("FileUpload6");

            if (fuImage != null && fuImage.HasFile)
            {
                byte[] img = fuImage.FileBytes;

                string sql = "update candi_five_image set image=@img where candidateid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.ExecuteNonQuery();
            }

            if (fuLogo != null && fuLogo.HasFile)
            {
                byte[] logo = fuLogo.FileBytes;

                string sql = "update candi_five_image set logo=@logo where candidateid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@logo", logo);
                cmd.ExecuteNonQuery();
            }

            if (fuColor != null && fuColor.HasFile)
            {
                byte[] color = fuColor.FileBytes;

                string sql = "update candi_five_image set partycolor=@color where candidateid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.ExecuteNonQuery();
            }
        }

        LoadGrid();
        con.Close();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        "alertMessage", "alert('Images updated successfully')", true);
    }

    // ================= GRID LOAD =================
    public void LoadGrid()
    {
        if (DropDownList1.SelectedIndex == 0 ||
            DropDownList2.SelectedIndex == 0 ||
            DropDownList3.SelectedIndex == 0)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            return;
        }

        string sql =
        "SELECT CandidateDetailsN.Id, CandidateDetailsN.CantiName, PartyMasterN.partyname, SubPartyMaster.SubPartyName " +
        "FROM CandidateDetailsN " +
        "INNER JOIN PartyMasterN ON CandidateDetailsN.Partyid = PartyMasterN.Id " +
        "LEFT JOIN SubPartyMaster ON CandidateDetailsN.SubPartyId = SubPartyMaster.Id " +
        "WHERE CandidateDetailsN.Stateid='" + DropDownList1.SelectedValue + "' " +
        "AND CandidateDetailsN.Districtid='" + DropDownList2.SelectedValue + "' " +
        "AND CandidateDetailsN.Constituencyid='" + DropDownList3.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();

        Session["data"] = dt;
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

        // Get data from session
        DataTable dt = (DataTable)Session["data"];
        Session["data"] = dt;

        // Get selected row id
        string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        // Delete query
        string sql = "DELETE FROM CandidateDetailsN WHERE Id='" + key + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "alertMessage", "alert('Deleted Successfully')", true);

        // Reload grid
        LoadGrid();

        con.Close();
    }
}
