using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_admin_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn1_Click(object sender, EventArgs e)
    {

        try
        {            
            i = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admin_login where username='" + t1.Text + "' and password='" + t2.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dataT = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataT);

            i = Convert.ToInt32(dataT.Rows.Count.ToString());

            if (i == 1)
            {
                Session["admin"] = t1.Text;
                Response.Redirect("testing.aspx");
            }
            else
            {
                l1.Text = "invalid user name or password provided";
            }

            con.Close();
        }
        catch(Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }        
    }
}