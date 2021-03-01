using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlNominasAddIn.Data
{
    public class AppSetting
    {
        public static string PERMISOS_KEY = "ControlNominasAddIn.Properties.Settings.PermisosConnectionString";
        public static string RELOJ1_KEY = "ControlNominasAddIn.Properties.Settings.Reloj1ConnectionString";
        public static string RELOJ2_KEY = "ControlNominasAddIn.Properties.Settings.Reloj2ConnectionString";

        Configuration config;
        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        //Get connection string from App.Config file
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        //Save connection string to App.config file
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
           // config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
    }

}
