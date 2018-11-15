using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KontaktFac
/// </summary>
public class KontaktFac
{
    DataAccess DA = new DataAccess();
    SqlCommand CMD;
    string strSQL;
    //Get Kontakt info
    public DataRow getKontakt()
    {
        strSQL = "SELECT k.fldKontaktID, k.fldFirmaNavn, k.fldEmail, k.fldTelfon, b.fldNavn FROM tblKontakt as k INNER JOIN tblBruger as b ON k.fldFormand_FK = b.fldLoginID";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD).Rows[0];
    }

    //Get Om text from Database
    public DataRow getOmText()
    {
        strSQL = "SELECT fldOmTitle, fldOmSubTitle, fldOmText FROM tblOm";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD).Rows[0];
    }
}