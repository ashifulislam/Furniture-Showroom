using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class product_des : System.Web.UI.Page
    {
        SqlConnection con = null;
        int id;
        string product_name, product_desc, product_price, product_quantity, images;
        protected void Page_Load(object sender, EventArgs e)
        {
            itemShow();
        }
        public void dbConnection()
        {
            string strCon = "Data Source=DESKTOP-778TEI8\\PRINCESQL;Initial Catalog=Shopping;Integrated Security=True";
            con = new SqlConnection(strCon);
            con.Open();
        }
        protected void itemShow()
        {
            dbConnection();
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DisplayItem1.aspx");
            }
            else
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                string query = "select * from productDetails1 where id = " + id + "";
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {


                    d1.DataSource = dt;
                    d1.DataBind();
                }

                con.Close();
            }

        }

        protected void d1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            dbConnection();
            string query = "select * from productDetails1 where id = " + id + "";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                product_name = dr["productName"].ToString();
                product_desc = dr["productDes"].ToString();
                product_price = dr["productPrice"].ToString();
                product_quantity = dr["productQuantity"].ToString();
                images = dr["productImage"].ToString();
                con.Close();
            }
            if (int.Parse(tbxQuantity.Text) > int.Parse(product_quantity))
            {
                lblError.Text = "Product is not available please enter low quantity";
            }
            else
            {
                lblError.Text = "Item added into successfully";
                if (Request.Cookies["aa"] == null)
                {
                    Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," +
                       product_price.ToString() + "," + product_quantity.ToString() + "," + images.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);

                }
                else
                {
                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," +
                      product_price.ToString() + "," + product_quantity.ToString() + "," + images.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
                dbConnection();
                SqlCommand cmd = new SqlCommand("update productDetails1 set productQuantity=productQuantity-" + tbxQuantity.Text+"where id="+id, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("product_des.aspx?id="+id.ToString());
                con.Close();
            }
        }
    }
}
