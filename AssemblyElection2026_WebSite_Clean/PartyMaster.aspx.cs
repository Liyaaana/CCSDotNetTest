using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

 

    public partial class PartyMaster : System.Web.UI.Page
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
                data();
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            get();
            byte[] arr = FileUpload1.FileBytes;
            byte[] arr1 = FileUpload2.FileBytes;
            string Partycolor = "";
            string PartyLogo = "";
            if (FileUpload1.HasFile)
            {
                Partycolor = Path.GetFullPath(FileUpload1.PostedFile.FileName);
            }
            if (FileUpload2.HasFile)
            {
                PartyLogo = Path.GetFullPath(FileUpload2.PostedFile.FileName);
            }

            if (FileUpload1.PostedFile.FileName == "")
            {
                Partycolor = "";
            }
            if (FileUpload2.PostedFile.FileName == "")
            {
                PartyLogo = "";
            }
            if (!string.IsNullOrEmpty(Partycolor) || !string.IsNullOrEmpty(PartyLogo))
            {
                String getPath = Partycolor; //getting partycolor path
                String image = Path.GetFileName(getPath); // extracting image name 
                String waspColorPath = Path.Combine(@"X:\2025\ELECTION\BIHAR 2025\PARTY COLOUR 2025\", image);  //party color path for wasp  
                String brainColorPath = Path.Combine(@"Y:\2025\DelhiElection\PARTY_COLORS\", image); //party color path forBrainstorm 

                String getLogo = PartyLogo; //getting partycolor path
                String Logoimage = Path.GetFileName(getLogo); // extracting image name 
                String waspLogoPath = Path.Combine(@"X:\2025\DelhiElection\SYMBOLS\", Logoimage);     //party logo path for wasp
                String brainLogoPath = Path.Combine(@"Y:\2025\DelhiElection\SYMBOLS\", Logoimage);  //party logo path forBrainstorm

                if (TextBox1.Text != "" && Partycolor != "")
                {
                    string sql = "insert into PartyMasterN(partyname,color_WASP,logo_WASP,color_BRAIN,logo_BRAIN) values(N'" + TextBox1.Text + "','" + waspColorPath + "','" + waspLogoPath + "','" + brainColorPath + "','" + brainLogoPath + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    TextBox1.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DONE..')", true);
                    data();
                    con.Close();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill the fields..')", true);
            }
        }

        public void data()
        {

            string sql = "select * from PartyMasterN";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt12 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt12);
            GridView1.DataSource = dt12;
            GridView1.DataBind();
            Session["datas"] = dt12;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            get();
            DataTable dt12 = (DataTable)Session["datas"];
            Session["datas"] = dt12;
            for (int j = 0; j < dt12.Rows.Count; j++)
            {
                string key = GridView1.DataKeys[j].Values[0].ToString();
                byte[] arr = ((FileUpload)GridView1.Rows[j].Cells[0].FindControl("FileUpload3")).FileBytes;
                byte[] arr1 = ((FileUpload)GridView1.Rows[j].Cells[1].FindControl("FileUpload4")).FileBytes;

                string filepath = "";
                string filepath1 = "";

                FileUpload fu = (FileUpload)GridView1.Rows[j].Cells[0].FindControl("FileUpload3");//for path
                if (fu != null && fu.PostedFile != null)
                {
                    filepath = fu.PostedFile.FileName;
                }
                FileUpload fu1 = (FileUpload)GridView1.Rows[j].Cells[1].FindControl("FileUpload4");
                if (fu1 != null && fu1.PostedFile != null)
                {
                    filepath1 = fu1.PostedFile.FileName;
                }

                // for color

                String upPath = filepath;
                String image = Path.GetFileName(upPath);
                String waspupPath = Path.Combine(@"X:\2025\ELECTION\BIHAR 2025\PARTY COLOUR 2025\", image);
                String brainUpdate = Path.Combine(@"Y:\2025\DelhiElection\PARTY_COLORS\", image);

                //for Logo
                String uplogo = filepath1;
                String imagelog = Path.GetFileName(uplogo);
                String waspupLogo = Path.Combine(@"X:\2025\DelhiElection\SYMBOLS\", imagelog);
                String brainLogoUp = Path.Combine(@"Y:\2025\DelhiElection\SYMBOLS\", imagelog);

                if (filepath != "" || filepath1 != "")
                {
                    if (filepath != "")
                    {
                        //SqlCommand sl = new SqlCommand("update PartyMaster set color_WASP= @waspcolor,color_BRAIN=@braincolor where id='" + key + "'", con);
                        SqlCommand sl = new SqlCommand("update PartyMasterN set color_WASP= @waspcolor,color_BRAIN=@braincolor where id=@key", con);
                        sl.Parameters.AddWithValue("@waspcolor", arr);
                        sl.Parameters.AddWithValue("@braincolor", arr1);
                        sl.Parameters.AddWithValue("@key", key);
                        // sl.Parameters.AddWithValue("@imgg", arr1);
                        sl.ExecuteNonQuery();

                        string update2 = "update PartyMasterN set color_WASP='" + waspupPath + "' ,color_BRAIN='" + brainUpdate + "'where id='" + key + "'";
                        SqlCommand cmdr = new SqlCommand(update2, con);
                        cmdr.ExecuteNonQuery();
                    }
                    if (filepath1 != "")
                    {

                        // SqlCommand sl = new SqlCommand("update PartyMaster set logo= @logo where id='" + key + "'", con);

                        SqlCommand sl = new SqlCommand("update PartyMasterN set logo_WASP= @wasp,logo_BRAIN=@brain where id=@key", con);
                        sl.Parameters.AddWithValue("@wasp", arr);
                        sl.Parameters.AddWithValue("@brain", arr1);
                        sl.Parameters.AddWithValue("@key", key);
                        sl.ExecuteNonQuery();

                        string update2 = "update PartyMasterN set logo_WASP='" + waspupLogo + "' ,logo_BRAIN='" + brainLogoUp + "'where id='" + key + "'";
                        SqlCommand cmdr = new SqlCommand(update2, con);
                        cmdr.ExecuteNonQuery();
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated successfully..')", true);
                    data();
                    con.Close();
                }
            }
        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            get();
            GridView1.EditIndex = e.NewEditIndex;

            data();
            con.Close();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            get();
            string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            string p_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

            string update = "update PartyMasterN set partyname=N'" + p_name + "' where id='" + key + "'";
            SqlCommand updatee = new SqlCommand(update, con);
            updatee.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Party Name Updated successfully..')", true);
            data();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            get();
            GridView1.EditIndex = -1;
            data();
            con.Close();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            get();
            string key = GridView1.DataKeys[e.RowIndex].Values[0].ToString(); // values[0] means first key value eg: Id
            string update = "delete from PartyMasterN where id='" + key + "'";
            SqlCommand updatee = new SqlCommand(update, con);
            updatee.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted successfully..')", true);
            data();
        }

    }

