using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFurnitureShowroom.User
{
    public partial class BuyNow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblPrice.Text = Request.QueryString["price"].ToString();
                ArrayList arr = (ArrayList)Session["key"];
     
                //string[] ud = arr[0].ToString();
                lblFirstName.Text = arr[0].ToString();

                lblLastName.Text = arr[1].ToString();
                lblPhone.Text = arr[2].ToString();
                lblAddress.Text = arr[3].ToString();
                lblCity.Text = arr[4].ToString();
                lblStateCode.Text = arr[5].ToString();
                //what is random object
                Random r = new Random();
                txnid.Value = (Convert.ToString(r.Next(1000, 20000)));
                txnid.Value = "Prince" + txnid.Value.ToString();
                Response.Write(txnid.Value.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Double amount = Convert.ToDouble(lblPrice.Text);

            String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + "Women Tops" + "|"  + "|"  + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
            //Response.Write(text);
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            hash.Value = hex;

            System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
            data.Add("hash", hex.ToString());
            data.Add("txnid", txnid.Value);
            data.Add("key", key.Value);
            // string AmountForm = ;// eliminating trailing zeros

            data.Add("amount", amount);
           
            data.Add("productinfo", "Women Tops");
            data.Add("udf1", "1");
            data.Add("udf2", "1");
            data.Add("udf3", "1");
            data.Add("udf4", "1");
            data.Add("udf5", "1");

            data.Add("surl", "http://localhost:2399/SuccessPayment.aspx");
            data.Add("furl", "http://localhost:2399/FailurePayment.aspx");

            data.Add("service_provider", "");


            string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
            Page.Controls.Add(new LiteralControl(strForm));



        }
        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
    }
}