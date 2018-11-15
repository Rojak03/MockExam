using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretEvent : System.Web.UI.Page
{
    EventsFac objEvent = new EventsFac();
    BrugerFac objBruger = new BrugerFac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (DataRow _type in objEvent.getAllTypes().Rows)
            {

                ddlType.Items.Add(new ListItem(_type["fldTypeNavn"].ToString(), _type["fldTypeID"].ToString()));
            }
            ddlType.Items.Insert(0, new ListItem("-- Vælg typer --"));

            foreach (DataRow _roles in objEvent.getAllRoles().Rows)
            {

                ddlRoles.Items.Add(new ListItem(_roles["fldRoleNavn"].ToString(), _roles["fldRoleID"].ToString()));
            }
            ddlRoles.Items.Insert(0, new ListItem("-- Vælg Role --"));

            foreach (DataRow _kategori in objEvent.getAllKategori().Rows)
            {

                ddlKategori.Items.Add(new ListItem(_kategori["fldKatNavn"].ToString(), _kategori["fldKatID"].ToString()));
            }
            ddlKategori.Items.Insert(0, new ListItem("-- Vælg kategori --"));

            foreach (DataRow _bruger in objBruger.getAllInstructors().Rows)
            {

                ddlPersons.Items.Add(new ListItem(_bruger["fldNavn"].ToString(), _bruger["fldLoginID"].ToString()));
            }
            ddlPersons.Items.Insert(0, new ListItem("-- Vælg Instruktør --"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ////Title = type
        objEvent._type = Convert.ToInt32(ddlType.SelectedValue);
        ////description
        objEvent._eventDesc = txtBeskrivelse.Text;
        //location
        objEvent._eventLoc = txtSted.Text;
        // date
        objEvent._eventTime = Convert.ToDateTime(txtDato.Text);
        // rules
        objEvent._eventRules = txtRules.Text;
       // picture
       
       // kate - "
       objEvent._eventKat = Convert.ToInt32(ddlKategori.SelectedValue);
        // person -
        objEvent._instructor = Convert.ToInt32(ddlPersons.SelectedValue);
        // Role -
        objEvent._role = Convert.ToInt32(ddlRoles.SelectedValue);
    }
}