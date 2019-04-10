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
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
            }

        }
        protected void dbConnection()
        {
            try
            {
                string strcon = "Data Source=DESKTOP-778TEI8\\PRINCESQL;Initial Catalog=FurnitureRegistration;Integrated Security=True";
                con = new SqlConnection(strcon);
                con.Open();
            }
            catch (Exception ex)
            {
                lblError.Text = "Not Successful";
            }
        }
        protected void DbInsert()
        {

            dbConnection();
            if (tbxName.Text == "" || tbxLastName.Text == "" || tbxEmail.Text == "" || tbxPassword.Text == "" || tbxConfirm.Text == "" || tbxPhone.Text == "")
            {
                lblError.Text = "Field These Mandatory Field";
            }

            else if (tbxPassword.Text != tbxConfirm.Text)
            {
                lblError.Text = "Password did not match Try again";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("userInsert1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Userid", int.Parse(hfUserId.Value == "" ? "0" : hfUserId.Value));
                cmd.Parameters.AddWithValue("@FirstName", tbxName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", tbxLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", tbxPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", tbxEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", tbxPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", tbxAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@City", ddlCity.SelectedItem.Value.ToString());
                cmd.Parameters.AddWithValue("@StateCode", tbxStateCode.Text.Trim());







                cmd.ExecuteNonQuery();
                clear();
                lblSuccessfull.Text = "Registered Successfully";
            }

        }
        protected void clear()
        {
            tbxName.Text = tbxLastName.Text = tbxEmail.Text = tbxPassword.Text = tbxConfirm.Text = "";
            lblSuccessfull.Text = lblError.Text = "";
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DbInsert();
        }

        protected void btnlogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}