using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_user : System.Web.UI.MasterPage
{
    string cookiesString, singleProduct;
    string[] parsedProduct = new string[6];
    int totalCartPrice = 0;
    int totalCartItems = 0;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product_category";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        data_list.DataSource = dt;
        data_list.DataBind();

        con.Close();

        if (Request.Cookies["aa"] != null)
        {
            cookiesString = Convert.ToString(Request.Cookies["aa"].Value);

            string[] strArr = cookiesString.Split('|');

            for (int i = 0; i < strArr.Length; i++)
            {
                singleProduct = Convert.ToString(strArr[i].ToString());
                string[] strSplitArr = singleProduct.Split(',');

                for (int j = 0; j < strSplitArr.Length; j++)
                {
                    parsedProduct[j] = strSplitArr[j].ToString();
                }

                totalCartPrice += Convert.ToInt32(parsedProduct[2].ToString()) * Convert.ToInt32(parsedProduct[3].ToString());
                totalCartItems++;
            }

            cartTotalPrice.Text = totalCartPrice.ToString();
            cartTotalItems.Text = totalCartItems.ToString();
        }
    }
}
