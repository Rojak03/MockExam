using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    string Conn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;


    /// <summary>
    /// Griber en SQL-SELECT-sætning og returnerer data fra databasen
    /// </summary>
    /// <param name="CMD">SQLsætningen som en SqlCommand</param>
    /// <returns>Returnerer en datatable med resultatet af SELECT-sætningen</returns>
    public DataTable GetData(SqlCommand CMD)
    {
        // Connect til databasen og tag CMD ("SQL") med
        SqlConnection objConn = new SqlConnection(Conn);
        CMD.Connection = objConn;

        SqlDataAdapter objDA = new SqlDataAdapter();
        objDA.SelectCommand = CMD;

        // Modtag resultatet
        DataTable dt = new DataTable();
        objDA.Fill(dt);

        // Og returner det til "spørgeren" (request'et)
        return dt;
    }


    /// <summary>
    /// Griber en SQL-sætning til enten INSERT, UPDATE eller DELETE
    /// </summary>
    /// <param name="CMD">SQLsætningen som en SqlCommand</param>
    /// <returns>Antal (int) rækker som blev oprettet, rettet eller slette i tabellen</returns>
    public int ModifyData(SqlCommand CMD)
    {

        SqlConnection objConn = new SqlConnection(Conn);
        CMD.Connection = objConn;
        objConn.Open();
        int rowsaffected = CMD.ExecuteNonQuery();
        objConn.Close();
        return rowsaffected;
    }
    ///<summary>
    ///This Method inserts data and returns the ID of the inputted data
    /// </summary>
    /// <param name="CMD">SQL command for the database</param>
    /// <returns>Returnerer et tal som er id på den netop oprettede post</returns>
    public int InsertDataGetNewID(SqlCommand CMD)
    {
        SqlConnection objConn = new SqlConnection(Conn);
        int newid;
        try
        {
            CMD.CommandText = CMD.CommandText + "; SELECT SCOPE_IDENTITY();";
            CMD.Connection = objConn;
            objConn.Open();
            newid = Convert.ToInt32(CMD.ExecuteScalar());
        }
        finally
        {

            objConn.Close();
        }
        return newid;
    }
    public int ModifyDataGetRows(SqlCommand CMD)
    {
        SqlConnection objConn = new SqlConnection(Conn);
        CMD.Connection = objConn;
        objConn.Open();

        int i = CMD.ExecuteNonQuery();

        objConn.Close();

        return i;
    }

}

