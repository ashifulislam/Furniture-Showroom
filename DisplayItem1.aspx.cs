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
    public partial class DisplayItem1 : System.Web.UI.Page
    {
        SqlConnection con = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            itemShow();
           
            //search();
           
        }
        protected void dbConnection()
        {
            try
            {
                string strCon = "Data Source=DESKTOP-778TEI8\\PRINCESQL;Initial Catalog=Shopping;Integrated Security=True";
                con = new SqlConnection(strCon);
                con.Open();
            }
            catch (Exception ex)
            {

            }
        }
        protected void itemShow()
        {
            dbConnection();
            string query = "select * from productDetails1";
           
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
        }
        public void search()
        {
            dbConnection();
            
            if (Request.QueryString["search"] != null)
            {
                string query = "select * from productDetails1 where productName like('%" + Request.QueryString["search"].ToString() + "%')";
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();
            }
            else 
            {
                
            }
            
        }
    }
}
