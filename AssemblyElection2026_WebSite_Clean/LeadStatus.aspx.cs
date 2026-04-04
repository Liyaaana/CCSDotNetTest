using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel.Protocols.WSTrust;

public partial class LeadStatus : System.Web.UI.Page
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
            LoadState();
            con.Close();
        }
    }

    // ================= STATE =================

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
        DropDownList1.Items.Insert(0, "--Select--");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadDistrict();

        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;

        con.Close();
    }

    // ================= DISTRICT =================

    public void LoadDistrict()
    {
        string sql =
            "SELECT Id, Districtname FROM DistrictMaster WHERE Stateid='" +
            DropDownList1.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "--Select--");
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        LoadConstituency();
        con.Close();
    }

    // ================= CONSTITUENCY =================

    public void LoadConstituency()
    {
        string sql =
            "SELECT Id, constituencyname FROM ConstituencyFive WHERE Districtid='" +
            DropDownList2.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList3.DataSource = dt;
        DropDownList3.DataTextField = "constituencyname";
        DropDownList3.DataValueField = "Id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, "--Select--");
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedIndex == 0)
            return;

        get();
        LoadCandidateGrid();
        LoadOnAir();
        LoadOffAir();
        con.Close();
    }


    // ================= MAIN GRID =================

    public void LoadCandidateGrid()
    {
        string sql =
            "SELECT CandidateDetailsN.Id, " +
            "ConstituencyFive.constituencyname, " +
            "CandidateDetailsN.CantiName, " +
            "CandidateDetailsN.lead, " +
            "CandidateDetailsN.Status, " +
            "CandidateDetailsN.total_vote " +
            "FROM CandidateDetailsN " +
            "INNER JOIN ConstituencyFive ON CandidateDetailsN.constituencyid = ConstituencyFive.Id " +
            "WHERE CandidateDetailsN.constituencyid='" +
            DropDownList3.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
        Session["dataab"] = dt;

        // 🔥 THIS IS THE IMPORTANT PART (Old Logic)
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            DropDownList dl =
                (DropDownList)GridView1.Rows[i]
                .FindControl("DropDownList4");

            if (dl != null)
            {
                string rr = "SELECT * FROM LeadStatus";

                SqlDataAdapter daStatus =
                    new SqlDataAdapter(rr, con);

                DataTable dtStatus = new DataTable();
                daStatus.Fill(dtStatus);

                dl.DataSource = dtStatus;
                dl.DataValueField = "id";
                dl.DataTextField = "status";
                dl.DataBind();

                dl.Items.Insert(0, new ListItem(" ", "0"));
            }
        }

        GridView1.Visible = true;
    }


    // ================= UPDATE BUTTON =================

    protected void Button1_Click(object sender, EventArgs e)
    {
        //get();

        //for (int i = 0; i < GridView1.Rows.Count; i++)
        //{
        //    string key = GridView1.DataKeys[i].Value.ToString();

        //    TextBox txtLead =
        //        (TextBox)GridView1.Rows[i].FindControl("TextBox");

        //    TextBox txtVote =
        //        (TextBox)GridView1.Rows[i].FindControl("TextBox1");

        //    DropDownList ddlStatus =
        //        (DropDownList)GridView1.Rows[i].FindControl("DropDownList4");

        //    // ✅ UPDATE LEAD ONLY IF ENTERED
        //    if (txtLead != null && txtLead.Text.Trim() != "")
        //    {
        //        string updateLead =
        //            "UPDATE CandidateDetailsN SET lead='" +
        //            txtLead.Text + "' WHERE Id='" + key + "'";

        //        SqlCommand cmdLead = new SqlCommand(updateLead, con);
        //        cmdLead.ExecuteNonQuery();
        //    }

        //    // ✅ UPDATE TOTAL VOTE ONLY IF ENTERED
        //    if (txtVote != null && txtVote.Text.Trim() != "")
        //    {
        //        string updateVote =
        //            "UPDATE CandidateDetailsN SET total_vote='" +
        //            txtVote.Text + "' WHERE Id='" + key + "'";

        //        SqlCommand cmdVote = new SqlCommand(updateVote, con);
        //        cmdVote.ExecuteNonQuery();
        //    }

        //    // ✅ UPDATE STATUS ONLY IF SELECTED
        //    if (ddlStatus != null &&
        //        ddlStatus.SelectedItem != null &&
        //        ddlStatus.SelectedItem.Text.Trim() != "")
        //    {
        //        string updateStatus =
        //            "UPDATE CandidateDetailsN SET Status=N'" +
        //            ddlStatus.SelectedItem.Text +
        //            "' WHERE Id='" + key + "'";

        //        SqlCommand cmdStatus =
        //            new SqlCommand(updateStatus, con);
        //        cmdStatus.ExecuteNonQuery();
        //    }
        //}
        get();
        DataTable dt12 = (DataTable)Session["dataab"];

        if (dt12 == null)
        {
            LoadCandidateGrid();
            dt12 = (DataTable)Session["dataab"];
        }
        for (int j = 0; j < dt12.Rows.Count; j++)
        {
            string key = GridView1.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView1.Rows[j].Cells[0].FindControl("TextBox")).Text; // textbox of Lead
            string textbox1 = ((TextBox)GridView1.Rows[j].Cells[0].FindControl("TextBox1")).Text; // textbox of TotalVote
            string dropdown = ((DropDownList)GridView1.Rows[j].Cells[0].FindControl("DropDownList4")).SelectedItem.Text; // dropdown of Status(select text like munnil)
            string dropdown1 = ((DropDownList)GridView1.Rows[j].Cells[0].FindControl("DropDownList4")).SelectedItem.Value; //dropdown of Status(select value ie, id of munnil)
                                                                                                                           //if (textbox != "" && textbox1!="")
                                                                                                                           //{
            string Wasp_path = "";
            string Brain_path = "";
            //if (dropdown1 == "")
            //{
            //    string leadcolor = "select Arrowcolor from CandidateDetailsN where id='" + key + "'";
            //}

            if (dropdown1 != "")
            {
                if (dropdown1 == "1" || dropdown1 == "3" || dropdown1 == "6")
                {
                    Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\GREEN.png";
                    Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
                }
                else if (dropdown1 == "2" || dropdown1 == "4")
                {
                    Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\RED.png";
                    Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
                }
                else if (dropdown1 == "5")// condn for id = 5
                {
                    Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
                    Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";


                    //    string getArrow = "select Arrowcolor from CandidateDetailsN where id='" + key + "'";
                    //    SqlCommand getCmd = new SqlCommand(getArrow, con);
                    //    object result = getCmd.ExecuteScalar();
                    //    if (result != null && result != DBNull.Value)
                    //    {
                    //        Wasp_path = result.ToString();
                    //    }
                    //    else
                    //    {
                    //        Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
                    //       // Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";
                    //    }
                }


                if (dropdown1 != " " && Convert.ToInt32(dropdown1) > 0)
                {
                    string updateStatus = "update CandidateDetailsN set status =N'" + dropdown + "',Arrowcolor ='" + Wasp_path + "',Arrowcolor_brain='" + Brain_path + "' ,statusid='" + dropdown1 + "' where id='" + key + "'";
                    SqlCommand sel1 = new SqlCommand(updateStatus, con);
                    sel1.ExecuteNonQuery();
                }

            }
            if (textbox != "")
            {
                string updatee11 = "update CandidateDetailsN set Arrowcolor =N'" + Wasp_path + "',Arrowcolor_brain=N'" + Brain_path + "', lead='" + textbox + "' where id='" + key + "'";
                SqlCommand sel1 = new SqlCommand(updatee11, con);
                sel1.ExecuteNonQuery();
            }

            if (textbox1 != "")
            {
                string updatee11 = "update CandidateDetailsN set total_vote='" + textbox1 + "' where id='" + key + "'";
                SqlCommand sel1 = new SqlCommand(updatee11, con);
                sel1.ExecuteNonQuery();
            }

        }

        LoadCandidateGrid();
        LoadOnAir();
        LoadOffAir();
        con.Close();
    }


    // ================= ON AIR =================

    public void LoadOnAir()
    {
        string sql =
            "SELECT CandidateDetailsN.Id, " +
            "ConstituencyFive.constituencyname, " +
            "CandidateDetailsN.CantiName, " +
            "CandidateDetailsN.Status " +
            "FROM CandidateDetailsN " +
            "INNER JOIN ConstituencyFive " +
            "ON CandidateDetailsN.constituencyid = ConstituencyFive.Id " +
            "WHERE CandidateDetailsN.constituencyid='" +
            DropDownList3.SelectedValue + "' " +
            "AND CandidateDetailsN.Onair=1";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView2.DataSource = dt;
        GridView2.DataBind();
        GridView2.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            string key = GridView2.DataKeys[i].Value.ToString();

            CheckBox chk =
                (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");

            if (chk.Checked)
            {
                string update =
                    "UPDATE CandidateDetailsN SET Onair=0 WHERE Id='" + key + "'";

                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
            }
        }

        LoadOnAir();
        LoadOffAir();
        con.Close();
    }


    // ================= OFF AIR =================

    public void LoadOffAir()
    {
        string sql =
            "SELECT CandidateDetailsN.Id, " +
            "ConstituencyFive.constituencyname, " +
            "CandidateDetailsN.CantiName, " +
            "CandidateDetailsN.Status " +
            "FROM CandidateDetailsN " +
            "INNER JOIN ConstituencyFive " +
            "ON CandidateDetailsN.constituencyid = ConstituencyFive.Id " +
            "WHERE CandidateDetailsN.constituencyid='" +
            DropDownList3.SelectedValue + "' " +
            "AND (CandidateDetailsN.Onair=0 OR CandidateDetailsN.Onair IS NULL)";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView3.DataSource = dt;
        GridView3.DataBind();
        GridView3.Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        get();

        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            string key = GridView3.DataKeys[i].Value.ToString();

            CheckBox chk =
                (CheckBox)GridView3.Rows[i].FindControl("CheckBox3");

            if (chk.Checked)
            {
                string update =
                    "UPDATE CandidateDetailsN SET Onair=1 WHERE Id='" + key + "'";

                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
            }
        }

        LoadOnAir();
        LoadOffAir();
        con.Close();
    }
}
