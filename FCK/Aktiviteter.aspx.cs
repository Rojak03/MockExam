using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aktiviteter : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();

    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (DataRow _event in objEvent.getAktiviteter().Rows)
        {
            litArtiviteter.Text += "<div><img src='Img/" + _event["fldEventImage"] + "'/>";
            litArtiviteter.Text += "<h2>" + _event["fldTypeNavn"] + "</h2>";
            litArtiviteter.Text += "<h4>" + _event["fldDato"] + "</h4>";
            litArtiviteter.Text += "<p>" + _event["fldBeskrivelse"] + "</p>";
            litArtiviteter.Text += "<a href='AktiviteterDetail.aspx?ID=" + _event["fldAktibitetID"] + "'>Læs &raquo;</a>";
        }
    }
}