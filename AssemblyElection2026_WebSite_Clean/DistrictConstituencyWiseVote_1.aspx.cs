using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistrictConstituencyLead : System.Web.UI.Page
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
        string sql = "select * from DistrictConstituencyVote where Districtid='" + 1 + "'";
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
        string sql1 = "select * from DistrictConstituencyVote where Districtid='" + 2 + "'";
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
        string sql2 = "select * from DistrictConstituencyVote where Districtid='" + 3 + "'";
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
        string sql3 = "select * from DistrictConstituencyVote where Districtid='" + 4 + "'";
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
        string sql4 = "select * from DistrictConstituencyVote where Districtid='" + 5 + "'";
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
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            string key = GridView1.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView1.Rows[j].Cells[0].FindControl("TextBox1")).Text;
            if (textbox != "")
            {
                string update = "update DistrictConstituencyVote set Vote='" + textbox + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictConstituencyVote where Districtid=1 order by Vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                int bvalue = Convert.ToInt32(ddt.Rows[0][2]);

                string barheight1 = "select * from DistrictConstituencyVote where Districtid=1  ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictConstituencyVote set barheight='" + barvalue + "' where id='" + 1 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictConstituencyVote set barheight='" + barvalue1 + "' where id='" + 2 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictConstituencyVote set barheight='" + barvalue2 + "' where id='" + 3 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictConstituencyVote set barheight='" + barvalue3 + "' where id='" + 4 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();


                    //DistrictConstituencyVote
                }

            }

        }
        grid();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt1 = (DataTable)Session["bupdate"];
        Session["bupdate"] = dt1;
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string key = GridView2.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView2.Rows[j].Cells[0].FindControl("TextBox2")).Text;
            if (textbox != "")
            {
                string update = "update DistrictConstituencyVote set Vote='" + textbox + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictConstituencyVote where Districtid=2 order by Vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                int bvalue = Convert.ToInt32(ddt.Rows[0][2]);

                string barheight1 = "select * from DistrictConstituencyVote where Districtid=2 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictConstituencyVote set barheight='" + barvalue + "' where id='" + 5 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictConstituencyVote set barheight='" + barvalue1 + "' where id='" + 6 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictConstituencyVote set barheight='" + barvalue2 + "' where id='" + 7 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictConstituencyVote set barheight='" + barvalue3 + "' where id='" + 8 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();

                }
            }
        }
        grid1();
        con.Close();
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt2 = (DataTable)Session["cupdate"];
        Session["cupdate"] = dt2;
        for (int j = 0; j < dt2.Rows.Count; j++)
        {
            string key = GridView3.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView3.Rows[j].Cells[0].FindControl("TextBox3")).Text;
            if (textbox != "")
            {
                string update = "update DistrictConstituencyVote set Vote='" + textbox + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictConstituencyVote where Districtid=3 order by Vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                int bvalue = Convert.ToInt32(ddt.Rows[0][2]);

                string barheight1 = "select * from DistrictConstituencyVote where Districtid=3 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictConstituencyVote set barheight='" + barvalue + "' where id='" + 9 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictConstituencyVote set barheight='" + barvalue1 + "' where id='" + 10 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictConstituencyVote set barheight='" + barvalue2 + "' where id='" + 11 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictConstituencyVote set barheight='" + barvalue3 + "' where id='" + 12 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();

                }
            }
        }
        grid2();
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt3 = (DataTable)Session["dupdate"];
        Session["dupdate"] = dt3;
        for (int j = 0; j < dt3.Rows.Count; j++)
        {
            string key = GridView4.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView4.Rows[j].Cells[0].FindControl("TextBox4")).Text;
            if (textbox != "")
            {
                string update = "update DistrictConstituencyVote set Vote='" + textbox + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictConstituencyVote where Districtid=4 order by Vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                int bvalue = Convert.ToInt32(ddt.Rows[0][2]);

                string barheight1 = "select * from DistrictConstituencyVote where Districtid=4 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictConstituencyVote set barheight='" + barvalue + "' where id='" + 13 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictConstituencyVote set barheight='" + barvalue1 + "' where id='" + 14 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictConstituencyVote set barheight='" + barvalue2 + "' where id='" + 15 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictConstituencyVote set barheight='" + barvalue3 + "' where id='" + 16 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();

                }

            }
        }
        grid3();
        con.Close();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt4 = (DataTable)Session["eupdate"];
        Session["eupdate"] = dt4;
        for (int j = 0; j < dt4.Rows.Count; j++)
        {
            string key = GridView5.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView5.Rows[j].Cells[0].FindControl("TextBox5")).Text;
            if (textbox != "")
            {
                string update = "update DistrictConstituencyVote set Vote='" + textbox + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictConstituencyVote where Districtid=5 order by Vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                int bvalue = Convert.ToInt32(ddt.Rows[0][2]);

                string barheight1 = "select * from DistrictConstituencyVote where Districtid=5 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictConstituencyVote set barheight='" + barvalue + "' where id='" + 17 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictConstituencyVote set barheight='" + barvalue1 + "' where id='" + 18 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictConstituencyVote set barheight='" + barvalue2 + "' where id='" + 19 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictConstituencyVote set barheight='" + barvalue3 + "' where id='" + 20 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();

                }

            }
        }
        grid4();
        con.Close();
    }
}
