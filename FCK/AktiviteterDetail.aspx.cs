using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AktiviteterDetail : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            dr = objEvent.getEventByID(Convert.ToInt32(Request.QueryString["ID"].ToString()));
            litEvent.Text += "<div><h1>" + dr["fldTypeNavn"].ToString() +" " + dr["fldDato"].ToString() + "</h1>";
            litEvent.Text += "<img src='Img/" + dr["fldEventImage"].ToString() + "'/>";
            litEvent.Text += "<p>" + dr["fldBeskrivelse"].ToString() + "</p><br/>";
            litEvent.Text += "<p><b>Sted: " + dr["fldSted"].ToString() + "</b></p>";
            litEvent.Text += "<p><b>" + dr["fldRoleNavn"].ToString() + ":</b> "+ dr["fldNavn"] +"</p>";
            litEvent.Text += "</div>";
            //add location
        }
    }
}