﻿using DataLayer;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace STOCK
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("connectdb.dba"))
            {
                string conStr = "";
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                Connect cp = (Connect)bf.Deserialize(fs);

                string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                string passwd = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
                string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);

                conStr += "Data Source=" + servername +
                    "; Initial Catalog=" + database +
                    "; User ID=" + username +
                    "; Password = " + passwd +
                    ";";
                connoi = conStr;
                //myFunctions._srv = servername;
                //myFunctions._us = username;
                //myFunctions._pw = passwd;
                //myFunctions._db = database;
                SqlConnection con = new SqlConnection(conStr);

                try
                {
                    con.Open();
                    //Application.Run(new MainForm());
                }
                catch
                {
                    MessageBox.Show("Không thể kết nối CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                }
                con.Close();
                fs.Close();
                Application.Run(new MainForm());
                //if (File.Exists("sysparam.ini"))
                //{
                //    Application.Run(new frmLogin());
                //}
                //else
                //{
                //    Application.Run(new frmSetParam());
                //}
            }
            else
            {
                Application.Run(new frmConnect());
            }
        }
        public static string connoi = string.Empty;
    }
}
