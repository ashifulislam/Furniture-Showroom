using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class checkOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is not logged in
            if (Session["user"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                Response.Redirect("update_order_details.aspx");
            }
        }
    }
}