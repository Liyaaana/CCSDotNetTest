using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class count_image : System.Web.UI.Page
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

        int id = Convert.ToInt32(Request.QueryString["id"]);

        string sql = "select image from candi_five_image where candidateid='" + id + "'";

        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            byte[] arr = (byte[])dr[0];
            Response.ContentType = "image/jpg";
            Response.BinaryWrite(arr);
        }

        con.Close();
    }
}