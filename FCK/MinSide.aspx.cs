using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MinSide : System.Web.UI.Page
{
    BrugerFac objBruger = new BrugerFac();
    DataRow dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Session["UserID"]);

        if (userID > 0)
        {
            dr = objBruger.getUserByID(userID);

            litOplysing.Text += "<h3>" + dr["fldNavn"].ToString() + "</h2>";
            litOplysing.Text += "<h3>" + dr["fldAdresse"].ToString() + "</h2>";
            litOplysing.Text += "<h3>Email: " + dr["fldEmail"].ToString() + "</h2>";
            litOplysing.Text += "<h3>Mobil: " + dr["fldTelefon"].ToString() + "</h2>";

            dr = objBruger.getDogByUser(userID);

            litDogs.Text += "<h1>" + dr["fldNavn"].ToString() + ": </h1><h2>" + dr["fldSex"].ToString() + ", født:" + dr["fldBirthday"] + "</h2>";
        }

        // add events going too
        // add edit profile
        // able to add and remove dog.
    }
}