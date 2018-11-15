using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetSletEvent : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();
    BrugerFac objBruger = new BrugerFac();
    int eventID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (DataRow _type in objEvent.getAllTypes().Rows)
            {

                ddlTyper.Items.Add(new ListItem(_type["fldTypeNavn"].ToString(), _type["fldTypeID"].ToString()));
            }
            ddlTyper.Items.Insert(0, new ListItem("-- Vælg typer --"));

            foreach (DataRow _roles in objEvent.getAllRoles().Rows)
            {

                ddlRoles.Items.Add(new ListItem(_roles["fldRoleNavn"].ToString(), _roles["fldRoleID"].ToString()));
            }
            ddlRoles.Items.Insert(0, new ListItem("-- Vælg Role --"));

            foreach (DataRow _kategori in objEvent.getAllKategori().Rows)
            {

                ddlKat.Items.Add(new ListItem(_kategori["fldKatNavn"].ToString(), _kategori["fldKatID"].ToString()));
            }
            ddlKat.Items.Insert(0, new ListItem("-- Vælg kategori --"));

            foreach (DataRow _bruger in objBruger.getAllInstructors().Rows)
            {

                ddlInstructor.Items.Add(new ListItem(_bruger["fldNavn"].ToString(), _bruger["fldLoginID"].ToString()));
            }
            ddlInstructor.Items.Insert(0, new ListItem("-- Vælg Instruktør --"));
            if (int.TryParse(Request.QueryString["ID"], out eventID))
            {
                pnlAlleEvents.Visible = false;
                pnlEnEvent.Visible = true;

                DataRow dr = objEvent.getEventByID(eventID);
                txtDesc.Text = dr["fldBeskrivelse"].ToString();
                txtSted.Text = dr["fldSted"].ToString();
                txtRules.Text = dr["fldForudsaetninger"].ToString();
                txtID.Text = dr["fldAktibitetID"].ToString();
            }
            else
            {
                foreach (DataRow _event in objEvent.getALLEvents().Rows)
                {
                    litAlleEvents.Text += "<div class='event'><h3>" + _event["fldTypeNavn"] + "</h2>";
                    litAlleEvents.Text += "<h4>" + _event["fldDato"].ToString().Replace("00:00:00", "").Trim() + "</h4>";
                    litAlleEvents.Text += "<a href='RetSletEvent.aspx?ID=" + _event["fldAktibitetID"] + "'>Vælg Nyhed</a>";
                    litAlleEvents.Text += "</div>";
                }
            }
        }


    }

    protected void btnRet_Click(object sender, EventArgs e)
    {
        //obj._nyhed = txtNyhed.Text;
        //objNyheder._nyhedTitle = txtTitle.Text;
        //objNyheder._datoNyhed = DateTime.Now;
        //eventID = Convert.ToInt32(txtID.Text);
        //objNyheder.editNyheder(eventID);
        //txtNyhed.Text = "";
        //txtTitle.Text = "";

        ////Title = type
        objEvent._type = Convert.ToInt32(ddlTyper.SelectedValue);
        ////description
        objEvent._eventDesc = txtDesc.Text;
        //location
        objEvent._eventLoc = txtSted.Text;
        // date
        objEvent._eventTime = Convert.ToDateTime(txtDato.Text);
        // rules
        objEvent._eventRules = txtRules.Text;
        // picture

        // kate - "
        objEvent._eventKat = Convert.ToInt32(ddlKat.SelectedValue);
        // person -
        objEvent._instructor = Convert.ToInt32(ddlInstructor.SelectedValue);
        // Role -
        objEvent._role = Convert.ToInt32(ddlRoles.SelectedValue);
        if (txtID.Text != "" || txtDesc.Text != "")
        {
            objEvent.editEvent(eventID);
            txtDato.Text = "";
            txtDesc.Text = "";
            txtRules.Text = "";
            txtSted.Text = "";


        }
    }

    protected void btnSlet_Click(object sender, EventArgs e)
    {
        eventID = Convert.ToInt32(txtID.Text);
        objEvent.deleteEvent(eventID);
        Response.Redirect(Request.RawUrl);
    }
}