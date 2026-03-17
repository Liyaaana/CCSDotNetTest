using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class logo_img : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection();
    public void getconnection()
    {
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["Assembly2026"].ToString();
        connection.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getconnection();
            DataTable dt12 = (DataTable)Session["data"];
            Session["data"] = dt12;
            if (dt12 != null)
            {
                for (int i = 0; i < dt12.Rows.Count; i++)
                {
                    int x = Convert.ToInt32(Request.QueryString["id"].ToString());
                    string ee = "select * from candi_five_image where candidateid='" + x + "'";
                    SqlCommand ddr = new SqlCommand(ee, connection);
                    SqlDataAdapter ww = new SqlDataAdapter(ddr);
                    DataTable et = new DataTable();
                    ww.Fill(et);
                    if (et.Rows.Count > 0)
                    {
                        byte[] arr = (byte[])et.Rows[0][2];
                        Response.BinaryWrite(arr);
                    }
                }
            }
            connection.Close();
        }
    }
}