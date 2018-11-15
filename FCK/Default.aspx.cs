using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();
    KontaktFac objKontakt = new KontaktFac();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {

        //Shows Om text from database
        dr = objKontakt.getOmText();
        string strOm = dr["fldOmText"].ToString();

        litOm.Text += "<h1>" + dr["fldOmTitle"].ToString() + "</h1><h2> - " + dr["fldOmSubTitle"].ToString() + "</h2>";
        litOm.Text += "<p>" + strOm.Replace(".", ".<br/><br/>" + System.Environment.NewLine) + "</p>";



        // shows 3 random events after todays date
        foreach (DataRow _events in objEvent.get3RandomComingEvents().Rows)
        {
            litAktiviteter.Text += "<div class='randomEvent'><h4>" + _events["fldTypeNavn"] + "</h4>";
            litAktiviteter.Text += "<p>" + _events["fldDato"] + "</p>";
            litAktiviteter.Text += "<img src='Img/" + _events["fldEventImage"] + "' />";
            litAktiviteter.Text += "<p>" + _events["fldBeskrivelse"] + "</p>";
            //add link
            litAktiviteter.Text += "</div>";

        }
    }
}