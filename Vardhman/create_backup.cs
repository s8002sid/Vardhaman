using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;
namespace Vardhman
{
    static class create_backup
    {
        public static void create()
        {

            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable("select path from autobackuppath");
            con.disconnect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Directory.Exists(dt.Rows[i][0].ToString()))
                {
                    Directory.CreateDirectory(dt.Rows[i][0].ToString());
                }
                string today = dt.Rows[i][0].ToString() + @"\" + DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
                if (!Directory.Exists(today))
                {
                    Directory.CreateDirectory(today);
                }
                checknumberoffile(today);
                string path = today + @"\" + DateTime.Now.TimeOfDay.Milliseconds.ToString() + "." + DateTime.Now.TimeOfDay.Seconds.ToString() + "." + DateTime.Now.TimeOfDay.Minutes.ToString() + "." + DateTime.Now.TimeOfDay.Hours.ToString() + ".bak";
                db_backup_query(path);
            }
            
        }
        public static void db_backup_query(string path)
        {
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey(string.Format("BACKUP DATABASE vardhman TO DISK = '{0}'", path));
            con.disconnect();
        }

        public static void db_restore_query(string backupPath, string restorePath)
        {
            Connection con = new Connection("master");
            con.connent();
            con.exeNonQurey(string.Format("BACKUP DATABASE vardhman TO DISK = '{0}'", backupPath));
            con.exeNonQurey("ALTER DATABASE vardhman SET Single_User WITH Rollback IMMEDIATE");
            con.exeNonQurey(string.Format("RESTORE DATABASE vardhman FROM DISK = '{0}'", restorePath));
            con.disconnect();
        }

        public static string generate_backup_filename()
        {
            string filename = DateTime.Now.Day.ToString() + "-" + 
                                DateTime.Now.Month.ToString() + "-" + 
                                DateTime.Now.Year + "-" + 
                                DateTime.Now.Hour.ToString() + "." + 
                                DateTime.Now.Minute + "." + 
                                DateTime.Now.Second;
            return filename;
        }
        private static void checknumberoffile(string path)
        {
            string []files = Directory.GetFiles(path);
            ArrayList a = new ArrayList();
            for (int i = 0; i < files.Length; i++)
            {
                a.Add(File.GetCreationTime(files[i]));
            }
            ArrayList a1 = (ArrayList)a.Clone();
            a.Sort();
            for (int i = 0; i < files.Length - 1; i++)
            {
                DateTime d = (DateTime)a[i];
                for (int j = 0; j < files.Length; j++)
                {
                    DateTime d1 = (DateTime)a1[j];
                    if (DateTime.Compare(d1, d) == 0)
                    {
                        File.Delete(files[j]);
                    }
                }
            }
        }
    }
}
