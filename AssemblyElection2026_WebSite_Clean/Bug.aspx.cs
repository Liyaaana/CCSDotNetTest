using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


    public partial class Bug : System.Web.UI.Page
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

                Bihar();
                // NDA();
                // INDIA();

            }
            con.Close();
        }
        //Page redirection
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddParty.aspx");
        }



        // 1)Bihar BUG
        public void Bihar()
        {
            string sqldata = "select *from StateSeat where Stateid=1";
            SqlCommand cmde = new SqlCommand(sqldata, con);
            SqlDataAdapter data = new SqlDataAdapter(cmde);
            DataTable dttt = new DataTable();
            data.Fill(dttt);
            BhGridView.DataSource = dttt;
            BhGridView.DataBind();
            Session["BhDATA"] = dttt;
        }

    // Safe Conversion Method
    private int SafeToInt(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        int number;
        if (int.TryParse(value.ToString(), out number))
            return number;

        return 0;
    }

    private double SafeToDouble(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        double number;
        if (double.TryParse(value.ToString(), out number))
            return number;

        return 0;
    }


    protected void BhBtn_Click(object sender, EventArgs e)
        {
            get();
            DataTable dttt = (DataTable)Session["BhDATA"];
            Session["BhDATA"] = dttt;
            int totalseats = 0;

            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                string textbox = "";
                string t1 = ((TextBox)BhGridView.Rows[i].Cells[0].FindControl("txtBh1")).Text;
                if (string.IsNullOrEmpty(t1))
                {
                    textbox = BhGridView.Rows[i].Cells[2].Text;
                }
                else
                {
                    textbox = t1;
                }
                int number;

                if (int.TryParse(textbox.Trim(), out number))
                {
                    totalseats += number;
                }
            }


            //getting total seat from state for validation*******

            string sqldata1 = "select Total_Seat from StateMaster where Id=1";
            SqlCommand seat = new SqlCommand(sqldata1, con);
            // int seatotal = SafeToInt(seat.ExecuteScalar());
            int seatotal = SafeToInt(seat.ExecuteScalar());
            if (totalseats <= seatotal)
            {
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    string key = BhGridView.DataKeys[i].Value.ToString();
                    string textbox = ((TextBox)BhGridView.Rows[i].Cells[0].FindControl("txtBh1")).Text;
                    //***********
                    //string textbox1 = ((TextBox)jkGridView.Rows[i].Cells[1].FindControl("txtJK2")).Text;

                    if (textbox != "")
                    {
                        string update1 = "update StateSeat set New_seat='" + textbox + "' where id='" + key + "'";
                        SqlCommand cmd41 = new SqlCommand(update1, con);
                        cmd41.ExecuteNonQuery();
                    }

                    //***************************************
                    //if (textbox1 != "")
                    //{
                    //    string update1 = "update StateSeat set Voteshare='" + textbox1 + "' where Id='" + key + "'";
                    //    SqlCommand cmd41 = new SqlCommand(update1, con);
                    //    cmd41.ExecuteNonQuery();
                    //}
                    /***************************/
                }

                //Updating difference and set color by comparing previous seat and new seat***************
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    string key = BhGridView.DataKeys[i].Value.ToString();
                    string seatdata = "select New_seat from StateSeat where id='" + key + "'";
                    SqlCommand data = new SqlCommand(seatdata, con);
                
                // int newseats = (int)data.ExecuteScalar();  // below safe line is given to avoid crash
                object result = data.ExecuteScalar();
                int newseats = 0;

                if (result != null && result != DBNull.Value)
                {
                    int.TryParse(result.ToString(), out newseats);
                }
                //

                string prevdata = "select Pre_yr_seat from StateSeat where id='" + key + "'";
                    SqlCommand data2 = new SqlCommand(prevdata, con);
                
                // int prevseat = (int)data2.ExecuteScalar(); // safe line is given below to avoid crash
                object result2 = data2.ExecuteScalar();
                int prevseat = 0;

                if (result2 != null && result2 != DBNull.Value)
                {
                    int.TryParse(result2.ToString(), out prevseat);
                }
                //

                if (prevseat > newseats)
                    {
                        int signvalue1 = prevseat - newseats;
                        string path1 = "-" + Convert.ToString(signvalue1);
                        string WASPcolor = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\RED.png";
                        string BRAINcolor = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
                        // string updatenew1 = "update Chhattisgarh_seat2023 set difference='" + path1 + "',color='" + stcolor1 + "' where id='" + 1 + "'";
                        string updatenew1 = "update StateSeat set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "' where Id='" + key + "'";
                        SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
                        cmdnew1.ExecuteNonQuery();
                    }
                    if (newseats > prevseat)
                    {
                        int signvalue11 = newseats - prevseat;
                        string path11 = "+" + Convert.ToString(signvalue11);
                        string stcolor1 = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\GREEN.png";
                        string BRAINcolor1 = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
                        // string updatenew11 = "update karnataka_seat2023 set difference='" + path11 + "',color='" + stcolor + "' where id='" + 1 + "'";
                        string updatenew11 = "update StateSeat set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "' where Id='" + key + "'";
                        SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
                        cmdnew11.ExecuteNonQuery();
                    }
                    if (newseats == prevseat)
                    {
                        int signvalue21 = newseats - prevseat;
                        string path21 = "0";//null
                        string stcolor2 = @"X:\Wasp3d\LOKSABHA_2019\TEXTURE\PARTY_COLOR\GREY.png";
                        string BRAINcolor2 = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.png";
                        // string updatenew21 = "update Chhattisgarh_seat2023 set difference='" + path21 + "',color='" + stcolor2 + "'where id='" + 1 + "'";
                        string updatenew21 = "update StateSeat set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "' where Id='" + key + "'";
                        SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
                        cmdnew21.ExecuteNonQuery();
                    }
                }
                //Set barvalue  Sum(total seat)*****************************

                string barheight = "select top 1 New_seat from dbo.StateSeat where Stateid=1 order by New_seat desc";
                SqlCommand bar = new SqlCommand(barheight, con);
                int barvalue = SafeToInt(bar.ExecuteScalar());
                int sum1 = 0;
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    string key = BhGridView.DataKeys[i].Value.ToString();
                    string New_seat = "select New_seat from StateSeat where Id='" + key + "'";
                    SqlCommand data = new SqlCommand(New_seat, con);
                // int barval = (int)data.ExecuteScalar(); // safe line is given below to avoid crash
                int barval = SafeToInt(data.ExecuteScalar());
                //

                sum1 = sum1 + barval;
                    if (sum1 <= seatotal)
                    {
                        string total = "update StateMaster set Seat_count='" + sum1 + "' where Id='" + 1 + "'";
                        SqlCommand Seat_count = new SqlCommand(total, con);
                        Seat_count.ExecuteNonQuery();
                    }

                    if (barvalue > 0)
                    {
                        int bar1 = (barval * 100) / barvalue;

                        string update11 = "update StateSeat set Bar22='" + bar1 + "' where Id='" + key + "'";
                        SqlCommand cmd411 = new SqlCommand(update11, con);
                        cmd411.ExecuteNonQuery();
                    }
                }

                //Set vote share *******************************************************
                double sum = 0;
                double vote = 0;
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    string key = BhGridView.DataKeys[i].Value.ToString();
                    string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key + "'";

                    SqlCommand data = new SqlCommand(TotalVoteshare, con);
                    // vote = Convert.ToInt32(data.ExecuteScalar()); // safe line is given below to avoid crash
                    vote = SafeToDouble(data.ExecuteScalar());
     
                    sum += vote;

                }
                if (sum > 0)
                {
                    // below sectn is commented out by liyana
                    //for (int i = 0; i < dttt.Rows.Count; i++)
                    //{
                    //    string key1 = BhGridView.DataKeys[i].Value.ToString();
                    //    string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key1 + "'";
                    //    SqlCommand data = new SqlCommand(TotalVoteshare, con);
                    //    vote = Convert.ToInt32(data.ExecuteScalar());

                    //    int voteshre1 = (vote * 360) / sum;


                    //    string update111 = "update StateSeat set Pie='" + voteshre1 + "' where Id='" + key1 + "'";
                    //    SqlCommand cmd4111 = new SqlCommand(update111, con);
                    //    cmd4111.ExecuteNonQuery();
                    //}
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);
                // Response.Write("<script>alert('Total seats Exceeded 60');</script>");
            }

            Bihar();
            con.Close();
        }

        protected void BhGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            get();
            string key = BhGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string update = "delete from StateSeat where Id='" + key + "'";
            SqlCommand updatee = new SqlCommand(update, con);
            updatee.ExecuteNonQuery();
            con.Close();
            BhGridView.EditIndex = -1;
            Bihar();
        }

        protected void BhGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            get();
            BhGridView.EditIndex = e.NewEditIndex;
            Bihar();
            con.Close();
        }
        protected void BhGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            get();
            string key = BhGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string p_name = ((TextBox)BhGridView.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

            string update = "update StateSeat set Partyname=N'" + p_name + "' where Id='" + key + "'";
            SqlCommand updatee = new SqlCommand(update, con);
            updatee.ExecuteNonQuery();
            con.Close();
            BhGridView.EditIndex = -1;
            Bihar();
        }
        protected void BhGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            get();
            BhGridView.EditIndex = -1;
            Bihar();
            con.Close();
        }


        // 2)NDA BUG
        //public void NDA()
        //{
        //    string sqldata = "select *from StateSeat where Stateid=2";
        //    SqlCommand cmde = new SqlCommand(sqldata, con);
        //    SqlDataAdapter data = new SqlDataAdapter(cmde);
        //    DataTable dttt = new DataTable();
        //    data.Fill(dttt);
        //    NDAGridView.DataSource = dttt;
        //    NDAGridView.DataBind();
        //    Session["NDADATA"] = dttt;
        //}

        //protected void NDABtn_Click(object sender, EventArgs e)
        //{
        //    get();
        //    DataTable dttt = (DataTable)Session["NDADATA"];
        //    Session["NDADATA"] = dttt;
        //    int totalseats = 0;

        //    for (int i = 0; i < dttt.Rows.Count; i++)
        //    {
        //        string textbox = "";
        //        string t1 = ((TextBox)NDAGridView.Rows[i].Cells[0].FindControl("txtNDA1")).Text;
        //        /* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //        string key = NDAGridView.DataKeys[i].Values[0].ToString(); 
        //        string dropdown = ((DropDownList)NDAGridView.Rows[i].Cells[0].FindControl("DropDownList1")).SelectedItem.Text;
        //        string dropdown1 = ((DropDownList)NDAGridView.Rows[i].Cells[0].FindControl("DropDownList1")).SelectedItem.Value;
        //        string Wasp_path = "";
        //        string Brain_path = "";
        //        if (dropdown1 != "")
        //        {
        //            if (dropdown1 == "1" || dropdown1 == "13")
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\GREEN.png";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
        //            }
        //            else if (dropdown1 == "2" || dropdown1 == "4")
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\RED.png";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
        //            }
        //            else // condn for id = 5
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";


        //                //    string getArrow = "select Arrowcolor from CandidateDetailsN where id='" + key + "'";
        //                //    SqlCommand getCmd = new SqlCommand(getArrow, con);
        //                //    object result = getCmd.ExecuteScalar();
        //                //    if (result != null && result != DBNull.Value)
        //                //    {
        //                //        Wasp_path = result.ToString();
        //                //    }
        //                //    else
        //                //    {
        //                //        Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
        //                //       // Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";
        //                //    }
        //            }

        //            if (dropdown1 != " " && Convert.ToInt32(dropdown1) > 0)
        //            {
        //                string updateStatus = "update CandidateDetailsN set status =N'" + dropdown + "',Arrowcolor ='" + Wasp_path + "',Arrowcolor_brain='" + Brain_path + "' ,Statusid='" + dropdown1 + "' where id='" + key + "'";
        //                SqlCommand sel1 = new SqlCommand(updateStatus, con);
        //                sel1.ExecuteNonQuery();
        //            }

        //        }
        //        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
        //        if (string.IsNullOrEmpty(t1))
        //        {
        //            textbox = NDAGridView.Rows[i].Cells[2].Text;
        //        }
        //        else
        //        {
        //            textbox = t1;
        //        }
        //        if (textbox != "" && textbox != " " && textbox != null)
        //        {
        //            totalseats = totalseats + Convert.ToInt32(textbox);
        //        }
        //    }


        //    //getting total seat from state for validation*******

        //    string sqldata1 = "select Total_Seat from StateMaster where Id=2";
        //    SqlCommand seat = new SqlCommand(sqldata1, con);
        //    int seatotal = (int)seat.ExecuteScalar();

        //    if (totalseats <= seatotal)
        //    {
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = NDAGridView.DataKeys[i].Value.ToString();
        //            string textbox = ((TextBox)NDAGridView.Rows[i].Cells[0].FindControl("txtNDA1")).Text;
        //            //***********
        //            //string textbox1 = ((TextBox)jkGridView.Rows[i].Cells[1].FindControl("txtJK2")).Text;

        //            if (textbox != "")
        //            {
        //                string update1 = "update StateSeat set New_seat='" + textbox + "' where id='" + key + "'";
        //                SqlCommand cmd41 = new SqlCommand(update1, con);
        //                cmd41.ExecuteNonQuery();
        //            }

        //            //***************************************
        //            //if (textbox1 != "")
        //            //{
        //            //    string update1 = "update StateSeat set Voteshare='" + textbox1 + "' where Id='" + key + "'";
        //            //    SqlCommand cmd41 = new SqlCommand(update1, con);
        //            //    cmd41.ExecuteNonQuery();
        //            //}
        //            /***************************/
        //        }

        //        //Updating difference and set color by comparing previous seat and new seat***************
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = NDAGridView.DataKeys[i].Value.ToString();
        //            string seatdata = "select New_seat from StateSeat where id='" + key + "'";
        //            SqlCommand data = new SqlCommand(seatdata, con);
        //            int newseats = (int)data.ExecuteScalar();

        //            string prevdata = "select Pre_yr_seat from StateSeat where id='" + key + "'";
        //            SqlCommand data2 = new SqlCommand(prevdata, con);
        //            int prevseat = (int)data2.ExecuteScalar();

        //            if (prevseat > newseats)
        //            {
        //                int signvalue1 = prevseat - newseats;
        //                string path1 = "-" + Convert.ToString(signvalue1);
        //                string WASPcolor = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\RED.png";
        //                string BRAINcolor = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
        //                // string updatenew1 = "update Chhattisgarh_seat2023 set difference='" + path1 + "',color='" + stcolor1 + "' where id='" + 1 + "'";
        //                string updatenew1 = "update StateSeat set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "' where Id='" + key + "'";
        //                SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
        //                cmdnew1.ExecuteNonQuery();
        //            }
        //            if (newseats > prevseat)
        //            {
        //                int signvalue11 = newseats - prevseat;
        //                string path11 = "+" + Convert.ToString(signvalue11);
        //                string stcolor1 = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\GREEN.png";
        //                string BRAINcolor1 = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
        //                // string updatenew11 = "update karnataka_seat2023 set difference='" + path11 + "',color='" + stcolor + "' where id='" + 1 + "'";
        //                string updatenew11 = "update StateSeat set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "' where Id='" + key + "'";
        //                SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
        //                cmdnew11.ExecuteNonQuery();
        //            }
        //            if (newseats == prevseat)
        //            {
        //                int signvalue21 = newseats - prevseat;
        //                string path21 = "0";//null
        //                string stcolor2 = @"X:\Wasp3d\LOKSABHA_2019\TEXTURE\PARTY_COLOR\GREY.png";
        //                string BRAINcolor2 = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.png";
        //                // string updatenew21 = "update Chhattisgarh_seat2023 set difference='" + path21 + "',color='" + stcolor2 + "'where id='" + 1 + "'";
        //                string updatenew21 = "update StateSeat set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "' where Id='" + key + "'";
        //                SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
        //                cmdnew21.ExecuteNonQuery();
        //            }
        //        }
        //        //Set barvalue  Sum(total seat)*****************************

        //        string barheight = "select top 1 New_seat from dbo.StateSeat where Stateid=2 order by New_seat desc";
        //        SqlCommand bar = new SqlCommand(barheight, con);
        //        int barvalue = (int)bar.ExecuteScalar();
        //        int sum1 = 0;
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = NDAGridView.DataKeys[i].Value.ToString();
        //            string New_seat = "select New_seat from StateSeat where Id='" + key + "'";
        //            SqlCommand data = new SqlCommand(New_seat, con);
        //            int barval = (int)data.ExecuteScalar();

        //            sum1 = sum1 + barval;
        //            if (sum1 <= seatotal)
        //            {
        //                string total = "update StateMaster set Seat_count='" + sum1 + "' where Id='" + 2 + "'";
        //                SqlCommand Seat_count = new SqlCommand(total, con);
        //                Seat_count.ExecuteNonQuery();
        //            }

        //            if (barvalue > 0)
        //            {
        //                int bar1 = (barval * 100) / barvalue;

        //                string update11 = "update StateSeat set Bar22='" + bar1 + "' where Id='" + key + "'";
        //                SqlCommand cmd411 = new SqlCommand(update11, con);
        //                cmd411.ExecuteNonQuery();
        //            }
        //        }

        //        //Set vote share *******************************************************
        //        int sum = 0;
        //        int vote = 0;
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = NDAGridView.DataKeys[i].Value.ToString();
        //            string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key + "'";

        //            SqlCommand data = new SqlCommand(TotalVoteshare, con);
        //            vote = Convert.ToInt32(data.ExecuteScalar());

        //            sum = sum + vote;

        //        }
        //        if (sum > 0)
        //        {
        //            for (int i = 0; i < dttt.Rows.Count; i++)
        //            {
        //                string key1 = NDAGridView.DataKeys[i].Value.ToString();
        //                string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key1 + "'";
        //                SqlCommand data = new SqlCommand(TotalVoteshare, con);
        //                vote = Convert.ToInt32(data.ExecuteScalar());

        //                int voteshre1 = (vote * 360) / sum;


        //                string update111 = "update StateSeat set Pie='" + voteshre1 + "' where Id='" + key1 + "'";
        //                SqlCommand cmd4111 = new SqlCommand(update111, con);
        //                cmd4111.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);
        //        // Response.Write("<script>alert('Total seats Exceeded 60');</script>");
        //    }

        //    NDA();
        //    con.Close();
        //}

        //protected void NDAGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    get();
        //    string key = NDAGridView.DataKeys[e.RowIndex].Values[0].ToString();
        //    string update = "delete from StateSeat where Id='" + key + "'";
        //    SqlCommand updatee = new SqlCommand(update, con);
        //    updatee.ExecuteNonQuery();
        //    con.Close();
        //    NDAGridView.EditIndex = -1;
        //    NDA();
        //}

        //protected void NDAGridView_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    get();
        //    NDAGridView.EditIndex = e.NewEditIndex;
        //    NDA();
        //    con.Close();
        //}
        //protected void NDAGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    get();
        //    string key = NDAGridView.DataKeys[e.RowIndex].Values[0].ToString();
        //    string p_name = ((TextBox)NDAGridView.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

        //    string update = "update StateSeat set Partyname=N'" + p_name + "' where Id='" + key + "'";
        //    SqlCommand updatee = new SqlCommand(update, con);
        //    updatee.ExecuteNonQuery();
        //    con.Close();
        //    NDAGridView.EditIndex = -1;
        //    NDA();
        //}
        //protected void NDAGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    get();
        //    NDAGridView.EditIndex = -1;
        //    NDA();
        //    con.Close();
        //}



        // 3)INDIA BUG
        //public void INDIA()
        //{
        //    string sqldata = "select *from StateSeat where Stateid=3";
        //    SqlCommand cmde = new SqlCommand(sqldata, con);
        //    SqlDataAdapter data = new SqlDataAdapter(cmde);
        //    DataTable dttt = new DataTable();
        //    data.Fill(dttt);
        //    INDIAGridView.DataSource = dttt;
        //    INDIAGridView.DataBind();
        //    Session["INDIADATA"] = dttt;
        //}

        //protected void INDIABtn_Click(object sender, EventArgs e)
        //{
        //    get();
        //    DataTable dttt = (DataTable)Session["INDIADATA"];
        //    Session["INDIADATA"] = dttt;
        //    int totalseats = 0;

        //    for (int i = 0; i < dttt.Rows.Count; i++)
        //    {
        //        string textbox = "";
        //        string t1 = ((TextBox)INDIAGridView.Rows[i].Cells[0].FindControl("txtINDIA1")).Text;


        //        /* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //        string key = INDIAGridView.DataKeys[i].Values[0].ToString();
        //        string dropdown = ((DropDownList)INDIAGridView.Rows[i].Cells[0].FindControl("DropDownList2")).SelectedItem.Text;
        //        string dropdown1 = ((DropDownList)INDIAGridView.Rows[i].Cells[0].FindControl("DropDownList2")).SelectedItem.Value;
        //        string Wasp_path = "";
        //        string Brain_path = "";
        //        if (dropdown1 != "")
        //        {
        //            if (dropdown1 == "1" || dropdown1 == "13")
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\GREEN.png";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
        //            }
        //            else if (dropdown1 == "2" || dropdown1 == "4")
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\RED.png";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
        //            }
        //            else // condn for id = 5
        //            {
        //                Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
        //                Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";


        //                //    string getArrow = "select Arrowcolor from CandidateDetailsN where id='" + key + "'";
        //                //    SqlCommand getCmd = new SqlCommand(getArrow, con);
        //                //    object result = getCmd.ExecuteScalar();
        //                //    if (result != null && result != DBNull.Value)
        //                //    {
        //                //        Wasp_path = result.ToString();
        //                //    }
        //                //    else
        //                //    {
        //                //        Wasp_path = @"X:\2024\ELECTION\ELECTION_NOV24\TEXTURES\BLACK.PNG";
        //                //       // Brain_path = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.PNG";
        //                //    }
        //            }

        //            if (dropdown1 != " " && Convert.ToInt32(dropdown1) > 0)
        //            {
        //                string updateStatus = "update CandidateDetailsN set status =N'" + dropdown + "',Arrowcolor ='" + Wasp_path + "',Arrowcolor_brain='" + Brain_path + "' ,Statusid='" + dropdown1 + "' where id='" + key + "'";
        //                SqlCommand sel1 = new SqlCommand(updateStatus, con);
        //                sel1.ExecuteNonQuery();
        //            }

        //        }
        //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/


        //        if (string.IsNullOrEmpty(t1))
        //        {
        //            textbox = INDIAGridView.Rows[i].Cells[2].Text;
        //        }
        //        else
        //        {
        //            textbox = t1;
        //        }
        //        if (textbox != "" && textbox != " " && textbox != null)
        //        {
        //            totalseats = totalseats + Convert.ToInt32(textbox);
        //        }
        //    }


        //    //getting total seat from state for validation*******

        //    string sqldata1 = "select Total_Seat from StateMaster where Id=3";
        //    SqlCommand seat = new SqlCommand(sqldata1, con);
        //    int seatotal = (int)seat.ExecuteScalar();

        //    if (totalseats <= seatotal)
        //    {
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = INDIAGridView.DataKeys[i].Value.ToString();
        //            string textbox = ((TextBox)INDIAGridView.Rows[i].Cells[0].FindControl("txtINDIA1")).Text;
        //            //***********
        //            //string textbox1 = ((TextBox)jkGridView.Rows[i].Cells[1].FindControl("txtJK2")).Text;

        //            if (textbox != "")
        //            {
        //                string update1 = "update StateSeat set New_seat='" + textbox + "' where id='" + key + "'";
        //                SqlCommand cmd41 = new SqlCommand(update1, con);
        //                cmd41.ExecuteNonQuery();
        //            }

        //            //***************************************
        //            //if (textbox1 != "")
        //            //{
        //            //    string update1 = "update StateSeat set Voteshare='" + textbox1 + "' where Id='" + key + "'";
        //            //    SqlCommand cmd41 = new SqlCommand(update1, con);
        //            //    cmd41.ExecuteNonQuery();
        //            //}
        //            /***************************/
        //        }

        //        //Updating difference and set color by comparing previous seat and new seat***************
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = INDIAGridView.DataKeys[i].Value.ToString();
        //            string seatdata = "select New_seat from StateSeat where id='" + key + "'";
        //            SqlCommand data = new SqlCommand(seatdata, con);
        //            int newseats = (int)data.ExecuteScalar();

        //            string prevdata = "select Pre_yr_seat from StateSeat where id='" + key + "'";
        //            SqlCommand data2 = new SqlCommand(prevdata, con);
        //            int prevseat = (int)data2.ExecuteScalar();

        //            if (prevseat > newseats)
        //            {
        //                int signvalue1 = prevseat - newseats;
        //                string path1 = "-" + Convert.ToString(signvalue1);
        //                string WASPcolor = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\RED.png";
        //                string BRAINcolor = @"Y:\2025\DelhiElection\WIN&LOSS\RED.png";
        //                // string updatenew1 = "update Chhattisgarh_seat2023 set difference='" + path1 + "',color='" + stcolor1 + "' where id='" + 1 + "'";
        //                string updatenew1 = "update StateSeat set Difference='" + path1 + "',colorWASP='" + WASPcolor + "',colorBRAIN='" + BRAINcolor + "' where Id='" + key + "'";
        //                SqlCommand cmdnew1 = new SqlCommand(updatenew1, con);
        //                cmdnew1.ExecuteNonQuery();
        //            }
        //            if (newseats > prevseat)
        //            {
        //                int signvalue11 = newseats - prevseat;
        //                string path11 = "+" + Convert.ToString(signvalue11);
        //                string stcolor1 = @"X:\2022\5_STATE_ELECTION\PARTY_COLOR\GREEN.png";
        //                string BRAINcolor1 = @"Y:\2025\DelhiElection\WIN&LOSS\GREEN.png";
        //                // string updatenew11 = "update karnataka_seat2023 set difference='" + path11 + "',color='" + stcolor + "' where id='" + 1 + "'";
        //                string updatenew11 = "update StateSeat set Difference='" + path11 + "',colorWASP='" + stcolor1 + "',colorBRAIN='" + BRAINcolor1 + "' where Id='" + key + "'";
        //                SqlCommand cmdnew11 = new SqlCommand(updatenew11, con);
        //                cmdnew11.ExecuteNonQuery();
        //            }
        //            if (newseats == prevseat)
        //            {
        //                int signvalue21 = newseats - prevseat;
        //                string path21 = "0";//null
        //                string stcolor2 = @"X:\Wasp3d\LOKSABHA_2019\TEXTURE\PARTY_COLOR\GREY.png";
        //                string BRAINcolor2 = @"Y:\2025\DelhiElection\WIN&LOSS\BLACK.png";
        //                // string updatenew21 = "update Chhattisgarh_seat2023 set difference='" + path21 + "',color='" + stcolor2 + "'where id='" + 1 + "'";
        //                string updatenew21 = "update StateSeat set Difference='" + path21 + "',colorWASP='" + stcolor2 + "',colorBRAIN='" + BRAINcolor2 + "' where Id='" + key + "'";
        //                SqlCommand cmdnew21 = new SqlCommand(updatenew21, con);
        //                cmdnew21.ExecuteNonQuery();
        //            }
        //        }
        //        //Set barvalue  Sum(total seat)*****************************

        //        string barheight = "select top 1 New_seat from dbo.StateSeat where Stateid=3 order by New_seat desc";
        //        SqlCommand bar = new SqlCommand(barheight, con);
        //        int barvalue = (int)bar.ExecuteScalar();
        //        int sum1 = 0;
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = INDIAGridView.DataKeys[i].Value.ToString();
        //            string New_seat = "select New_seat from StateSeat where Id='" + key + "'";
        //            SqlCommand data = new SqlCommand(New_seat, con);
        //            int barval = (int)data.ExecuteScalar();

        //            sum1 = sum1 + barval;
        //            if (sum1 <= seatotal)
        //            {
        //                string total = "update StateMaster set Seat_count='" + sum1 + "' where Id='" + 3 + "'";
        //                SqlCommand Seat_count = new SqlCommand(total, con);
        //                Seat_count.ExecuteNonQuery();
        //            }

        //            if (barvalue > 0)
        //            {
        //                int bar1 = (barval * 100) / barvalue;

        //                string update11 = "update StateSeat set Bar22='" + bar1 + "' where Id='" + key + "'";
        //                SqlCommand cmd411 = new SqlCommand(update11, con);
        //                cmd411.ExecuteNonQuery();
        //            }
        //        }

        //        //Set vote share *******************************************************
        //        int sum = 0;
        //        int vote = 0;
        //        for (int i = 0; i < dttt.Rows.Count; i++)
        //        {
        //            string key = INDIAGridView.DataKeys[i].Value.ToString();
        //            string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key + "'";

        //            SqlCommand data = new SqlCommand(TotalVoteshare, con);
        //            vote = Convert.ToInt32(data.ExecuteScalar());

        //            sum = sum + vote;

        //        }
        //        if (sum > 0)
        //        {
        //            for (int i = 0; i < dttt.Rows.Count; i++)
        //            {
        //                string key1 = INDIAGridView.DataKeys[i].Value.ToString();
        //                string TotalVoteshare = "select Voteshare from StateSeat where Id='" + key1 + "'";
        //                SqlCommand data = new SqlCommand(TotalVoteshare, con);
        //                vote = Convert.ToInt32(data.ExecuteScalar());

        //                int voteshre1 = (vote * 360) / sum;


        //                string update111 = "update StateSeat set Pie='" + voteshre1 + "' where Id='" + key1 + "'";
        //                SqlCommand cmd4111 = new SqlCommand(update111, con);
        //                cmd4111.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total seats Exceeded... " + seatotal + "')", true);
        //        // Response.Write("<script>alert('Total seats Exceeded 60');</script>");
        //    }

        //    INDIA();
        //    con.Close();
        //}

        //protected void INDIAGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    get();
        //    string key = INDIAGridView.DataKeys[e.RowIndex].Values[0].ToString();
        //    string update = "delete from StateSeat where Id='" + key + "'";
        //    SqlCommand updatee = new SqlCommand(update, con);
        //    updatee.ExecuteNonQuery();
        //    con.Close();
        //    INDIAGridView.EditIndex = -1;
        //    INDIA();
        //}

        //protected void INDIAGridView_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    get();
        //    INDIAGridView.EditIndex = e.NewEditIndex;
        //    INDIA();
        //    con.Close();
        //}
        //protected void INDIAGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    get();
        //    string key = INDIAGridView.DataKeys[e.RowIndex].Values[0].ToString();
        //    string p_name = ((TextBox)INDIAGridView.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

        //    string update = "update StateSeat set Partyname=N'" + p_name + "' where Id='" + key + "'";
        //    SqlCommand updatee = new SqlCommand(update, con);
        //    updatee.ExecuteNonQuery();
        //    con.Close();
        //    INDIAGridView.EditIndex = -1;
        //    INDIA();
        //}
        //protected void INDIAGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    get();
        //    INDIAGridView.EditIndex = -1;
        //    INDIA();
        //    con.Close();
        //}
    }

