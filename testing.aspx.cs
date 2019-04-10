using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void b4_Click(object sender, EventArgs e)
        {
           
           
                var s = Convert.ToString(Request.Cookies["aa"].Value);
                string[] array = s.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    Response.Write(array[i].ToString());
                    Response.Write("<br>");

                }
            
        }
       

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            HttpCookie prince = new HttpCookie("aa");
            prince.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(prince);
            Response.Redirect("testing.aspx");
        }
    }
}