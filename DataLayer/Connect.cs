using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataLayer
{
    [Serializable]
    public class Connect
    {
        public string servername;

        public string ServerName
        {
            get { return servername; }
            set { servername = value; }
        }

        public string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string passwd;

        public string PassWd
        {
            get { return passwd; }
            set { passwd = value; }
        }

        public string database;

        public string DataBase
        {
            get { return database; }
            set { database = value; }
        }

        public Connect(string _servername, string _username, string _passwd, string _database)
        {
            this.servername = _servername;
            this.username = _username;
            this.passwd = _passwd;
            this.database = _database;
        }

        public void SaveFile()
        {
            if (File.Exists("connectdb.dba"))
                File.Delete("connectdb.dba");
            FileStream fs = File.Open("connectdb.dba", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
    }
}
