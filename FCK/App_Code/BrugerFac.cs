using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for BrugerFac
/// </summary>
public class userprop
{
    //Bruger Info
    public int _Userid { get; set; }
    public string _UserName { get; set; }
    public int _Levelid { get; set; }
    public string _Password { get; set; }
    public string _Navn { get; set; }
    public string _Adresse { get; set; }
    public int _Telfon { get; set; }
    public int _Postnr { get; set; }
    public string _Email { get; set; }
}


public class BrugerFac
{

    //Dog info
    public string _DogName { get; set; }
    public DateTime _DogBirth { get; set; }
    public int _DogGender { get; set; }
    public int _Owner { get; set; }
    public int _Vaccine { get; set; }


    DataAccess DA = new DataAccess();
    SqlCommand CMD;
    string strSQL;
    //Login
    public userprop login(userprop props)
    {

        DataAccess objdata = new DataAccess();
        SqlCommand CMD = new SqlCommand();

        CMD = new SqlCommand("SELECT fldUsernavn, fldLoginID, fldUserLevel FROM tblBruger WHERE fldPassword = @password AND fldUsernavn = @username");
        CMD.Parameters.AddWithValue("@password", props._Password);
        CMD.Parameters.AddWithValue("@username", props._UserName);

        DataTable DtUser = objdata.GetData(CMD);
        userprop _user = new userprop();

        if (DtUser.Rows.Count > 0)
        {
            _user._Userid = Convert.ToInt32(DtUser.Rows[0]["fldLoginID"]);
            _user._UserName = DtUser.Rows[0]["fldUsernavn"].ToString();
            _user._Levelid = Convert.ToInt32(DtUser.Rows[0]["fldUserLevel"]);
        }
        return _user;
    }
    //Get all User info
    public DataTable getAllUsers()
    {
        strSQL = "SELECT b.fldLoginID, b.fldUsernavn, b.fldPassword, b.fldNavn, b.fldAdresse, b.fldEmail, b.fldPostnr, b.fldTelefon, b.fldUserLevel, d.fldDogID, d.fldNavn, d.fldBirthday, d.fldVaccine, k.fldSex FROM tblBruger as b INNER JOIN tblDog as d ON b.fldLoginID = d.fldOwner_FK INNER JOIN tblKoen as k ON d.fldSex_FK = k.fldKoenID ";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Get user by ID
    public DataRow getUserByID(int id)
    {
        strSQL = "SELECT b.fldLoginID, b.fldUsernavn, b.fldPassword, b.fldNavn, b.fldAdresse, b.fldEmail, b.fldPostnr, b.fldTelefon, b.fldUserLevel, d.fldDogID, d.fldNavn, d.fldBirthday, d.fldVaccine, k.fldSex FROM tblBruger as b INNER JOIN tblDog as d ON b.fldLoginID = d.fldOwner_FK INNER JOIN tblKoen as k ON d.fldSex_FK = k.fldKoenID WHERE b.fldLoginID = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", id);
        return DA.GetData(CMD).Rows[0];

    }
    public DataRow getDogByUser(int id)
    {
        strSQL = "SELECT d.fldNavn, d.fldBirthday, d.fldVaccine, b.fldNavn, k.fldSex FROM tblDog as d INNER JOIN tblBruger as b ON d.fldOwner_FK  =b.fldLoginID INNER JOIN tblKoen as k ON d.fldSex_FK = k.fldKoenID WHERE d.fldOwner_FK = @id";
        CMD = new SqlCommand(strSQL);
        CMD.Parameters.AddWithValue("@id", id);
        return DA.GetData(CMD).Rows[0];

    }
    //Get all Instructors
    public DataTable getAllInstructors()
    {
        strSQL = "SELECT b.fldNavn, b.fldLoginID FROM tblBruger as b WHERE fldUserLevel = 2";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //Add Bruger

    public string addUser(userprop props)
    {
        CMD = new SqlCommand(@"BEGIN
                                IF NOT EXISTS (SELECT * FROM tblBruger WHERE fldUsernavn = @username)
                                    BEGIN
                                        INSERT INTO tblBruger
                                        (fldUsernavn, fldPassword, fldUserLevel, fldNavn, fldAdresse, fldTelefon, fldPostnr, fldEmail)
                                        VALUES
                                        (@username, @password, @level, @Name, @Adresse, @Telfon, @post, @email)
                                        END
                                        END");
        CMD.Parameters.AddWithValue("@password", props._Password);
        CMD.Parameters.AddWithValue("@username", props._UserName);
        CMD.Parameters.AddWithValue("@level", props._Levelid);
        CMD.Parameters.AddWithValue("@Name", props._Navn);
        CMD.Parameters.AddWithValue("@Adresse", props._Adresse);
        CMD.Parameters.AddWithValue("@Telfon", props._Telfon);
        CMD.Parameters.AddWithValue("@post", props._Postnr);
        CMD.Parameters.AddWithValue("@email", props._Email);


        int i = DA.InsertDataGetNewID(CMD);

        strSQL = "INSERT INTO tblDog (fldNavn, fldBirthday, fldVaccine, fldOwner_FK, fldSex_FK) VALUES (@Name, @Birth, @Vaccine, @Owner, @Gender)";
        CMD = new SqlCommand(strSQL);

        CMD.Parameters.AddWithValue("@Name", _DogName);
        CMD.Parameters.AddWithValue("@Birth", _DogBirth);
        CMD.Parameters.AddWithValue("@Vaccine", _Vaccine);
        CMD.Parameters.AddWithValue("@Owner", i);
        CMD.Parameters.AddWithValue("@Gender", _DogGender);
        DA.ModifyData(CMD);

        string Msg = "";
        if (i > 0)
        {
            Msg = "User created!!";
        }
        else
        {
            Msg = "There is already an User with this name!";
        }
        return Msg;
    }
    //Encrypting of password
    public string GetSH1(string _password)
    {
        SHA1 algorithm = SHA1.Create();
        byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(_password));
        string sh1 = "";
        for (int i = 0; i < data.Length; i++)
        {
            sh1 += data[i].ToString().ToUpperInvariant();
        }
        return sh1;
    }


    //<------DOGS-------->
    // Add Dog By User
    //public void createDog(int id)
    //{
    //    strSQL = "INSERT INTO tblDog (fldNavn, fldBirthday, fldVaccine, fldOwner_FK, fldSex_FK) VALUES (@Name, @Birth, @Vaccine, @Owner, @Gender)";
    //    CMD = new SqlCommand(strSQL);

    //    CMD.Parameters.AddWithValue("@Name", _DogName);
    //    CMD.Parameters.AddWithValue("@Birth", _DogBirth);
    //    CMD.Parameters.AddWithValue("@Vaccine", _Vaccine);
    //    CMD.Parameters.AddWithValue("@Owner", id);
    //    CMD.Parameters.AddWithValue("@Gender", _DogGender);
    //    DA.ModifyData(CMD);
    //}
    public DataTable getALLGender()
    {
        strSQL = "SELECT fldKoenID, fldSex FROM tblKoen";
        CMD = new SqlCommand(strSQL);
        return DA.GetData(CMD);
    }
    //get all dogs
    //get dogs that are vacineated
    //get dogs by sex
    //get dog by owner id
}