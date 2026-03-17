using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public partial class DistrictWiseVote_1 : System.Web.UI.Page
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
                grid();
                grid1();
                grid2();
                grid3();
                grid4();

            }
            con.Close();
        }
        public void grid()
        {
            string sql = "select * from DistrictWiseBug where idd='" + 1 + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["aupdate"] = dt;
            }
        }
        public void grid1()
        {
            string sql1 = "select * from DistrictWiseBug where idd='" + 2 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                Session["bupdate"] = dt1;
            }
        }
        public void grid2()
        {
            string sql2 = "select * from DistrictWiseBug where idd='" + 3 + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                GridView3.DataSource = dt2;
                GridView3.DataBind();
                Session["cupdate"] = dt2;
            }
        }
        public void grid3()
        {
            string sql3 = "select * from DistrictWiseBug where idd='" + 4 + "'";
            SqlCommand cmd3 = new SqlCommand(sql3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                GridView4.DataSource = dt3;
                GridView4.DataBind();
                Session["dupdate"] = dt3;
            }
        }
        public void grid4()
        {
            string sql4 = "select * from DistrictWiseBug where idd='" + 5 + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                GridView5.DataSource = dt4;
                GridView5.DataBind();
                Session["eupdate"] = dt4;
            }
        }

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt = (DataTable)Session["aupdate"];
        Session["aupdate"] = dt;
        int totalseats = 0;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string textbox = "";

            string t1 = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TextBox1")).Text;
            if (string.IsNullOrEmpty(t1))
            {
                textbox = GridView1.Rows[i].Cells[2].Text;
            }
            else
            {
                textbox = t1;
            }
            if (textbox != "" && textbox != " " && textbox != null)
            {
                totalseats = totalseats + Convert.ToInt32(textbox);
            }

        }

        //getting total seat from state for validation*******

        string sqldata1 = "select Total_Seat from DistrictMaster where Id=1";
        SqlCommand seat = new SqlCommand(sqldata1, con);
        int seatotal = (int)seat.ExecuteScalar();

        if (totalseats <= seatotal)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string key = GridView1.DataKeys[i].Value.ToString();
                string textbox = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TextBox1")).Text;

                if (textbox != "")
                {
                    string update1 = "update DistrictWiseBug set vote='" + textbox + "' where id='" + key + "'";
                    SqlCommand cmd41 = new SqlCommand(update1, con);
                    cmd41.ExecuteNonQuery();
                }

            }
            //bar
            string barheightgd = "select top 1 vote from dbo.DistrictWiseBug where IDD=1 order by vote desc";
            SqlCommand bar = new SqlCommand(barheightgd, con);
            int barvalue = (int)bar.ExecuteScalar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string key = GridView1.DataKeys[i].Value.ToString();
                string New_seat = "select vote from  dbo.DistrictWiseBug  where Id='" + key + "'";
                SqlCommand data = new SqlCommand(New_seat, con);
                int barval = (int)data.ExecuteScalar();
                if (barvalue > 0)
                {
                    int bar1 = (barval * 100) / barvalue;
                    string update11 = "update dbo.DistrictWiseBug  set barheight='" + bar1 + "' where Id='" + key + "'";
                    SqlCommand cmd411 = new SqlCommand(update11, con);
                    cmd411.ExecuteNonQuery();
                }
            }
            //Updating difference and set color by comparing previous seat and new seat***************

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string key = GridView1.DataKeys[i].Value.ToString();
                string seatdata = "select vote from DistrictWiseBug where id='" + key + "'";
                SqlCommand data = new SqlCommand(seatdata, con);
                int newseats = (int)data.ExecuteScalar();

                //string prevdata = "select Pre_yr_seat from DistrictWiseBug where id='" + key + "'";
                string prevdata = "select Pre_yr_seat from StateSeat " + "where Districtid='" + '1' + "' " + "and PartyName=(select PartyName from DistrictWiseBug where Id='" + key + "')";
                SqlCommand data2 = new SqlCommand(prevdata, con);
                int prevseat = (int)data2.ExecuteScalar();

                if (prevseat > newseats)
                {
                    int signvalue1 = prevseat - newseats;
                    string path1 = "-" + Convert.ToString(signvalue1);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowdown.png";
                    string WASPcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string BRAINcolor = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string updatenew1 = "update DistrictWiseBug set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                    cmdnew1.ExecuteNonQuery();
                }
                if (newseats > prevseat)
                {
                    int signvalue11 = newseats - prevseat;
                    string path11 = "+" + Convert.ToString(signvalue11);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor1 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string BRAINcolor1 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string updatenew11 = "update DistrictWiseBug set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "',Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                    cmdnew11.ExecuteNonQuery();
                }
                if (newseats == prevseat)
                {
                    int signvalue21 = newseats - prevseat;
                    string path21 = "0";//null
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor2 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string BRAINcolor2 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string updatenew21 = "update DistrictWiseBug set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                    cmdnew21.ExecuteNonQuery();
                }
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);

        }


        grid();
        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt1 = (DataTable)Session["Bupdate"];
        Session["Bupdate"] = dt1;

        int totalseats = 0;

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string textbox = "";

            string t1 = ((TextBox)GridView2.Rows[i].Cells[0].FindControl("TextBox2")).Text;
            if (string.IsNullOrEmpty(t1))
            {
                textbox = GridView2.Rows[i].Cells[2].Text;
            }
            else
            {
                textbox = t1;
            }
            if (textbox != "" && textbox != " " && textbox != null)
            {
                totalseats = totalseats + Convert.ToInt32(textbox);
            }

        }

        //getting total seat from state for validation*******

        string sqldata1 = "select Total_Seat from DistrictMaster where Id=2";
        SqlCommand seat = new SqlCommand(sqldata1, con);
        int seatotal = (int)seat.ExecuteScalar();

        if (totalseats <= seatotal)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView2.DataKeys[i].Value.ToString();
                string textbox = ((TextBox)GridView2.Rows[i].Cells[0].FindControl("TextBox2")).Text;

                if (textbox != "")
                {
                    string update1 = "update DistrictWiseBug set vote='" + textbox + "' where id='" + key + "'";
                    SqlCommand cmd41 = new SqlCommand(update1, con);
                    cmd41.ExecuteNonQuery();
                }

            }
            //bar
            string barheightgd = "select top 1 vote from dbo.DistrictWiseBug where IDD=2 order by vote desc";
            SqlCommand bar = new SqlCommand(barheightgd, con);
            int barvalue = (int)bar.ExecuteScalar();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView2.DataKeys[i].Value.ToString();
                string New_seat = "select vote from  dbo.DistrictWiseBug  where Id='" + key + "'";
                SqlCommand data = new SqlCommand(New_seat, con);
                int barval = (int)data.ExecuteScalar();
                if (barvalue > 0)
                {
                    int bar1 = (barval * 100) / barvalue;

                    string update11 = "update dbo.DistrictWiseBug  set barheight='" + bar1 + "' where Id='" + key + "'";
                    SqlCommand cmd411 = new SqlCommand(update11, con);
                    cmd411.ExecuteNonQuery();
                }
            }
            //Updating difference and set color by comparing previous seat and new seat***************
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView2.DataKeys[i].Value.ToString();
                string seatdata = "select vote from DistrictWiseBug where id='" + key + "'";
                SqlCommand data = new SqlCommand(seatdata, con);
                int newseats = (int)data.ExecuteScalar();

                //string prevdata = "select Pre_yr_seat from DistrictWiseBug where id='" + key + "'";
                string prevdata = "select Pre_yr_seat from StateSeat " + "where Districtid='" + '2' + "' " + "and PartyName=(select PartyName from DistrictWiseBug where Id='" + key + "')";
                SqlCommand data2 = new SqlCommand(prevdata, con);
                int prevseat = (int)data2.ExecuteScalar();

                if (prevseat > newseats)
                {
                    int signvalue1 = prevseat - newseats;
                    string path1 = "-" + Convert.ToString(signvalue1);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowdown.png";
                    string WASPcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string BRAINcolor = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";

                    string updatenew1 = "update DistrictWiseBug set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                    cmdnew1.ExecuteNonQuery();
                }
                if (newseats > prevseat)
                {
                    int signvalue11 = newseats - prevseat;
                    string path11 = "+" + Convert.ToString(signvalue11);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor1 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string BRAINcolor1 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string updatenew11 = "update DistrictWiseBug set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "' ,Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                    cmdnew11.ExecuteNonQuery();
                }
                if (newseats == prevseat)
                {
                    int signvalue21 = newseats - prevseat;
                    string path21 = "0";//null
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor2 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string BRAINcolor2 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string updatenew21 = "update DistrictWiseBug set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "' ,Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                    cmdnew21.ExecuteNonQuery();
                }
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);

        }
        grid1();
        con.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt1 = (DataTable)Session["Jupdate"];
        Session["Jupdate"] = dt1;

        int totalseats = 0;

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string textbox = "";

            string t1 = ((TextBox)GridView3.Rows[i].Cells[0].FindControl("TextBox3")).Text;
            if (string.IsNullOrEmpty(t1))
            {
                textbox = GridView3.Rows[i].Cells[2].Text;
            }
            else
            {
                textbox = t1;
            }
            if (textbox != "" && textbox != " " && textbox != null)
            {
                totalseats = totalseats + Convert.ToInt32(textbox);
            }

        }

        //getting total seat from state for validation*******

        string sqldata1 = "select Total_Seat from DistrictMaster where Id=3";
        SqlCommand seat = new SqlCommand(sqldata1, con);
        int seatotal = (int)seat.ExecuteScalar();

        if (totalseats <= seatotal)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView3.DataKeys[i].Value.ToString();
                string textbox = ((TextBox)GridView3.Rows[i].Cells[0].FindControl("TextBox3")).Text;

                if (textbox != "")
                {
                    string update1 = "update DistrictWiseBug set vote='" + textbox + "' where id='" + key + "'";
                    SqlCommand cmd41 = new SqlCommand(update1, con);
                    cmd41.ExecuteNonQuery();
                }

            }
            //bar
            string barheightgd = "select top 1 vote from dbo.DistrictWiseBug where IDD=3 order by vote desc";
            SqlCommand bar = new SqlCommand(barheightgd, con);
            int barvalue = (int)bar.ExecuteScalar();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView3.DataKeys[i].Value.ToString();
                string New_seat = "select vote from  dbo.DistrictWiseBug  where Id='" + key + "'";
                SqlCommand data = new SqlCommand(New_seat, con);
                int barval = (int)data.ExecuteScalar();
                if (barvalue > 0)
                {
                    int bar1 = (barval * 100) / barvalue;

                    string update11 = "update dbo.DistrictWiseBug  set barheight='" + bar1 + "' where Id='" + key + "'";
                    SqlCommand cmd411 = new SqlCommand(update11, con);
                    cmd411.ExecuteNonQuery();
                }
            }
            //Updating difference and set color by comparing previous seat and new seat***************

            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                string key = GridView3.DataKeys[i].Value.ToString();
                string seatdata = "select vote from DistrictWiseBug where id='" + key + "'";
                SqlCommand data = new SqlCommand(seatdata, con);
                int newseats = (int)data.ExecuteScalar();

                //string prevdata = "select Pre_yr_seat from DistrictWiseBug where id='" + key + "'";
                string prevdata = "select Pre_yr_seat from StateSeat " + "where Districtid='" + '3' + "' " + "and PartyName=(select PartyName from DistrictWiseBug where Id='" + key + "')";
                SqlCommand data2 = new SqlCommand(prevdata, con);
                int prevseat = (int)data2.ExecuteScalar();

                if (prevseat > newseats)
                {
                    int signvalue1 = prevseat - newseats;
                    string path1 = "-" + Convert.ToString(signvalue1);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowdown.png";
                    string WASPcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string BRAINcolor = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string updatenew1 = "update DistrictWiseBug set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                    cmdnew1.ExecuteNonQuery();
                }
                if (newseats > prevseat)
                {
                    int signvalue11 = newseats - prevseat;
                    string path11 = "+" + Convert.ToString(signvalue11);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor1 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string BRAINcolor1 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string updatenew11 = "update DistrictWiseBug set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                    cmdnew11.ExecuteNonQuery();
                }
                if (newseats == prevseat)
                {
                    int signvalue21 = newseats - prevseat;
                    string path21 = "0";//null
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor2 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string BRAINcolor2 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string updatenew21 = "update DistrictWiseBug set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                    cmdnew21.ExecuteNonQuery();
                }
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);

        }
        grid2();
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt1 = (DataTable)Session["Mupdate"];
        Session["Mupdate"] = dt1;

        int totalseats = 0;

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string textbox = "";

            string t1 = ((TextBox)GridView4.Rows[i].Cells[0].FindControl("TextBox4")).Text;
            if (string.IsNullOrEmpty(t1))
            {
                textbox = GridView4.Rows[i].Cells[2].Text;
            }
            else
            {
                textbox = t1;
            }
            if (textbox != "" && textbox != " " && textbox != null)
            {
                totalseats = totalseats + Convert.ToInt32(textbox);
            }

        }

        //getting total seat from state for validation*******

        string sqldata1 = "select Total_Seat from DistrictMaster where Id=4";
        SqlCommand seat = new SqlCommand(sqldata1, con);
        int seatotal = (int)seat.ExecuteScalar();

        if (totalseats <= seatotal)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView4.DataKeys[i].Value.ToString();
                string textbox = ((TextBox)GridView4.Rows[i].Cells[0].FindControl("TextBox4")).Text;

                if (textbox != "")
                {
                    string update1 = "update DistrictWiseBug set vote='" + textbox + "' where id='" + key + "'";
                    SqlCommand cmd41 = new SqlCommand(update1, con);
                    cmd41.ExecuteNonQuery();
                }

            }
            //bar
            string barheightgd = "select top 1 vote from dbo.DistrictWiseBug where IDD=4 order by vote desc";
            SqlCommand bar = new SqlCommand(barheightgd, con);
            int barvalue = (int)bar.ExecuteScalar();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView4.DataKeys[i].Value.ToString();
                string New_seat = "select vote from  dbo.DistrictWiseBug  where Id='" + key + "'";
                SqlCommand data = new SqlCommand(New_seat, con);
                int barval = (int)data.ExecuteScalar();
                if (barvalue > 0)
                {
                    int bar1 = (barval * 100) / barvalue;

                    string update11 = "update dbo.DistrictWiseBug  set barheight='" + bar1 + "' where Id='" + key + "'";
                    SqlCommand cmd411 = new SqlCommand(update11, con);
                    cmd411.ExecuteNonQuery();
                }
            }
            //Updating difference and set color by comparing previous seat and new seat***************
            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                string key = GridView4.DataKeys[i].Value.ToString();
                string seatdata = "select vote from DistrictWiseBug where id='" + key + "'";
                SqlCommand data = new SqlCommand(seatdata, con);
                int newseats = (int)data.ExecuteScalar();

                //string prevdata = "select Pre_yr_seat from DistrictWiseBug where id='" + key + "'";
                string prevdata ="select Pre_yr_seat from StateSeat " +"where Districtid='" + '4' + "' " +"and PartyName=(select PartyName from DistrictWiseBug where Id='" + key + "')";
                SqlCommand data2 = new SqlCommand(prevdata, con);
                int prevseat = (int)data2.ExecuteScalar();

                if (prevseat > newseats)
                {
                    int signvalue1 = prevseat - newseats;
                    string path1 = "-" + Convert.ToString(signvalue1);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowdown.png";
                    string WASPcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string BRAINcolor = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string updatenew1 = "update DistrictWiseBug set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "',Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                    cmdnew1.ExecuteNonQuery();
                }
                if (newseats > prevseat)
                {
                    int signvalue11 = newseats - prevseat;
                    string path11 = "+" + Convert.ToString(signvalue11);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor1 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string BRAINcolor1 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string updatenew11 = "update DistrictWiseBug set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "',Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                    cmdnew11.ExecuteNonQuery();
                }
                if (newseats == prevseat)
                {
                    int signvalue21 = newseats - prevseat;
                    string path21 = "0";//null
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor2 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string BRAINcolor2 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string updatenew21 = "update DistrictWiseBug set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "',Arrow='" + Arrowcolor + "' where Id='" + key + "'";
                    SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                    cmdnew21.ExecuteNonQuery();
                }
            }

        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);

        }

        grid3();
        con.Close();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt1 = (DataTable)Session["Cupdate"];
        Session["Cupdate"] = dt1;

        int totalseats = 0;

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string textbox = "";

            string t1 = ((TextBox)GridView5.Rows[i].Cells[0].FindControl("TextBox5")).Text;
            if (string.IsNullOrEmpty(t1))
            {
                textbox = GridView5.Rows[i].Cells[2].Text;
            }
            else
            {
                textbox = t1;
            }
            if (textbox != "" && textbox != " " && textbox != null)
            {
                totalseats = totalseats + Convert.ToInt32(textbox);
            }

        }


        //getting total seat from state for validation*******

        string sqldata1 = "select Total_Seat from DistrictMaster where Id=5";
        SqlCommand seat = new SqlCommand(sqldata1, con);
        int seatotal = (int)seat.ExecuteScalar();

        if (totalseats <= seatotal)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView5.DataKeys[i].Value.ToString();
                string textbox = ((TextBox)GridView5.Rows[i].Cells[0].FindControl("TextBox5")).Text;

                if (textbox != "")
                {
                    string update1 = "update DistrictWiseBug set vote='" + textbox + "' where id='" + key + "'";
                    SqlCommand cmd41 = new SqlCommand(update1, con);
                    cmd41.ExecuteNonQuery();
                }

            }
            //bar
            string barheightgd = "select top 1 vote from dbo.DistrictWiseBug where IDD=5 order by vote desc";
            SqlCommand bar = new SqlCommand(barheightgd, con);
            int barvalue = (int)bar.ExecuteScalar();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView5.DataKeys[i].Value.ToString();
                string New_seat = "select vote from  dbo.DistrictWiseBug  where Id='" + key + "'";
                SqlCommand data = new SqlCommand(New_seat, con);
                int barval = (int)data.ExecuteScalar();
                if (barvalue > 0)
                {
                    int bar1 = (barval * 100) / barvalue;

                    string update11 = "update dbo.DistrictWiseBug  set barheight='" + bar1 + "' where Id='" + key + "'";
                    SqlCommand cmd411 = new SqlCommand(update11, con);
                    cmd411.ExecuteNonQuery();
                }
            }
            //Updating difference and set color by comparing previous seat and new seat***************
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string key = GridView5.DataKeys[i].Value.ToString();
                string seatdata = "select vote from DistrictWiseBug where id='" + key + "'";
                SqlCommand data = new SqlCommand(seatdata, con);
                int newseats = (int)data.ExecuteScalar();

                //string prevdata = "select Pre_yr_seat from DistrictWiseBug where id='" + key + "'";
                string prevdata = "select Pre_yr_seat from StateSeat " + "where Districtid='" + '5' + "' " + "and PartyName=(select PartyName from DistrictWiseBug where Id='" + key + "')";
                SqlCommand data2 = new SqlCommand(prevdata, con);
                int prevseat = (int)data2.ExecuteScalar();

                if (prevseat > newseats)
                {
                    int signvalue1 = prevseat - newseats;
                    string path1 = "-" + Convert.ToString(signvalue1);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowdown.png";
                    string WASPcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string BRAINcolor = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\RED.png";
                    string updatenew1 = "update DistrictWiseBug set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                    cmdnew1.ExecuteNonQuery();
                }
                if (newseats > prevseat)
                {
                    int signvalue11 = newseats - prevseat;
                    string path11 = "+" + Convert.ToString(signvalue11);
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor1 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string BRAINcolor1 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\DARK_GREEN.png";
                    string updatenew11 = "update DistrictWiseBug set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                    cmdnew11.ExecuteNonQuery();
                }
                if (newseats == prevseat)
                {
                    int signvalue21 = newseats - prevseat;
                    string path21 = "0";//null
                    string Arrowcolor = @"X:\2025\ELECTION\PANCHAYATH\Arrow\Arrowup.png";
                    string stcolor2 = @"X:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string BRAINcolor2 = @"Y:\2025\ELECTION\PANCHAYATH\Arrow\GREY.png";
                    string updatenew21 = "update DistrictWiseBug set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "',Arrow='" + Arrowcolor + "'  where Id='" + key + "'";
                    SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                    cmdnew21.ExecuteNonQuery();
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);

        }
        grid4();
        con.Close();
    }
}


