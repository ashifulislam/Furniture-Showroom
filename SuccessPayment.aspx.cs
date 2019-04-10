using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class SuccessPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Text = "Transaction ID :" + Request.Form["txnid"] + " has been successfully Completed";
        }
    }
}