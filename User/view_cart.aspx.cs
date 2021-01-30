using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_view_cart : System.Web.UI.Page
{
    string cookiesString, singleProduct;
    string[] parsedProduct = new string[6];
    int totalCart = 0;

    // tworzenie tymczasowej tabeli dla koszyka zakupów 
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("prod_name"), new DataColumn("prod_desc"), new DataColumn("prod_price"), new DataColumn("prod_qty"), new DataColumn("prod_images"), new DataColumn("id"), new DataColumn("prod_id") });

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

                dt.Rows.Add(parsedProduct[0].ToString(), parsedProduct[1].ToString(), parsedProduct[2].ToString(), parsedProduct[3].ToString(), parsedProduct[4].ToString(), i.ToString(), parsedProduct[5].ToString());

                totalCart += Convert.ToInt32(parsedProduct[2].ToString()) * Convert.ToInt32(parsedProduct[3].ToString());
            }
        }

        d1.DataSource = dt;
        d1.DataBind();

        l1.Text = "Total price: "+totalCart.ToString();
    }


    protected void b1_Click(object sender, EventArgs e)
    {
        Session["checkoutbutton"] = "yes";
        Response.Redirect("checkout.aspx");
    }
}