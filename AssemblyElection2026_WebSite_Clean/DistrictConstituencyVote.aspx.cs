using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistrictConstituencyVote : System.Web.UI.Page
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
            BindState();
            con.Close();
        }
    }

    // ================= STATE BIND =================
    public void BindState()
    {
        string sql = "SELECT Id, Statename FROM StateMaster";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Statename";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "-- Select --");
    }

    // ================= DISTRICT BIND =================
    public void BindDistrict()
    {
        string sql = "SELECT Id, Districtname FROM DistrictMaster WHERE Stateid='"
                     + DropDownList1.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "-- Select --");
    }

    // ================= MAIN GRID (LEAD UPDATE) =================
    public void BindGrid()
    {
        string sql =
            "SELECT id, constituencyname, CantiName, lead, status, total_vote " +
            "FROM CandidateDetailsN " +
            "WHERE Stateid='" + DropDownList1.SelectedValue + "' " +
            "AND Districtid='" + DropDownList2.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Visible = true;
    }

    // ================= ON AIR GRID =================
    public void BindOnAir()
    {
        string sql =
            "SELECT id, constituencyname, CantiName, status " +
            "FROM CandidateDetailsN " +
            "WHERE Onair=1 AND Stateid='" + DropDownList1.SelectedValue + "' " +
            "AND Districtid='" + DropDownList2.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    // ================= OFF AIR GRID =================
    public void BindOffAir()
    {
        string sql =
            "SELECT id, constituencyname, CantiName, status " +
            "FROM CandidateDetailsN " +
            "WHERE Onair=0 AND Stateid='" + DropDownList1.SelectedValue + "' " +
            "AND Districtid='" + DropDownList2.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    // ================= STATE CHANGED =================
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        BindDistrict();
        con.Close();
    }

    // ================= DISTRICT CHANGED =================
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        BindGrid();
        BindOnAir();
        BindOffAir();
        con.Close();
    }

    // ================= UPDATE LEAD / STATUS / TOTAL VOTE =================
    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string key = GridView1.DataKeys[i].Value.ToString();

            TextBox txtLead =
                (TextBox)GridView1.Rows[i].FindControl("TextBox");

            TextBox txtTotalVote =
                (TextBox)GridView1.Rows[i].FindControl("TextBox1");

            DropDownList ddlStatus =
                (DropDownList)GridView1.Rows[i].FindControl("DropDownList3");

            string lead = txtLead.Text;
            string totalVote = txtTotalVote.Text;
            string status = ddlStatus.SelectedValue;

            string update =
                "UPDATE CandidateDetailsN SET " +
                "lead='" + lead + "', " +
                "status=N'" + status + "', " +
                "total_vote='" + totalVote + "' " +
                "WHERE id='" + key + "'";

            SqlCommand cmd = new SqlCommand(update, con);
            cmd.ExecuteNonQuery();
        }

        BindGrid();
        BindOnAir();
        BindOffAir();
        con.Close();
    }

    // ================= ON AIR → OFF AIR =================
    protected void Button2_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            string key = GridView2.DataKeys[i].Value.ToString();

            CheckBox chk =
                (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");

            if (chk != null && chk.Checked)
            {
                string update =
                    "UPDATE CandidateDetailsN SET Onair=0 WHERE id='" + key + "'";

                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
            }
        }

        BindOnAir();
        BindOffAir();
        con.Close();
    }

    // ================= OFF AIR → ON AIR =================
    protected void Button3_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            string key = GridView3.DataKeys[i].Value.ToString();

            CheckBox chk =
                (CheckBox)GridView3.Rows[i].FindControl("CheckBox3");

            if (chk != null && chk.Checked)
            {
                string update =
                    "UPDATE CandidateDetailsN SET Onair=1 WHERE id='" + key + "'";

                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
            }
        }

        BindOnAir();
        BindOffAir();
        con.Close();
    }
}
