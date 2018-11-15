using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchFac
/// </summary>
public class SearchFac
{
    DataAccess DA = new DataAccess();
    SqlCommand CMD;
    string strSQL;

    //Simple Search
    public DataTable sreachEvents(string searchword)
    {
        strSQL = "SELECt e.fldAktibitetID, e.fldBeskrivelse, e.fldDato, e.fldEventImage, e.fldForudsaetninger, e.fldSted, t.fldTypeNavn, r.fldRoleNavn, b.fldNavn FROM tblEvents  as e INNER JOIN tblType as t on e.fldType_FK = t.fldTypeID INNER JOIN tblAnsvarligt as a  on e.fldAnsvarligt_FK = a.fldAnsvarID INNER JOIN tblBruger as b ON a.fldAnsvarligt_FK = b.fldLoginID INNER JOIN tblRoles as r ON a.fldRole_FK = r.fldRoleID WHERE e.fldBeskrivelse LIKE @search OR e.fldDato LIKE @search OR e.fldForudsaetninger LIKE @search OR e.fldSted LIKE @search OR t.fldTypeNavn LIKE @search OR r.fldRoleNavn LIKE @search OR b.fldNavn LIKE @search";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@search", "%" + searchword + "%");
        return DA.GetData(CMD);
    }
    //Advanced Search
    //Advanced Search
    public DataTable AdvSoeg(int _CatId, decimal _FromPrice, decimal _ToPrice, string _KeyWord)
    {
        string _key = "";

        if (_KeyWord != "")
        {
            _key = @" AND (P.FldName LIKE @KeyWord OR P.FldContent LIKE @KeyWord)";
        }

        if (_CatId > 0)
        {

            CMD = new SqlCommand(@"SELECT P.fldProductID, P.fldName, P.fldContent, P.fldPrice, C.fldCategory
                                FROM tblProducts AS P
                                INNER JOIN
                                tblCategory AS C
                                ON
                                P.fldCategory_FK = C.fldCategoryID
                                WHERE
                                P.fldName LIKE @KeyWord
                                AND
                                P.fldPrice
                                BETWEEN
                                @FromPrice
                                AND
                                @ToPrice"
                                  + _key);
            CMD.Parameters.AddWithValue("@CatId", _CatId);
            CMD.Parameters.AddWithValue("@FromPrice", _FromPrice);
            CMD.Parameters.AddWithValue("@ToPrice", _ToPrice);
            CMD.Parameters.AddWithValue("@KeyWord", "%" + _KeyWord + "%");

        }
        else if (_CatId > 0)
        {

            CMD = new SqlCommand(@"SELECT P.fldProductID, P.fldName, P.fldContent, P.FldPrice, C.fldCategory
                                FROM tblProducts AS P
                                INNER JOIN
                                tblCategory AS C
                                ON
                                P.fldCategory_FK = C.fldCategoryID
                                WHERE
                                P.fldName LIKE @KeyWord
                                AND
                                P.fldPrice
                                BETWEEN
                                @FromPrice
                                AND
                                @ToPrice" + _key);

            CMD.Parameters.AddWithValue("@CatId", _CatId);
            CMD.Parameters.AddWithValue("@FromPrice", _FromPrice);
            CMD.Parameters.AddWithValue("@ToPrice", _ToPrice);
            CMD.Parameters.AddWithValue("@KeyWord", "%" + _KeyWord + "%");

        }
        else
        {
            CMD = new SqlCommand(@"SELECT P.fldProductID, P.fldName, P.fldContent, P.fldPrice, C.fldCategory
                                FROM tblproduct AS P
                                INNER JOIN
                                tblCategory AS C
                                ON
                                P.fldCategory = C.fldCategory
                                WHERE
                                P.fldPrice
                                BETWEEN
                                @FromPrice
                                AND
                                @ToPrice" + _key);

            CMD.Parameters.AddWithValue("@FromPrice", _FromPrice);
            CMD.Parameters.AddWithValue("@ToPrice", _ToPrice);
            CMD.Parameters.AddWithValue("@KeyWord", "%" + _KeyWord + "%");
        }

        return DA.GetData(CMD);
    }


}