using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class update_order_details : System.Web.UI.Page
    {
        SqlConnection con = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            show();
        }
        public void dbConnection()
        {
         string strcon= "Data Source=DESKTOP-778TEI8\\PRINCESQL;Initial Catalog=FurnitureRegistration;Integrated Security=True";
            con = new SqlConnection(strcon);
            con.Open();
        }
        public void show()
        {
            dbConnection();
            string query = "select * from UserRegistration1 where Email='" + Session["user"].ToString() + "'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                tbxName.Text = dr["FirstName"].ToString();
                tbxLastName.Text = dr["LastName"].ToString();
                tbxPhone.Text = dr["Phone"].ToString();
                tbxAddress.Text = dr["Address"].ToString();
                ddlCity.SelectedItem.Value = dr["City"].ToString();
                tbxStateCode.Text = dr["StateCode"].ToString();




            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.Add(tbxName.Text);
            arr.Add(tbxLastName.Text);
            arr.Add(tbxPhone.Text);
            arr.Add(tbxAddress.Text);
            arr.Add(ddlCity.SelectedItem.Value);
            arr.Add(tbxStateCode.Text);
          
            //string[] ud = { tbxName.Text, tbxLastName.Text };
            Session["key"] = arr;
            dbConnection();
            string query = "update UserRegistration1 set FirstName='"+tbxName.Text+"',LastName='"+tbxLastName.Text+"',Phone='"+tbxPhone.Text+ "',Address='" + tbxAddress.Text + "',City='" + ddlCity.SelectedItem.Value +"',StateCode='"+tbxStateCode.Text+"' where Email='" + Session["user"].ToString() + "'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            Response.Redirect(Session["goUrl"].ToString());
            
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
        }
    }
}