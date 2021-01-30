using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_display_product : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);    

    protected void Page_Load(object sender, EventArgs e)
    {        

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        if (Request.QueryString["category"] == null)
        {
            cmd.CommandText = "select * from Product";
        }
        else
        {
            cmd.CommandText = "select * from Product where prod_category='" + Request.QueryString["category"].ToString() + "'";
        }
                
        cmd.ExecuteNonQuery();
        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataTable);
        d1.DataSource = dataTable;
        d1.DataBind();

        con.Close();
    }
}