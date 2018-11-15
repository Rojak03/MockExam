using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretteNyhed : System.Web.UI.Page
{
    NyhederFac objNyhed = new NyhederFac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objNyhed._nyhedTitle = txtTitle.Text;
        objNyhed._nyhed = txtNyhed.Text;
        objNyhed._datoNyhed = DateTime.Now.Date;
        if (txtNyhed.Text != "" || txtTitle.Text != "")
        {
            objNyhed.createNyheder();
            //ADD success msg
            txtNyhed.Text = "";
            txtTitle.Text = "";
        }
        else
        {
           //ADD error msg
        }
    }
}