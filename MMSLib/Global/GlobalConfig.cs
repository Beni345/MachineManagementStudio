using MMSLib.DataAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.Global
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }
        

        public static void InitializeConnection(string dbName)
        {
            MongoCRUD mongoCRUD = new MongoCRUD(dbName);
            Connection = mongoCRUD;
        }

        public static string ConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string DbName(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }
        
    }
}
