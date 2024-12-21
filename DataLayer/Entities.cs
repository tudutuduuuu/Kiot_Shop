using System;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataLayer
{
    [Serializable]
    public partial class Entities
    {
        private Entities(DbConnection connectionString, bool contextOwnsConnection = true)
            : base(connectionString, contextOwnsConnection) { }

        public static Entities CreateEntities(bool contextOwnsConnection = true)
        {
            // Doc file connect
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
            Connect cp = (Connect)bf.Deserialize(fs);

            // Decrypt noi dung
            string serverName = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
            string userName = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
            string passWd = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
            string dataBase = Encryptor.Decrypt(cp.database, "qwertyuiop", true);

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder sqlConnectBuilder = new SqlConnectionStringBuilder();
            sqlConnectBuilder.DataSource = serverName;
            sqlConnectBuilder.InitialCatalog = dataBase;
            sqlConnectBuilder.UserID = userName;
            sqlConnectBuilder.Password = passWd;

            string sqlConnectionString = sqlConnectBuilder.ConnectionString;

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlConnectionString;

            entityBuilder.Metadata = @"res://*/KHOHANG.csdl|res://*/KHOHANG.ssdl|res://*/KHOHANG.msl";

            EntityConnection connection = new EntityConnection(entityBuilder.ConnectionString);

            fs.Close();
            return new Entities(connection);
        }
    }
}
