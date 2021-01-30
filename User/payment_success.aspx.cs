using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_payment_success : System.Web.UI.Page
{
    string cookiesString, singleProduct;
    string[] parsedProduct = new string[6];
    string order, order_id;

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {   
        
        con.Open();
        order = Request.QueryString["order"].ToString();
        if (order != null)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration where email='" + Session["user"].ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            // do poprawienia znalezc id i zapisac Registration id w Orders !!
            foreach (DataRow dr in dt.Rows)
            {

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into Orders values('" + dr["firstname"].ToString() + "','" + dr["lastname"].ToString() + "','" + dr["email"].ToString() + "','" + dr["address"].ToString() + "','" + dr["town"].ToString() + "','" + dr["postcode"].ToString() + "','" + dr["telephone"].ToString() + "')";
                cmd1.ExecuteNonQuery();
            }

            // wyszukanie order id 
            order_id = getOrderId();

            // tworzy record w order details dane pochodza z pliku cookie oraz id z orders
            createOrderDetails(order_id);
        }
        else
        {
            Response.Redirect("login.aspx");
        }

        con.Close();

        Session["user"] = "";
        clearCookies();

        Response.Redirect("display_product.aspx");
        
    }

    public void clearCookies()
    {
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        //czysci cookies po stronie klienta
        HttpContext.Current.Request.Cookies.Clear();
    }

    public void createOrderDetails(string orderId)
    {
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

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into order_details values('"+orderId.ToString()+"','"+ parsedProduct[0].ToString()+ "','" + parsedProduct[2].ToString() + "','" + parsedProduct[3].ToString() + "','" + parsedProduct[4].ToString() + "')";
                cmd.ExecuteNonQuery();

            }
        }
    }

    public string getOrderId()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select top 1 * from Orders where email='" + Session["user"].ToString() + "' order by id desc ";
        cmd.ExecuteNonQuery();

        string id = "";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            id = dr["id"].ToString();
        }
        return id;
    }
}