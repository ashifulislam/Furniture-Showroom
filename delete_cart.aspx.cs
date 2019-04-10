using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class delete_cart : System.Web.UI.Page
    {
        string s;
        string t;
        string[] a = new string[5];
        int id;
        string product_name, product_desc, product_price, product_quantity, images;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("productName"), new DataColumn("productDes"), new DataColumn("productPrice"), new DataColumn("productQuantity"), new DataColumn("productImage"), new DataColumn("id") });
                if (Request.Cookies["aa"] != null)
                {
                    s = Convert.ToString(Request.Cookies["aa"].Value);
                    string[] strArr = s.Split('|');
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        t = Convert.ToString(strArr[i].ToString());
                        string[] strArr1 = t.Split(',');
                        for (int j = 0; j < strArr1.Length; j++)
                        {
                            a[j] = strArr1[j].ToString();
                        }
                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString());
                    }
                }
                dt.Rows.RemoveAt(id);
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                
                foreach (DataRow dr in dt.Rows)
                {
                    product_name = dr["productName"].ToString();
                    product_desc = dr["productDes"].ToString();
                    product_price = dr["productPrice"].ToString();
                    product_quantity = dr["productQuantity"].ToString();
                    images = dr["productImage"].ToString();
                    count = count + 1;

                    if (count==1)
                    {
                        Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," +
                           product_price.ToString() + "," + product_quantity.ToString() + "," + images.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(2);

                    }
                    else
                    {
                        Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," +
                          product_price.ToString() + "," + product_quantity.ToString() + "," + images.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(2);
                    }
                }
                Response.Redirect("ViewCart.aspx");


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }
               
    }
    
