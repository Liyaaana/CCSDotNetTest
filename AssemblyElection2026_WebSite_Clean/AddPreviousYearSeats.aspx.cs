using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPreviousYearSeats : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    public void get()
    {
        con.ConnectionString =
            ConfigurationManager.ConnectionStrings["Assembly2026"].ToString();
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

    // ================= STATE =================

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
        GridView1.DataSource = null;   // optional (clears grid)
        GridView1.DataBind();
        con.Close();
    }

    // ================= DISTRICT =================

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
        BindGrid();
        con.Close();
    }

    // ================= GRID BIND =================

    public void BindGrid()
    {
        if (DropDownList1.SelectedIndex > 0 &&
            DropDownList2.SelectedIndex > 0)
        {
            string sql =
            "SELECT Id as SeatId," + " PartyName AS partyname, " +
            "ISNULL(Pre_yr_seat,0) AS Pre_yr_seat " +
            "FROM StateSeat " +
            "WHERE Stateid='" + DropDownList1.SelectedValue + "' " +
            "AND Districtid='" + DropDownList2.SelectedValue + "'";
            /*  string sql =
                "SELECT P.id AS PartyId, P.partyname, " +
                "ISNULL(S.Pre_yr_seat,0) AS Pre_yr_seat, " +
                "S.Id AS SeatId " +
                "FROM PartyMasterN P " +
                "LEFT JOIN StateSeat S ON " +
                "    S.PartyName = P.partyname AND " +
                "    S.Stateid = '" + DropDownList1.SelectedValue + "' AND " +
                "    S.Districtid = '" + DropDownList2.SelectedValue + "'";
            */
            
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            Session["UPDATA"] = dt;
        }
    }


    // ================= UPDATE BUTTON =================

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string partyName = GridView1.Rows[i].Cells[0].Text;
            string seat = ((TextBox)GridView1.Rows[i]
                          .FindControl("TextBox1")).Text;

            if (!string.IsNullOrEmpty(seat))
            {
                string checkQuery =
                "SELECT COUNT(*) FROM StateSeat WHERE " +
                "Stateid='" + DropDownList1.SelectedValue + "' AND " +
                "Districtid='" + DropDownList2.SelectedValue + "' AND " +
                "PartyName='" + partyName + "'";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    string update =
                    "UPDATE StateSeat SET Pre_yr_seat='" + seat + "' WHERE " +
                    "Stateid='" + DropDownList1.SelectedValue + "' AND " +
                    "Districtid='" + DropDownList2.SelectedValue + "' AND " +
                    "PartyName='" + partyName + "'";

                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string insert =
                    "INSERT INTO StateSeat (Stateid, Districtid, PartyName, Pre_yr_seat) VALUES ('" +
                    DropDownList1.SelectedValue + "','" +
                    DropDownList2.SelectedValue + "','" +
                    partyName + "','" +
                    seat + "')";

                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        BindGrid();
        con.Close();
    }
}
