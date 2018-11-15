using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AtVaereHundeejer : System.Web.UI.Page
{
    NyhederFac objNyhed = new NyhederFac();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        dr = objNyhed.getAtVaereHundejerIntro();

        litIntro.Text += "<h3>" + dr["fldNyhedTitle"].ToString() + "</h3><br/>";
        litIntro.Text += "<p>" + dr["fldDato"].ToString() + "</p><br/>";
        litIntro.Text += "<h3>" + dr["fldNavn"].ToString() + "</h3><br/><br/>";
        litIntro.Text += "<p>" + dr["fldNyhed"].ToString() + "</p>";


        foreach (DataRow _nyhed in objNyhed.getLast3Nyhed().Rows)
        {
            litTidligereNyheder.Text += "<h3>" + _nyhed["fldNyhedTitle"].ToString() + "</h3><br/>";
            litTidligereNyheder.Text += "<p>" + _nyhed["fldDato"].ToString() + "</p><br/>";
            litTidligereNyheder.Text += "<h3>" + _nyhed["fldNavn"].ToString() + "</h3><br/><br/>";
            litTidligereNyheder.Text += "<p>" + _nyhed["fldNyhed"].ToString() + "</p>";
        }

    }
}