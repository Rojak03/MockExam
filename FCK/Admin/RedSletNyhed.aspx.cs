using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RedSletNyhed : System.Web.UI.Page
{
    NyhederFac objNyheder = new NyhederFac();
    int nyhedID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (DataRow _nyheder in objNyheder.getAllNyheder().Rows)
            {
                litAlleNyheder.Text += "<div><h3>" + _nyheder["fldNyhedTitle"] + "</h2>";
                litAlleNyheder.Text += "<h4>" + _nyheder["fldDato"].ToString().Replace("00:00:00", "").Trim() + "</h4>";
                litAlleNyheder.Text += "<a href='RedSletNyhed.aspx?ID=" + _nyheder["fldNyhedID"] + "'>Vælg Nyhed</a>";
                litAlleNyheder.Text += "</div>";
            }
            if (int.TryParse(Request.QueryString["ID"], out nyhedID))
            {
                pnlAllNyheder.Visible = false;
                pnlRetNyheder.Visible = true;

                DataRow dr = objNyheder.getNyhedByID(nyhedID);
                txtTitle.Text = dr["fldNyhedTitle"].ToString();
                txtNyhed.Text = dr["fldNyhed"].ToString();
                txtID.Text = dr["fldNyhedID"].ToString();
            }
        }

    }

    protected void btnRet_Click(object sender, EventArgs e)
    {
        objNyheder._nyhed = txtNyhed.Text;
        objNyheder._nyhedTitle = txtTitle.Text;
        objNyheder._datoNyhed = DateTime.Now;
        nyhedID = Convert.ToInt32(txtID.Text);
        objNyheder.editNyheder(nyhedID);
        txtNyhed.Text = "";
        txtTitle.Text = "";
    }

    protected void btnSlet_Click(object sender, EventArgs e)
    {
        nyhedID = Convert.ToInt32(txtID.Text);
        objNyheder.deleteNyhed(nyhedID);
        Response.Redirect(Request.RawUrl);
    }
}