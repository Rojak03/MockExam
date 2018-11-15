using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        userprop objProp = new userprop();
        BrugerFac objLogin = new BrugerFac();

        objProp._Password = objLogin.GetSH1(txtPassword.Text);
        objProp._UserName = txtUsername.Text;

        objProp = objLogin.login(objProp);
        if (objProp._Userid > 0)
        {
            Session["Userlevel"] = objProp._Levelid;
            Session.Timeout = 60;
            if (Session["Userlevel"] != null)
            {
                // int lvl = Convert.ToInt32(Session["Brugerlvl"]);
                string lvl = Session["Userlevel"].ToString();
                Session["UserID"] = objProp._Userid;
                int userlvl = Convert.ToInt32(lvl);
                if (userlvl == 3)
                {
                    Response.Redirect("Default.aspx");
                }
                else if (userlvl == 2 || userlvl == 1)
                {
                    Response.Redirect("Admin/OpretEvent.aspx");
                }

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong username or password.');", true);
        }
    }
}
