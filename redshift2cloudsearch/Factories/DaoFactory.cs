using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    public static class DaoFactory
    {        
        private static IApplicationLogDao applicationLogDao = null;

        private static IApplicationLogDao getApplicationLogInstance()
        {
                switch (ConfigurationManager.AppSettings["Driver"])
                {
                    case ("ODBC") :
                        applicationLogDao = new ApplicationLogDaoODBC();
                        return applicationLogDao;
                    case ("PostgreSQL"):
                        applicationLogDao = new ApplicationLogDaoPostgreSQL();
                        return applicationLogDao;
                    default:
                        applicationLogDao = new ApplicationLogDaoODBC();
                        return applicationLogDao;
                }
	    }

        public static IApplicationLogDao getApplicationLogDao()
        {
            if (applicationLogDao == null)
            {
                applicationLogDao = getApplicationLogInstance();
	        }
            return applicationLogDao;
	    }
    }
}
