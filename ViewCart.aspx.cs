using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class ViewCart : System.Web.UI.Page
    {
        string s;
        string t;
        string[] a = new string[5];
        int tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("productName"), new DataColumn("productDes"), new DataColumn("productPrice"), new DataColumn("productQuantity"), new DataColumn("productImage"),new DataColumn("id") });
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
                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(),i.ToString());
                        tot = tot + (int.Parse(a[2].ToString()) * int.Parse(a[3].ToString()));
                    }
                }
                dl1.DataSource = dt;
                dl1.DataBind();
                l1.Text =tot.ToString();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Session["goUrl"] = "BuyNow.aspx?price=" + l1.Text;
            Session["CheckOut"] = "yes";
            Response.Redirect("checkout.aspx");
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            Session["buyNow"] = "yes";
            if (Session["user"] == null)
            {
                Session["goUrl"] = "BuyNow.aspx?price=" + l1.Text;
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                Response.Redirect("BuyNow.aspx?price=" + l1.Text);
            }
           
        }
    }
}