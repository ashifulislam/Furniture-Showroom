using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class DateOfBuyControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calanderr1.Visible = false;
            }

        }

        protected void imgButton_Click(object sender, ImageClickEventArgs e)
        {
            if (calanderr1.Visible)
            {
                calanderr1.Visible = false;
            }
            else
            {
                calanderr1.Visible = true;
            }
        }

        protected void calanderr1_SelectionChanged(object sender, EventArgs e)
        {
            textDate.Text = calanderr1.SelectedDate.ToLongDateString();
            calanderr1.Visible = false;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Write(textDate.Text);
        }
    }
}
