using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tools
/// </summary>
public class Tools
{
    public static string stringOfWholeWords(string str, int antalTegn)
    {
        int j;
        string strResultat;

        if (str != "")
        {
            if (str.Length >= antalTegn)
            {
                j = str.Substring(0, antalTegn).Length;

                while ((str.Substring(j - 1, 1) != " ") && (j > 1))
                {
                    j = j - 1;
                }

                if ((str.Substring(j - 1, 1)) == " ")
                {
                    strResultat = str.Substring(0, j - 1).TrimEnd(',') + "....";
                }
                else
                {
                    strResultat = str.Substring(0, antalTegn);
                }
            }
            else
            {
                strResultat = str.Substring(0, str.Length);
            }
        }
        else
        {
            strResultat = "Der skal være tekst";
        }
        return strResultat;

    }
}