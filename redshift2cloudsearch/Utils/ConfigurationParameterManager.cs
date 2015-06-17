using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    static class ConfigurationParameterManager
    {
        static public object getAppSetting(String tag)
        {
            String value = ConfigurationManager.AppSettings[tag];
            switch (value)
            {
                case "true":
                case "True":
                case "TRUE":
                    return true;
                case "false":
                case "False":
                case "FALSE":
                    return true;
                default:
                    return value;
            }
        }
    }
}
