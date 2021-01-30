using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_update_order_details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (IsPostBack) { return; }
        // pobiera informacje o urzytkowniku w celu weryfikacji addresu dostawy
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Registration where email='" + Session["user"].ToString() + "'";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            TextBoxFirst.Text = dr["firstname"].ToString();
            TextBoxLast.Text = dr["lastname"].ToString();
            TextBoxAddress.Text = dr["address"].ToString();
            TextBoxTown.Text = dr["town"].ToString();
            TextBoxPost.Text = dr["postcode"].ToString();
            TextBoxPhone.Text = dr["telephone"].ToString();
        }
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        //mozliwosc modyfikacji lub zmiany informacji adresowych i kontaktowych uzytkownika
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update Registration set firstname='"+ TextBoxFirst.Text + "', lastname='"+ TextBoxLast.Text + "', address='"+ TextBoxAddress.Text + "', town='"+ TextBoxTown.Text + "', postcode='"+ TextBoxPost.Text + "', telephone='"+ TextBoxPhone.Text + "' where email='" + Session["user"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        // przekierowanie do strony z platnoscia
        Response.Redirect("payment_gateway.aspx");
    }
}