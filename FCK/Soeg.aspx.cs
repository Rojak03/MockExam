using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Soeg : System.Web.UI.Page
{
    SearchFac objSoeg = new SearchFac();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Soegord = Request.QueryString["soegt"];
            if (Soegord == "")
            {
                litSoegord.Text = "Brug siden søgefelt herover for at foretage en søgning";
            }
            else
            {
                litSoegord.Text = "<h4>Du har søgt på<i> " + Soegord + "</i> - følgende aktiviteter matcher dun søgning:";
            }

            dt = objSoeg.sreachEvents(Soegord);
            int soegCount;

            soegCount = 0;

            foreach (DataRow soegt in dt.Rows)
            {
                litResultat.Text += "<div class='resultBox'><h2>" + soegt["fldTypeNavn"] + "</h2>";
                litResultat.Text += "<p> Oprettet: " + soegt["fldDato"] + "</p>";
                //litResultat.Text += "<img src='Img/Cat/" + soegt["fldKategoriImage"] + "'/>";
                litResultat.Text += "<a class='link' href='AktiviteterDetail.aspx?ID=" + soegt["fldAktibitetID"] + "'>Læs mere</a></div>";
                soegCount++;
            }
            litAntal.Text = "<h4><i>" + soegCount.ToString() + "</i> nyheder matcher din søgning.";

        }


    }
}
