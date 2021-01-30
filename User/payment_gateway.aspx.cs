using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_payment_gateway : System.Web.UI.Page
{

    string cookiesString, singleProduct;
    string[] parsedProduct = new string[6];
    int totalCart = 0;
    string order_no;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }

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

                totalCart += Convert.ToInt32(parsedProduct[2].ToString()) * Convert.ToInt32(parsedProduct[3].ToString());
            }
            Session["totalCart"] = totalCart.ToString();
        }

        //paypal payment implementation

        order_no = Class1.GetRandomPassword(10).ToString();
        Session["order_no"] = order_no.ToString();

        //Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredits'>");
        //Response.Write("<input type='hidden' name='cmd' value='_xclick'>");
        //Response.Write("<input type='hidden' name='business' value='amit_1266030690_per@gmail.com' >");
        //Response.Write("<input type='hidden' name='currency_code' value'USD'>");
        //Response.Write("<input type='hidden' name='item_name' value='payment for purchase' >");
        //Response.Write("<input type='hidden' name='item_number' value='0' >");
        //Response.Write("<input type='hidden' name='amount' value'" + Session["totalCart"].ToString() + "'>");
        //Response.Write("<input type='hidden' name='return' value='http://localhost:50437/E-commerce-webapp/User/payment_success.aspx?order=" + order_no.ToString() + "' >");
        //Response.Write("</form>");

        //Response.Write("<script type='text/javascript'>");
        //Response.Write("document.getElementById('buyCredits').submit();");
        //Response.Write("</script>");

        Response.Redirect("payment_success.aspx?order='"+order_no+"'");
    }
}