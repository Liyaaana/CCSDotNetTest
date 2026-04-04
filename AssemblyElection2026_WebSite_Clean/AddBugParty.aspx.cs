using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Drawing.Imaging;

public partial class AddBugParty : Page
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Bug.aspx");
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
        Session["data1"] = dt;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        //district();
        data();
        con.Close();
    }

    // ================= DISTRICT DROPDOWN =================

    //public void district()
    //{
    //    if (DropDownList1.SelectedIndex > 0)
    //    {
    //        string sql =
    //            "select Id, Districtname from DistrictMaster " +
    //            "where Stateid='" + DropDownList1.SelectedValue + "'";

    //        SqlCommand cmd = new SqlCommand(sql, con);
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataTable dt1 = new DataTable();
    //        da.Fill(dt1);

    //        DropDownList2.DataSource = dt1;
    //        DropDownList2.DataTextField = "Districtname";
    //        DropDownList2.DataValueField = "Id";
    //        DropDownList2.DataBind();
    //        DropDownList2.Items.Insert(0, "-- Select --");
    //        Session["data1"] = dt1;
    //    }
    //}

    //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    get();
    //    data();
    //    con.Close();
    //}

    // ================= INSERT PARTY =================

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();
        string sql1 = "";
        string path = "";

        String waspPath = "";

        byte[] arr = FileUpload1.FileBytes;


        //party colour
        if (FileUpload1.PostedFile.FileName != "")
        {
            path = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
            String getPath = path;
            String image = Path.GetFileName(getPath);
            String waspLocation = getPath.Replace(getPath, @"X:\2025\ELECTION\PANCHAYATH\TEXTURES\");
            waspPath = Path.Combine(waspLocation, image);

            ///////////////////////////////////Liyana/////////////////////////////////////////////////////////
            //string check = "SELECT COUNT(*) FROM StateSeat WHERE Stateid='" + DropDownList1.SelectedValue + "' AND Districtid='" + DropDownList2.SelectedValue + "' AND PartyName=N'" + TextBox1.Text + "'";
            string check = "SELECT COUNT(*) FROM StateSeat WHERE Stateid='" + DropDownList1.SelectedValue + "'";

            SqlCommand checkCmd = new SqlCommand(check, con);
            int exists = (int)checkCmd.ExecuteScalar();

            if (exists == 0)
            {
                // INSERT
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", "alert('Party already exists')", true);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////

            object ob = new object();
            if (DropDownList1.SelectedItem.Value != "" && DropDownList1.SelectedItem.Value != "-- Select --" && TextBox1.Text != "")
            {
                //sql1 = "INSERT INTO DistrictWiseBug (Idd, PartyName, barcolor)VALUES('" + DropDownList2.SelectedItem.Value + "', N'" + TextBox1.Text + "', '" + waspPath +"');select @@identity";
                //sql1 = "insert into StateSeat(Stateid,PartyName,PartycolorWASP,PartycolorBRAIN,Pre_yr_seat,New_seat,Difference,ColorWASP,ColorBRAIN,Pie17,Pie22,Bar17,Bar22,Partycolor,Voteshare,Pie,CandiImage_Wasp,CandiImage_Brain,Logo_wasp,Logo_brain,Stateimage_brain,Displayname) values('" + DropDownList1.SelectedItem.Value + "',N'" + TextBox1.Text + "','" + waspPath + "','" + brainPath + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + waspCandiPath + "','" + brainCandiPath + "','" + waspLogoPath + "','" + brainLogoPath + "','" + 0 + "','" + 0 + "','" + DropDownList1.SelectedItem.Value + "');select @@identity";
                sql1 = "INSERT INTO StateSeat " +
                "(Stateid,  PartyName, PartycolorWASP, PartycolorBRAIN, " +
                "Pre_yr_seat, New_seat, Difference, ColorWASP, ColorBRAIN, " +
                "Pie17, Pie22, Bar17, Bar22, Partycolor, Voteshare, Pie, " +
                "CandiImage_Wasp, CandiImage_Brain, Logo_wasp, Logo_brain, Stateimage_brain, Displayname) VALUES (" +

                "'" + DropDownList1.SelectedValue + "', " +   // Stateid
                //"'" + DropDownList2.SelectedValue + "', " +   // Districtid
                "N'" + TextBox1.Text + "', " +               // PartyName
                "'" + waspPath + "', " +                     // PartycolorWASP
                "'" + waspPath + "', " +                     // PartycolorBRAIN

                "0, 0, '0', " +                             // Pre_yr_seat, New_seat, Difference
                "'', '', " +                                // ColorWASP, ColorBRAIN

                "0, 0, 0, 0, " +                            // Pie17, Pie22, Bar17, Bar22
                "'" + waspPath + "', " +                    // Partycolor
                "0, 0, " +                                  // Voteshare, Pie

                "'', '', '', '', '', " +                    // Images
                "N'" + TextBox1.Text + "'" +                // Displayname

                "); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql1, con);
                ob = cmd.ExecuteScalar();
                data();
                con.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select State Name & Party Name')", true);
            }
        }
    }

    // ================= GRID DATA =================

    public void data()
    {
        if (DropDownList1.SelectedIndex > 0)
        {
            //string sql = "SELECT Id, PartyName FROM DistrictWiseBug WHERE idd= '" + DropDownList2.SelectedItem.Value + "'"; 

            string sql =
                "select Id, PartyName from StateSeat " +
                "where Stateid='" + DropDownList1.SelectedValue + "' "
            /*+ "and Districtid='" + DropDownList2.SelectedValue + "'"*/;

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            GridView1.DataSource = dt2;
            GridView1.DataBind();
            Session["data1"] = dt2;
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
            "update DistrictWiseBug set PartyName=N'" + p_name +
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
        string del = "delete from DistrictWiseBug where Id='" + key + "'";

        SqlCommand cmd = new SqlCommand(del, con);
        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;
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
