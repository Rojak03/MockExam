using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        //string lvl = Session["Userlevel"].ToString();
        //int userlvl = Convert.ToInt32(lvl);

        //if (userlvl == 1)
        //{
        //    litBrugerside.Text = "<li><a href='RetSletOpretBruger.aspx'>Bruger Oplysing</a></li>";
        //}
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Userlevel");
        Response.Redirect("../Default.aspx");
    }
}
