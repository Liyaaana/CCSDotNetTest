using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

 

    public partial class VIP_Onair : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        public void get()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Assembly2026"].ToString();
            con.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            get();
            if (!IsPostBack)
            {
                state();
                //bindd21();
            }
            con.Close();
        }
        //ON AIR
        protected void Button1_Click(object sender, EventArgs e)
        {
            get();
            DataTable dtq12 = (DataTable)Session["check"];
            Session["check"] = dtq12;

            for (int j = 0; j < dtq12.Rows.Count; j++)
            {
                string key = GridView1.DataKeys[j].Values[0].ToString();
                bool dropdown = ((CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox1")).Checked;
                if (dropdown == true)
                {
                    string update = "update CandidateDetailsN set Onairvip='" + 1 + "' where Id='" + key + "'";//lead
                    SqlCommand cmd4 = new SqlCommand(update, con);
                    cmd4.ExecuteNonQuery();
                }
            }
            bindd();
            bindd21();
            con.Close();
        }
        //OFF AIR
        protected void Button2_Click(object sender, EventArgs e)
        {
            get();
            DataTable dtq12 = (DataTable)Session["checkq"];
            Session["checkq"] = dtq12;

            for (int j = 0; j < dtq12.Rows.Count; j++)
            {
                string key = GridView2.DataKeys[j].Values[0].ToString();
                bool dropdown = ((CheckBox)GridView2.Rows[j].Cells[0].FindControl("CheckBox2")).Checked;
                if (dropdown == true)
                {
                    string update = "update CandidateDetailsN set Onairvip='" + 0 + "' where Id='" + key + "'";//lead
                    SqlCommand cmd4 = new SqlCommand(update, con);
                    cmd4.ExecuteNonQuery();
                }
            }
            bindd();
            bindd21();
            con.Close();
        }
        public void state()
        {
            string sql1 = "select * from StateMaster";
            SqlCommand cmf = new SqlCommand(sql1, con);
            SqlDataAdapter daf = new SqlDataAdapter(cmf);
            DataTable dtff1 = new DataTable();
            daf.Fill(dtff1);
            if (dtff1.Rows.Count > 0)
            {
                DropDownList1.DataSource = dtff1;
                DropDownList1.DataTextField = "Statename";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select--");
                Session["data1"] = dtff1;
            }
        }

    public void district()
    {
        string sql =
            "select id, Districtname from DistrictMaster " +
            "where Stateid='" + DropDownList1.SelectedValue + "'";

        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Districtname";
        DropDownList2.DataValueField = "id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "--Select--");
    }

    public void bindd()
        {
            string sql12 = "";
            if (DropDownList1.SelectedItem.Value != "" && DropDownList1.SelectedItem.Value != "--Select--")
            {
            sql12 = "SELECT CandidateDetailsN.Id, CandidateDetailsN.Stateid, " +
"StateMaster.Statename, CandidateDetailsN.Constituencyid, " +
"ConstituencyFive.Constituencyname, CandidateDetailsN.CantiName, " +
"CandidateDetailsN.Status, CandidateDetailsN.Statusid, CandidateDetailsN.Onair " +
"FROM StateMaster " +
"INNER JOIN ConstituencyFive ON StateMaster.id = ConstituencyFive.Stateid " +
"INNER JOIN CandidateDetailsN ON ConstituencyFive.Id = CandidateDetailsN.Constituencyid " +
"WHERE CandidateDetailsN.Stateid='" + DropDownList1.SelectedValue + "' " +
"AND CandidateDetailsN.Districtid='" + DropDownList2.SelectedValue + "' " +
"AND CandidateDetailsN.Isvip = 1 " +
"AND (CandidateDetailsN.Onairvip = 0 OR CandidateDetailsN.Onairvip IS NULL)";

            SqlCommand cmd12 = new SqlCommand(sql12, con);
                SqlDataAdapter ad12 = new SqlDataAdapter(cmd12);
                DataTable dt12 = new DataTable();
                ad12.Fill(dt12);
                GridView1.DataSource = dt12;
                GridView1.DataBind();
                Session["check"] = dt12;
            }
            else if (DropDownList1.SelectedItem.Value == "--Select--")
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        public void bindd21()
        {
        string sql12 = "SELECT CandidateDetailsN.Id, CandidateDetailsN.Stateid, " +
"StateMaster.Statename, CandidateDetailsN.Constituencyid, " +
"ConstituencyFive.Constituencyname, CandidateDetailsN.CantiName, " +
"CandidateDetailsN.Status, CandidateDetailsN.Statusid, CandidateDetailsN.Onair " +
"FROM StateMaster " +
"INNER JOIN ConstituencyFive ON StateMaster.id = ConstituencyFive.Stateid " +
"INNER JOIN CandidateDetailsN ON ConstituencyFive.Id = CandidateDetailsN.Constituencyid " +
"WHERE CandidateDetailsN.Stateid='" + DropDownList1.SelectedValue + "' " +
"AND CandidateDetailsN.Districtid='" + DropDownList2.SelectedValue + "' " +
"AND CandidateDetailsN.Isvip = 1 " +
"AND (CandidateDetailsN.Onairvip = 1 OR CandidateDetailsN.Onairvip IS NULL)";

        SqlCommand cmd12 = new SqlCommand(sql12, con);
            SqlDataAdapter ad12 = new SqlDataAdapter(cmd12);
            DataTable dtq12 = new DataTable();
            ad12.Fill(dtq12);
            GridView2.DataSource = dtq12;
            GridView2.DataBind();
            Session["checkq"] = dtq12;
        }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        district();
        con.Close();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        get();
        bindd();
        bindd21();
        con.Close();
    }

}

