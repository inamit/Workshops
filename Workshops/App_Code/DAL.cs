using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Drawing;

/// <summary>
/// A class to handle all database requests.
/// </summary>
public class DAL
{
    private static OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;Persist Security Info=True");
    
    public static string GetPermission(string username, string password)
    {
        string perm = "false";
        conn.Open();
        string cmdStr = string.Format("SELECT * FROM MyUsers WHERE (MyEmail='{0}' AND MyPassword='{1}')", username, password);
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        OleDbDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
            perm = "parent";
        else
        {
            dr.Close();
            cmdStr = string.Format("SELECT * FROM MyCounselors WHERE (MyEmail='{0}' AND MyPassword='{1}')", username, password);
            cmd.CommandText = cmdStr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
                perm = "counselor";
            else
            {
                dr.Close();
                cmdStr = string.Format("SELECT * FROM MyStaff WHERE (MyEmail='{0}' AND MyPassword='{1}')", username, password);
                cmd.CommandText = cmdStr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    perm = "admin";
            }
        }
        return perm;
    }

    #region Show workshops to users
    public static DataSet GetWorkshops()
    {
        conn.Open();
        string cmdStr = "SELECT * FROM MyWorkshops";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public static OleDbDataReader GetWorkshopBy(string id)
    {
        conn.Open();
        string cmdStr = "SELECT * FROM MyWorkshops WHERE ID=" + id;
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        OleDbDataReader dr = cmd.ExecuteReader();
        return dr;
    }
    #endregion

    #region Register methods
    public static int Register(string email, string fname, string lname, string pass, string phone, string country, string state)
    {
        conn.Open();
        string cmdStr = string.Format("INSERT INTO MyUsers (MyFirst, MyLast, MyEmail, MyCountry, MyState, MyPassword, MyPhone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", fname, lname, email, country, state, pass, phone);
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        int num = cmd.ExecuteNonQuery();
        conn.Close();
        return num;
    }
    public static DataSet GetCountries()
    {
        conn.Open();
        string cmdStr = "SELECT * FROM MyCountries ORDER BY Country";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataSet GetStates()
    {
        conn.Open();
        string cmdStr = "SELECT MyCode FROM MyStates ORDER BY MyCode";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public static string GetPhoneCode(string country)
    {
        string phone = "";
        string cmdStr = "SELECT PhoneCode FROM MyCountries WHERE Country='" + country + "'";
            conn.Open();
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        OleDbDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            phone = dr[0].ToString();
        }
        conn.Close();
        return phone;
    }
    #endregion

    #region Admin workshops methods
    public static bool DeleteWorkshop(string id)
    {
        conn.Open();
        string cmdStr = "DELETE FROM MyWorkshops WHERE ID=" + id;
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        int x = 0; // The number of affected rows
        x = cmd.ExecuteNonQuery();
        conn.Close();
        return x > 0;
    }
    public static bool AddWorkshop(string name, string description, string units, string roomNeeds, string campersNeeds, string image)
    {
        conn.Open();
        string cmdStr = string.Format("INSERT INTO MyWorkshops (MyName, MyDescription, MyUnits, MyRoomNeeds, MyCamperNeeds, MyImage) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", name, description, units, roomNeeds, campersNeeds, image);
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        int num = cmd.ExecuteNonQuery();
        conn.Close();
        return num == 1;
    }
    public static bool EditWorkshop(string name, string description, string units, string roomNeeds, string campersNeeds, string id)
    {
        conn.Open();
        string cmdStr = string.Format("UPDATE MyWorkshops SET MyName='{0}', MyDescription='{1}', MyUnits='{2}', MyRoomNeeds='{3}', MyCamperNeeds='{4}) WHERE ID={5}", name, description, units, roomNeeds, campersNeeds, id);
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        int num = cmd.ExecuteNonQuery();
        conn.Close();
        return num == 1;
    }
    public static bool EditWorkshop(string name, string description, string units, string roomNeeds, string campersNeeds, string image, string id)
    {
        conn.Open();
        string cmdStr = string.Format("UPDATE MyWorkshops SET MyName='{0}', MyDescription='{1}', MyUnits='{2}', MyRoomNeeds='{3}', MyCamperNeeds='{4}', MyImage='{5}' WHERE ID={6}", name, description, units, roomNeeds, campersNeeds, image, id);
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        int num = cmd.ExecuteNonQuery();
        conn.Close();
        return num == 1;
    }
    #region Needs methods
    public static DataSet GetRoomNeeds()
    {
        conn.Open();
        string cmdStr = "SELECT * FROM MyRoomNeeds";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataSet GetCampersNeeds()
    {
        conn.Open();
        string cmdStr = "SELECT * FROM MyCampersNeeds";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        return ds;
    }

    public static void AddRoomNeeds(string need)
    {
        conn.Open();
        string cmdStr = "INSERT INTO MyRoomNeeds (MyNeed) VALUES ('" + need + "'";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public static void AddCampersNeeds(string need)
    {
        conn.Open();
        string cmdStr = "INSERT INTO MyCampersNeeds (MyNeed) VALUES ('" + need + "'";
        OleDbCommand cmd = new OleDbCommand(cmdStr, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    #endregion

    #endregion

    public static void CloseConnection()
    {
        conn.Close();
    }
}