using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Traening : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();

    protected void Page_Load(object sender, EventArgs e)
    {

        foreach (DataRow _event in objEvent.getAllTraining().Rows)
        {
            litTraining.Text += "<div><img src='Img/" + _event["fldEventImage"] + "'/>";
            litTraining.Text += "<h2>" + _event["fldTypeNavn"] + "</h2>";
            litTraining.Text += "<h4>" + _event["fldDato"] + "</h4>";
            litTraining.Text += "<p>" + _event["fldBeskrivelse"] + "</p>";
            litTraining.Text += "<a href='TraeningDetail.aspx?ID=" + _event["fldAktibitetID"] + "'>Læs &raquo;</a>";
        }
    }
}