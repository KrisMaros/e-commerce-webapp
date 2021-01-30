using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_delete_cart : System.Web.UI.Page
{
    string prod_name, prod_desc, prod_price, prod_qty, prod_images;
    string cookiesString, singleProduct;
    string[] parsedProduct = new string[6];
    int id;
    int prod_id;
    int qty;
    int count = 0;

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        // tabela tymczasowa

        DataTable dt = createProductTable();

        //dodawanie produktu do puli w tabeli jesli produkt usuniety z koszyka 

        updateQty(dt);

        //usowa produkt z koszyka
        dt.Rows.RemoveAt(id);

        // Kasowanie plikow cookies 

        clearCookies();

        //tworzenie nowych plikow cookies, z tymczasowej tabeli

        createNewCookies(dt);
    }

    public DataTable createProductTable()
    {
        //pogiera id do usuniecia z addressu url
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        // tabela tymczasowa
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
            }
        }
        return dt;
    }

    public void createNewCookies(DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            prod_name = dr["prod_name"].ToString();
            prod_desc = dr["prod_desc"].ToString();
            prod_price = dr["prod_price"].ToString();
            prod_qty = dr["prod_qty"].ToString();
            prod_images = dr["prod_images"].ToString();
            prod_id = Convert.ToInt32(dr["prod_id"].ToString());

            if (Request.Cookies["aa"] == null)
            {
                Response.Cookies["aa"].Value = prod_name.ToString() + "," + prod_desc.ToString() + "," + prod_price.ToString() + "," + prod_qty.ToString() + "," + prod_images.ToString() + "," + prod_id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
            else if (Request.Cookies["aa"] != null)
            {
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + prod_name.ToString() + "," + prod_desc.ToString() + "," + prod_price.ToString() + "," + prod_qty.ToString() + "," + prod_images.ToString() + "," + prod_id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
        }

        Response.Redirect("view_cart.aspx");
    }

    public void clearCookies()
    {
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        //czysci cookies po stronie klienta
        HttpContext.Current.Request.Cookies.Clear();
    }

    public void updateQty(DataTable dt)
    {
        count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (count == id)
            {
                prod_id = Convert.ToInt32(dr["prod_id"].ToString());
                qty = Convert.ToInt32(dr["prod_qty"].ToString());
            }
            count++;
        }
        count = 0;

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update Product set prod_qty=prod_qty+" + qty + "where id=" + prod_id;
        cmd.ExecuteNonQuery();
        con.Close();
    }
}