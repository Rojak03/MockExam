using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NyhederFac
/// </summary>
public class NyhederFac
{
    public string _nyhedTitle { get; set; }
    public string _nyhed { get; set; }
    public DateTime _datoNyhed { get; set; }
    public int _nyhedOpretter { get; set; }
    public int _nyhedID { get;  set;}

    DataAccess DA = new DataAccess();
    string strSQL;
    SqlCommand CMD;

    //Get all Nyheder
    public DataTable getAllNyheder()
    {
        strSQL = "SELECT fldNyhedID, fldNyhedTitle, fldNyhed, fldDato, fldNavn FROM tblNyhed INNER JOIN tblBruger ON fldOprettet_FK = fldLoginID";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get newest Nyheder
    public DataRow getLastestNyheder()
    {
        strSQL = "SELECT fldNyhedID, fldNyhedID, fldNyhedTitle, fldNyhed, fldDato, fldNavn FROM tblNyhed INNER JOIN tblBruger ON fldOprettet_FK = fldLoginID WHERE fldDato = (SELECT MAX(fldDato) FROM tblNyhed)";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD).Rows[0];
    }
    //Get 3 past news
    public DataTable getLast3Nyhed()
    {
        strSQL = "SELECT TOP 3 fldNyhedID, fldNyhedID, fldNyhedTitle, fldNyhed, fldDato, fldNavn FROM tblNyhed INNER JOIN tblBruger ON fldOprettet_FK = fldLoginID WHERE fldDato < getdate() ORDER BY fldDato ";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);

    }
    //Get nyheder by ID
    public DataRow getNyhedByID(int ID)
    {
        strSQL = "SELECT fldNyhedID, fldNyhedTitle, fldNyhed, fldDato, fldNavn FROM tblNyhed INNER JOIN tblBruger ON fldOprettet_FK = fldLoginID WHERE fldNyhedID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", ID);
        return DA.GetData(CMD).Rows[0];
    }
    //Get intro for AtVæreHundeejer
    public DataRow getAtVaereHundejerIntro()
    {
        strSQL = "SELECT fldNyhedID, fldNyhedTitle, fldNyhed, fldDato, fldNavn FROM tblNyhed INNER JOIN tblBruger ON fldOprettet_FK = fldLoginID WHERE fldNyhedID = 12";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD).Rows[0];
    }


    //Modify Nyheder

    //Opret Nyheder
    public void createNyheder()
    {
        strSQL = "INSERT INTO tblNyhed (fldNyhedTitle, fldNyhed, fldDato) VALUES (@Title, @Nyhed, @Dato)";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@Title", _nyhedTitle);
        CMD.Parameters.AddWithValue("@Nyhed", _nyhed);
        CMD.Parameters.AddWithValue("@Dato", _datoNyhed);
        DA.ModifyData(CMD);
    }
    public void editNyheder(int id)
    {
        strSQL = "UPDATE tblNyhed SET fldNyhedTitle = @Title, fldNyhed = @Nyhed, fldDato = @Dato, fldOprettet_FK = @Opret WHERE fldNyhedID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@Title", _nyhedTitle);
        CMD.Parameters.AddWithValue("@Nyhed", _nyhed);
        CMD.Parameters.AddWithValue("@Dato", _datoNyhed);
        CMD.Parameters.AddWithValue("@Opret", 1);
        CMD.Parameters.AddWithValue("@id", id);
        DA.ModifyData(CMD);
       
    }

    public void deleteNyhed(int id)
    {
        strSQL = "DELETE FROM tblNyhed WHERE fldNyhedID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", id);
        DA.ModifyData(CMD);
    }
}