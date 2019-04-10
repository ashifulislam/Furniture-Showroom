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
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection con = null;
        int tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void dbConnection()
        {
            string strCon = "Data Source=DESKTOP-778TEI8\\PRINCESQL;Initial Catalog=FurnitureRegistration;Integrated Security=True";
            con = new SqlConnection(strCon);
            con.Open();
        }
        public void performLogin()
        {
            dbConnection();
            string query="select * from UserRegistration1 where Email='"+tbxEmail.Text+"' and Password='"+tbxPassword.Text+"'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            tot = int.Parse(dt.Rows.Count.ToString());
            if(tot>0)
            {
                
                if ((string)Session["CheckOut"] == "yes" )
                {
                    Session["user"] = tbxEmail.Text;
                    Response.Redirect("update_order_details.aspx");
                }
                else if((string)Session["buyNow"]=="yes")
                {
                    Session["user"] = tbxEmail.Text;
                    Response.Redirect(Session["goUrl"].ToString());
                }
               
                else
                {
                    Session["user"] = tbxEmail.Text;
                    Response.Redirect("order_details.aspx");

                }
                Response.Redirect("checkOut.aspx");
            }
            else
            {
                lblError.Text = "Invalid user name or password";
            }
        
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            performLogin();
        }
    }
}