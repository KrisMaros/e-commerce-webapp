using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_delete_category : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from product_category where product_category='"+ Request.QueryString["category"].ToString() + "'";
        cmd.ExecuteNonQuery();

         // kasuje wszystkie produkty z danej kategorii (modyfikacjia bazy danych dodac foregin key )
        SqlCommand cmd1 = con.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "delete from Product where prod_category='" + Request.QueryString["category"].ToString() + "'";
        cmd1.ExecuteNonQuery();

        con.Close();

        Response.Redirect("add_category.aspx");
    }
}