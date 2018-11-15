using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    NyhederFac objNyhed = new NyhederFac();
    EventsFac objEvent = new EventsFac();
    KontaktFac objKontakt = new KontaktFac();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["Userlevel"] != null)
        {
            litMinSideLink.Text = "<li><a href='MinSide.aspx'>Mine side</a></li>";
        }
        dr = objNyhed.getLastestNyheder();
        litSenesteNy.Text += "<div id=letestNyhed><h2>Seneste Nyt</h2>";
        litSenesteNy.Text += "<h3>" + dr["fldDato"].ToString().Replace("00:00:00", "").Trim() + "</h3>";
        litSenesteNy.Text += "<h4>" + dr["fldNavn"].ToString() + "</h4>";
        litSenesteNy.Text += "<h3><i>" + dr["fldNyhedtitle"] + "</i></h3>";
        litSenesteNy.Text += "<h4>" + dr["fldNyhed"] + "</h4>";
        litSenesteNy.Text += "</div>";
        // add link to nyhed

        litPastEvents.Text += "<div>";
        litPastEvents.Text += "<h2>Tidligere aktiviteter</h2>";
        foreach (DataRow _event in objEvent.getLast3Events().Rows)
        {
            litPastEvents.Text += "<div style='margin-left:10px;'><p>" + _event["fldTypeNavn"] + "</p>";
            litPastEvents.Text += "<p>" + _event["fldDato"] + "</p>";
            litPastEvents.Text += "<img src='Img/" + _event["fldEventImage"] + "' style='width:130px;height:130px;float:left;' /><div style='clear: both; '></div></div>";
            //add link
        }
        litPastEvents.Text += "</div>";

        //Kontakt information
        dr = objKontakt.getKontakt();
        litKontakt.Text += "<ul><li>" + dr["fldFirmaNavn"].ToString() + "</li>";
        litKontakt.Text += "<li>Formand " + dr["fldNavn"].ToString() + "</li>";
        litKontakt.Text += "<li>email: " + dr["fldEmail"].ToString() + "- tlf: " + dr["fldTelfon"].ToString() + "</li>";
        litKontakt.Text += "</ul>";




    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch != null)
        {
            Response.Redirect("soeg.aspx?Soegt=" + txtSearch.Text);
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
