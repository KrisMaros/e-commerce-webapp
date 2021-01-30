using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into registration values('" + TextBoxFirst.Text + "','" + TextBoxLast.Text + "','" + TextBoxEmail.Text + "','" + TextBoxPass.Text + "','" + TextBoxAddress.Text + "','" + TextBoxTown.Text + "','" + TextBoxPost.Text + "','" + TextBoxPin.Text + "','" + TextBoxTelephone.Text + "')";
        cmd.ExecuteNonQuery();

        con.Close();

        TextBoxFirst.Text = "";
        TextBoxLast.Text = "";
        TextBoxEmail.Text = "";
        TextBoxPass.Text = "";
        TextBoxAddress.Text = "";
        TextBoxTown.Text = "";
        TextBoxPost.Text = "";
        TextBoxPin.Text = "";
        TextBoxTelephone.Text = "";

        Label1.Text = "Registration successful";
    }
}