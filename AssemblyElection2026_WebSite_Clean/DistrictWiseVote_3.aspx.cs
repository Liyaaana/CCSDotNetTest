using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistrictWiseVote_3 : System.Web.UI.Page
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
            //grid4();

        }
        con.Close();
    }
    public void grid()
    {
        string sql = "select * from DistrictWiseBug where idd='" + 11 + "'";
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
        string sql1 = "select * from DistrictWiseBug where idd='" + 12 + "'";
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
        string sql2 = "select * from DistrictWiseBug where idd='" + 13 + "'";
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
        string sql3 = "select * from DistrictWiseBug where idd='" + 14 + "'";
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
    //public void grid4()
    //{
    //    string sql4 = "select * from DistrictWiseBug where idd='" + 15 + "'";
    //    SqlCommand cmd4 = new SqlCommand(sql4, con);
    //    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
    //    DataTable dt4 = new DataTable();
    //    da4.Fill(dt4);
    //    if (dt4.Rows.Count > 0)
    //    {
    //        GridView5.DataSource = dt4;
    //        GridView5.DataBind();
    //        Session["eupdate"] = dt4;
    //    }
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        get();
        DataTable dt = (DataTable)Session["aupdate"];
        Session["aupdate"] = dt;
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            string key = GridView1.DataKeys[j].Values[0].ToString();
            string textbox = ((TextBox)GridView1.Rows[j].Cells[0].FindControl("TextBox1")).Text;
            int voteValue = 0;
            int.TryParse(textbox, out voteValue);
            if (textbox != "")
            {
                //string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
                string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictWiseBug where idd=1 order by vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                //int bvalue = Convert.ToInt32(ddt.Rows[0][2]);
                int bvalue = 0;
                if (ddt.Rows.Count > 0 && ddt.Rows[0][2] != DBNull.Value)
                {
                    int.TryParse(ddt.Rows[0][2].ToString(), out bvalue);
                }

                string barheight1 = "select * from DistrictWiseBug where idd=1  ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                //int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                //int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                //int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                //int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);
                int bar1 = 0, bar2 = 0, bar3 = 0, bar4 = 0;

                if (ddt1.Rows.Count > 0 && ddt1.Rows[0][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[0][2].ToString(), out bar1);

                if (ddt1.Rows.Count > 1 && ddt1.Rows[1][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[1][2].ToString(), out bar2);

                if (ddt1.Rows.Count > 2 && ddt1.Rows[2][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[2][2].ToString(), out bar3);

                if (ddt1.Rows.Count > 3 && ddt1.Rows[3][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[3][2].ToString(), out bar4);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictWiseBug set barheight='" + barvalue + "' where id='" + 41 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictWiseBug set barheight='" + barvalue1 + "' where id='" + 42 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictWiseBug set barheight='" + barvalue2 + "' where id='" + 43 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictWiseBug set barheight='" + barvalue3 + "' where id='" + 44 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();


                    //DistrictWiseBug
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
            int voteValue = 0;
            int.TryParse(textbox, out voteValue);
            if (textbox != "")
            {
                string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictWiseBug where idd=2 order by vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                //int bvalue = Convert.ToInt32(ddt.Rows[0][2]);
                int bvalue = 0;
                if (ddt.Rows.Count > 0 && ddt.Rows[0][2] != DBNull.Value)
                {
                    int.TryParse(ddt.Rows[0][2].ToString(), out bvalue);
                }
                string barheight1 = "select * from DistrictWiseBug where idd=2 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                //int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                //int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                //int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                //int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);
                int bar1 = 0, bar2 = 0, bar3 = 0, bar4 = 0;

                if (ddt1.Rows.Count > 0 && ddt1.Rows[0][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[0][2].ToString(), out bar1);

                if (ddt1.Rows.Count > 1 && ddt1.Rows[1][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[1][2].ToString(), out bar2);

                if (ddt1.Rows.Count > 2 && ddt1.Rows[2][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[2][2].ToString(), out bar3);

                if (ddt1.Rows.Count > 3 && ddt1.Rows[3][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[3][2].ToString(), out bar4);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictWiseBug set barheight='" + barvalue + "' where id='" + 45 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictWiseBug set barheight='" + barvalue1 + "' where id='" + 46 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictWiseBug set barheight='" + barvalue2 + "' where id='" + 47 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictWiseBug set barheight='" + barvalue3 + "' where id='" + 48 + "'";
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
            int voteValue = 0;
            int.TryParse(textbox, out voteValue);
            if (textbox != "")
            {
                string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictWiseBug where idd=3 order by vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                //int bvalue = Convert.ToInt32(ddt.Rows[0][2]);
                int bvalue = 0;
                if (ddt.Rows.Count > 0 && ddt.Rows[0][2] != DBNull.Value)
                {
                    int.TryParse(ddt.Rows[0][2].ToString(), out bvalue);
                }

                string barheight1 = "select * from DistrictWiseBug where idd=3 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                //int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                //int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                //int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                //int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);
                int bar1 = 0, bar2 = 0, bar3 = 0, bar4 = 0;

                if (ddt1.Rows.Count > 0 && ddt1.Rows[0][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[0][2].ToString(), out bar1);

                if (ddt1.Rows.Count > 1 && ddt1.Rows[1][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[1][2].ToString(), out bar2);

                if (ddt1.Rows.Count > 2 && ddt1.Rows[2][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[2][2].ToString(), out bar3);

                if (ddt1.Rows.Count > 3 && ddt1.Rows[3][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[3][2].ToString(), out bar4);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictWiseBug set barheight='" + barvalue + "' where id='" + 49 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictWiseBug set barheight='" + barvalue1 + "' where id='" + 50 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictWiseBug set barheight='" + barvalue2 + "' where id='" + 51 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictWiseBug set barheight='" + barvalue3 + "' where id='" + 52 + "'";
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
            int voteValue = 0;
            int.TryParse(textbox, out voteValue);
            if (textbox != "")
            {
                string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
                SqlCommand cmd4 = new SqlCommand(update, con);
                cmd4.ExecuteNonQuery();

                string barheight = "select top 1 * from DistrictWiseBug where idd=6 order by vote desc";
                SqlCommand co = new SqlCommand(barheight, con);
                SqlDataAdapter dta = new SqlDataAdapter(co);
                DataTable ddt = new DataTable();
                dta.Fill(ddt);
                //int bvalue = Convert.ToInt32(ddt.Rows[0][2]);
                int bvalue = 0;
                if (ddt.Rows.Count > 0 && ddt.Rows[0][2] != DBNull.Value)
                {
                    int.TryParse(ddt.Rows[0][2].ToString(), out bvalue);
                }

                string barheight1 = "select * from DistrictWiseBug where idd=6 ";
                SqlCommand co1 = new SqlCommand(barheight1, con);
                SqlDataAdapter dta1 = new SqlDataAdapter(co1);
                DataTable ddt1 = new DataTable();
                dta1.Fill(ddt1);
                //int bar1 = Convert.ToInt32(ddt1.Rows[0][2]);
                //int bar2 = Convert.ToInt32(ddt1.Rows[1][2]);
                //int bar3 = Convert.ToInt32(ddt1.Rows[2][2]);
                //int bar4 = Convert.ToInt32(ddt1.Rows[3][2]);
                int bar1 = 0, bar2 = 0, bar3 = 0, bar4 = 0;

                if (ddt1.Rows.Count > 0 && ddt1.Rows[0][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[0][2].ToString(), out bar1);

                if (ddt1.Rows.Count > 1 && ddt1.Rows[1][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[1][2].ToString(), out bar2);

                if (ddt1.Rows.Count > 2 && ddt1.Rows[2][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[2][2].ToString(), out bar3);

                if (ddt1.Rows.Count > 3 && ddt1.Rows[3][2] != DBNull.Value)
                    int.TryParse(ddt1.Rows[3][2].ToString(), out bar4);

                if (bvalue != 0)
                {
                    int barvalue = (bar1 * 100) / bvalue;
                    int barvalue1 = (bar2 * 100) / bvalue;
                    int barvalue2 = (bar3 * 100) / bvalue;
                    int barvalue3 = (bar4 * 100) / bvalue;

                    string update10 = "update DistrictWiseBug set barheight='" + barvalue + "' where id='" + 53 + "'";
                    SqlCommand cmd410 = new SqlCommand(update10, con);
                    cmd410.ExecuteNonQuery();

                    string update20 = "update DistrictWiseBug set barheight='" + barvalue1 + "' where id='" + 54 + "'";
                    SqlCommand cmd420 = new SqlCommand(update20, con);
                    cmd420.ExecuteNonQuery();

                    string update30 = "update DistrictWiseBug set barheight='" + barvalue2 + "' where id='" + 55 + "'";
                    SqlCommand cmd430 = new SqlCommand(update30, con);
                    cmd430.ExecuteNonQuery();

                    string update31 = "update DistrictWiseBug set barheight='" + barvalue3 + "' where id='" + 56 + "'";
                    SqlCommand cmd431 = new SqlCommand(update31, con);
                    cmd431.ExecuteNonQuery();

                }

            }
        }
        grid3();
        con.Close();
    }
    //protected void Button5_Click(object sender, EventArgs e)
    //{
    //    get();
    //    DataTable dt4 = (DataTable)Session["eupdate"];
    //    Session["eupdate"] = dt4;
    //    for (int j = 0; j < dt4.Rows.Count; j++)
    //    {
    //        string key = GridView5.DataKeys[j].Values[0].ToString();
    //        string textbox = ((TextBox)GridView5.Rows[j].Cells[0].FindControl("TextBox5")).Text;
    //        int voteValue = 0;
    //        int.TryParse(textbox, out voteValue);
    //        if (textbox != "")
    //        {
    //            string update = "update DistrictWiseBug set vote='" + voteValue + "' where id='" + key + "'";
    //            SqlCommand cmd4 = new SqlCommand(update, con);
    //            cmd4.ExecuteNonQuery();

    //            string barheight = "select top 1 * from DistrictWiseBug where idd=7 order by vote desc";
    //            SqlCommand co = new SqlCommand(barheight, con);
    //            SqlDataAdapter dta = new SqlDataAdapter(co);
    //            DataTable ddt = new DataTable();
    //            dta.Fill(ddt);
    //            //int bvalue = Convert.ToInt32(ddt.Rows[0][2]);
    //            int bvalue = 0;
    //            if (ddt.Rows.Count > 0 && ddt.Rows[0][2] != DBNull.Value)
    //            {
    //                int.TryParse(ddt.Rows[0][2].ToString(), out bvalue);
    //            }

    //            string barheight1 = "select * from DistrictWiseBug where idd=7 ";
    //            SqlCommand co1 = new SqlCommand(barheight1, con);
    //            SqlDataAdapter dta1 = new SqlDataAdapter(co1);
    //            DataTable ddt1 = new DataTable();
    //            dta1.Fill(ddt1);
    //            int bar1 = 0, bar2 = 0, bar3 = 0, bar4 = 0;

    //            if (ddt1.Rows.Count > 0 && ddt1.Rows[0][2] != DBNull.Value)
    //                int.TryParse(ddt1.Rows[0][2].ToString(), out bar1);

    //            if (ddt1.Rows.Count > 1 && ddt1.Rows[1][2] != DBNull.Value)
    //                int.TryParse(ddt1.Rows[1][2].ToString(), out bar2);

    //            if (ddt1.Rows.Count > 2 && ddt1.Rows[2][2] != DBNull.Value)
    //                int.TryParse(ddt1.Rows[2][2].ToString(), out bar3);

    //            if (ddt1.Rows.Count > 3 && ddt1.Rows[3][2] != DBNull.Value)
    //                int.TryParse(ddt1.Rows[3][2].ToString(), out bar4);


    //            if (bvalue != 0)
    //            {
    //                int barvalue = (bar1 * 100) / bvalue;
    //                int barvalue1 = (bar2 * 100) / bvalue;
    //                int barvalue2 = (bar3 * 100) / bvalue;
    //                int barvalue3 = (bar4 * 100) / bvalue;

    //                string update10 = "update DistrictWiseBug set barheight='" + barvalue + "' where id='" + 57 + "'";
    //                SqlCommand cmd410 = new SqlCommand(update10, con);
    //                cmd410.ExecuteNonQuery();

    //                string update20 = "update DistrictWiseBug set barheight='" + barvalue1 + "' where id='" + 58 + "'";
    //                SqlCommand cmd420 = new SqlCommand(update20, con);
    //                cmd420.ExecuteNonQuery();

    //                string update30 = "update DistrictWiseBug set barheight='" + barvalue2 + "' where id='" + 59 + "'";
    //                SqlCommand cmd430 = new SqlCommand(update30, con);
    //                cmd430.ExecuteNonQuery();

    //                string update31 = "update DistrictWiseBug set barheight='" + barvalue3 + "' where id='" + 60 + "'";
    //                SqlCommand cmd431 = new SqlCommand(update31, con);
    //                cmd431.ExecuteNonQuery();

    //            }

    //        }
    //    }
    //    grid4();
    //    con.Close();
    //}
}