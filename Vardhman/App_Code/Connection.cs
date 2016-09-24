using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

public class Connection
{
    protected SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter ada;
    SqlDataReader dr;
    SqlConnectionStringBuilder str;
    Vardhman.Main _mainFrm = null;
    public Vardhman.Main MainForm
    {
        get { return _mainFrm; }
        set { _mainFrm = value; }
    }
    private void DisplayMessage(string msg)
    {
        if (_mainFrm != null)
            {
                _mainFrm.DisplayMessage(msg);
            }
            else
            {
                MessageBox.Show(msg);
            }
    }
    public Connection()
    {
        try
        {
            str = new SqlConnectionStringBuilder();
            str.DataSource = @".\sqlexpress";
            str.InitialCatalog = "vardhman";
            str.IntegratedSecurity = true;
            conn = new SqlConnection(str.ConnectionString);
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }
    }
    public Connection(string initialCatalog)
    {
        try
        {
            str = new SqlConnectionStringBuilder();
            str.DataSource = @".\sqlexpress";
            str.InitialCatalog = initialCatalog;
            str.IntegratedSecurity = true;
            conn = new SqlConnection(str.ConnectionString);
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }
    }
    public SqlConnectionStringBuilder connectionstring()
    {
        return str;
    }
    public void connent()
    {
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }
    }
    public void disconnect()
    {
        try
        {
            conn.Close();
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }
    }
    public DataTable getTable(String qurey)
    {
        DataTable dt = new DataTable();

        try
        {
            ada = new SqlDataAdapter(qurey, conn);
            ada.Fill(dt);
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }

        return dt;
    }

    public int exeNonQurey(String qurey)
    {
        int i = 0;

        try
        {
            cmd = new SqlCommand(qurey, conn);
            i = cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }

        return i;
    }
    public DataSet dsentry(string query, string table)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            
            cmd = new SqlCommand(query, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            try { da.Fill(ds); }
            catch (Exception e)
            {
                DisplayMessage(e.Message.ToString());
                throw;
            }
            
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            ds = null;
            throw;
        }
        return ds;
    }
    public SqlDataReader exereader(String qurey)
    {
        try
        {
            cmd = new SqlCommand(qurey, conn);
            dr = cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            DisplayMessage(e.Message.ToString());
            throw;
        }
        return dr;
    }
    public void closereader()
    {
        dr.Close();
    }
    public string exesclr(String qurey)
    {
        string i = "";

        try
        {
            cmd = new SqlCommand(qurey, conn);
            i = cmd.ExecuteScalar().ToString();

        }
        catch (Exception ex)
        {
            DisplayMessage(ex.Message.ToString());
            throw;
        }

        return i;
    }
}
