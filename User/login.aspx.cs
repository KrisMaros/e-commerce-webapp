using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);
    string email, pass;
    int credentialOk = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn1_Click(object sender, EventArgs e)
    {

        email = TextBoxEmail.Text;
        pass = TextBoxPass.Text;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Registration where email='"+email+"' and password='"+pass+"'";
        //cmd.ExecuteNonQuery();

        //sprawda czy jakis rekord jest zwrucony z bazy danych
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {  
            if(Session["checkoutbutton"] == "yes")
            {
                Session["user"] = TextBoxEmail.Text;
                Response.Redirect("update_order_details.aspx");
            }
            else
            {
                Session["user"] = TextBoxEmail.Text;
                Response.Redirect("order_details.aspx");
            }         
            
        }
        else
        {
            l1.Text = "Credentials are not correct, please try agein !";            
        }

        con.Close();
    }
}