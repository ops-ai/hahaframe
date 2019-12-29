using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using HahaFrame.Data.Repository;

namespace HahaFrame.Data
{
    public partial class DataSettingsManager
    {
        public virtual DataSettings LoadSettings()
        {
            var shellSettings = new DataSettings();
            shellSettings.DataConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            shellSettings.DataProvider= "sqlserver";
            return shellSettings;
        }
    }
}
