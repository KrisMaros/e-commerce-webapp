using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_product_desc : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceConnectionString"].ConnectionString);
    int id;
    int qty;
    string prod_name, prod_desc, prod_price, prod_qty, prod_images;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_product.aspx");
        }
        else
        {
            // pobiera produkty z lokalnej bazy danych
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where id='"+id+"'";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            d1.DataSource = dataTable;
            d1.DataBind();

            con.Close();
        }

        // sprawdza czy produkt jest dostepny , jesli nie to wylacza panel i wyswietla wiadomosc 
        qty = get_qty(id);
        if(qty == 0)
        {
            l2.Visible = false;
            t1.Visible = false;
            b1.Visible = false;
            l1.Text = "Product is not available";
        }
    }

    protected void b1_Click(object sender, EventArgs e)
    {
        if(con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Product where id=" + id;
        cmd.ExecuteNonQuery();
        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataTable);
        
        foreach (DataRow dr in dataTable.Rows)
        {
            prod_name = dr["prod_name"].ToString();
            prod_desc = dr["prod_desc"].ToString();
            prod_price = dr["prod_price"].ToString();
            prod_qty = dr["prod_qty"].ToString();
            prod_images = dr["prod_images"].ToString();
        }        

        // sprawdzanie czy zamowiona ilosc jest dostepna
        if (Convert.ToInt32(t1.Text) > Convert.ToInt32(prod_qty))
        {
            l1.Text = "The quantity is not available";
        }
        else
        {
            string qty = t1.Text;
            l1.Text = "";
            // tworzenie pliku cookies który sluzy do przechowywania zawartosci koszyka zakupowego 
            if (Request.Cookies["aa"] == null)
            {
                Response.Cookies["aa"].Value = prod_name.ToString() + "," + prod_desc.ToString() + "," + prod_price.ToString() + "," + qty.ToString() + "," + prod_images.ToString() +","+ id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + prod_name.ToString() + "," + prod_desc.ToString() + "," + prod_price.ToString() + "," + qty.ToString() + "," + prod_images.ToString() + "," + id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update Product set prod_qty=prod_qty-"+t1.Text+"where id='"+id+"'";
            cmd1.ExecuteNonQuery();
            Response.Redirect("product_desc.aspx?id=" + id.ToString());
             

        }        
    }

    public int get_qty(int id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Product where id='" + id + "'";
        cmd.ExecuteNonQuery();
        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataTable);

        foreach (DataRow dr in dataTable.Rows)
        {
            qty = Convert.ToInt32(dr["prod_qty"].ToString());
        }
        return qty;
    }
}