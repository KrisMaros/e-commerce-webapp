using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_add_product : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);
    string a, b;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["admin"] == null)
        {
            Response.Redirect("admin_login.aspx");
        }
        
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;       
        cmd.CommandText = "select product_category from product_category";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        // zapobiega ponownemu wczytaniu listy
        if(DropDownCategory.Items.Count == 0)

        foreach(DataRow dr in dt.Rows)
        {
            DropDownCategory.Items.Add(dr["product_category"].ToString()); 
        }
        con.Close();
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        try
        {
            a = Class1.GetRandomPassword(5).ToString();
            f1.SaveAs(Request.PhysicalApplicationPath + "./Images/" + a + f1.FileName.ToString());
            b = "Images/" + a + f1.FileName.ToString();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            // t3 i t4 nie potrzebuja pojedynczych cudzyslowów poniewaz zwracaja intiger
            cmd.CommandText = "insert into Product values('" + t1.Text + "','" + t2.Text + "'," + t3.Text + "," + t4.Text + ",'" + b.ToString() + "','" + DropDownCategory.SelectedItem.ToString() + "')";
            cmd.ExecuteNonQuery();
            con.Close();            
            //Response.Write("insert into Product values('" + t1.Text + "','" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + b.ToString() + "')");
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }
}