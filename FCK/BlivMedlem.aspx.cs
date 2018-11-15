using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BlivMedlem : System.Web.UI.Page
{
    BrugerFac objLogin = new BrugerFac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (DataRow _gender in objLogin.getALLGender().Rows)
            {

                ddlSex.Items.Add(new ListItem(_gender["fldSex"].ToString(), _gender["fldKoenID"].ToString()));
            }
            ddlSex.Items.Insert(0, new ListItem("-- Vælg køn --"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        userprop objUser = new userprop();

        objUser._Password = objLogin.GetSH1(txtPassword.Text); //Encrypt password
        objUser._UserName = txtNavn.Text.Replace(" ", string.Empty);
        objUser._Email = txtEmail.Text;
        objUser._Adresse = txtAdresse.Text;
        objUser._Telfon = Convert.ToInt32(txtMobil.Text);
        objUser._Postnr = Convert.ToInt32(txtPost.Text);
        objUser._Navn = txtNavn.Text;
        objUser._Levelid = 3;
        objLogin._DogName = txtDogName.Text;
        objLogin._DogBirth = Convert.ToDateTime(txtBirthday.Text);
        objLogin._DogGender = Convert.ToInt32(ddlSex.SelectedValue);


        if (txtDogName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('udfyld alle felter.');", true);

        }
        else if (txtDogName.Text != "" && txtBirthday.Text != "" && ddlSex.SelectedIndex > 0)
        {

            if (chbVaccine.Checked)
            {
                objLogin._Vaccine = 1;
            }
            else
            {
                objLogin._Vaccine = 0;
            }
            if (txtNavn.Text != "" && txtPassword.Text != "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('New user created.');", true);
                txtNavn.Text = "";
                txtPassword.Text = "";
                objLogin.addUser(objUser);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('udfyld alle felter.');", true);
            }
        }

    }
}
