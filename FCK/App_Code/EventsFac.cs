using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventsFac
/// </summary>
public class EventsFac
{
    public int _instructor { get; set; }
    public int _role { get; set; }
    public int _type { get; set; }
    public string _eventImage { get; set; }
    public DateTime _eventTime { get; set; }
    public string _eventDesc { get; set; }
    public string _eventRules { get; set; }
    public string _eventLoc { get; set; }
    public int _eventKat { get; set; }


    DataAccess DA = new DataAccess();
    SqlCommand CMD;
    string strSQL;

    //Get all Events
    public DataTable getALLEvents()
    {
        strSQL = "SELECT e.fldAktibitetID, e.fldBeskrivelse, e.fldDato, e.fldEventImage, e.fldForudsaetninger, e.fldSted, t.fldTypeNavn, r.fldRoleNavn, b.fldNavn FROM tblEvents  as e INNER JOIN tblType as t on e.fldType_FK = t.fldTypeID INNER JOIN tblAnsvarligt as a  on e.fldAnsvarligt_FK = a.fldAnsvarID INNER JOIN tblBruger as b ON a.fldAnsvarligt_FK = b.fldLoginID INNER JOIN tblRoles as r ON a.fldRole_FK = r.fldRoleID";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    // get all events with category Traning and prøver
    public DataTable getAllTraining()
    {
        strSQL = "SELECT t.fldTypeNavn, e.fldEventImage, e.fldDato, e.fldBeskrivelse, e.fldAktibitetID, k.fldKatNavn FROM tblEvents as e INNER JOIN tblType as t ON e.fldType_FK = t.fldTypeID INNER JOIN tblKategori as k ON t.fldKat_fk = k.fldKatID WHERE k.fldKatID > 1 ORDER BY e.fldDato";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get træning by ID
    public DataRow getEventByID(int id)
    {
        strSQL = "SELECT e.fldAktibitetID,b.fldNavn, r.fldRoleNavn, t.fldTypeNavn, e.fldEventImage, e.fldDato, e.fldBeskrivelse,  e.fldForudsaetninger, e.fldSted, k.fldKatNavn FROM tblEvents as e INNER JOIN tblType as t ON e.fldType_FK = t.fldTypeID INNER JOIN tblKategori as k ON t.fldKat_fk = k.fldKatID INNER JOIN tblAnsvarligt as a ON e.fldAnsvarligt_FK = a.fldAnsvarID INNER JOIN tblBruger as b ON a.fldAnsvarligt_FK = b.fldLoginID INNER JOIN tblRoles as r ON a.fldRole_FK = r.fldRoleID WHERE e.fldAktibitetID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", id);
        return DA.GetData(CMD).Rows[0];
    }
    //Get all Aktiviteter
    public DataTable getAktiviteter()
    {
        strSQL = "SELECT t.fldTypeNavn, e.fldEventImage, e.fldDato, e.fldBeskrivelse, e.fldAktibitetID, k.fldKatNavn FROM tblEvents as e INNER JOIN tblType as t ON e.fldType_FK = t.fldTypeID INNER JOIN tblKategori as k ON t.fldKat_fk = k.fldKatID WHERE k.fldKatID = 1 ORDER BY e.fldDato";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get top 3 Events
    //Get top 3 events before date
    public DataTable getLast3Events()
    {
        strSQL = "SELECT TOP 3 e.fldAktibitetID, e.fldDato, t.fldTypeNavn, e.fldEventImage FROM tblEvents as e INNER JOIN tblType as t ON e.fldType_FK = t.fldTypeID WHERE e.fldDato < getdate() ORDER BY e.fldDato ";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);

    }
    //get 3 events after current date
    public DataTable get3RandomComingEvents()
    {
        strSQL = "SELECT TOP 3 e.fldAktibitetID, e.fldDato, t.fldTypeNavn, e.fldBeskrivelse, e.fldEventImage FROM tblEvents as e INNER JOIN tblType as t ON e.fldType_FK = t.fldTypeID WHERE e.fldDato > getdate() ORDER BY e.fldDato";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get all types
    public DataTable getAllTypes()
    {
        strSQL = "SELECT fldTypeID, fldTypeNavn FROM tblType";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get all Roles
    public DataTable getAllRoles()
    {
        strSQL = "SELECT fldRoleID, fldRoleNavn FROM tblRoles";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get all Kategori
    public DataTable getAllKategori()
    {
        strSQL = "SELECT fldKatID, fldKatNavn FROM tblKategori";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    // Create Event
    public void createNyheder()
    {
        strSQL = "INSERT INTO tblEvents (fldSted,fldDato, fldForudsaetninger, fldType_FK, fldBeskrivelse, fldEventImage, fldAnsvarligt_FK) VALUES (@Sted, @Dato, @Rules, @type, @Desc, @Image, @Name)";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@Sted", _eventLoc);
        CMD.Parameters.AddWithValue("@Dato", _eventTime);
        CMD.Parameters.AddWithValue("@Rules", _eventRules);
        CMD.Parameters.AddWithValue("@type", _type);
        CMD.Parameters.AddWithValue("@Desc", _eventDesc);
        CMD.Parameters.AddWithValue("@Image", _eventImage);
        CMD.Parameters.AddWithValue("@Name", _instructor);
        DA.ModifyData(CMD);
    }
    public void editEvent(int id)
    {
        strSQL = "UPDATE tblEvents SET fldNyhedTitle = @Title, fldNyhed = @Nyhed, fldDato = @Dato, fldOprettet_FK = @Opret WHERE fldNyhedID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@Sted", _eventLoc);
        CMD.Parameters.AddWithValue("@Dato", _eventTime);
        CMD.Parameters.AddWithValue("@Rules", _eventRules);
        CMD.Parameters.AddWithValue("@type", _type);
        CMD.Parameters.AddWithValue("@Desc", _eventDesc);
        CMD.Parameters.AddWithValue("@Image", _eventImage);
        CMD.Parameters.AddWithValue("@Name", _instructor);
        DA.ModifyData(CMD);

    }

    public void deleteEvent(int id)
    {
        strSQL = "DELETE FROM tblEvent WHERE fldAktibitetID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", id);
        DA.ModifyData(CMD);
    }
}