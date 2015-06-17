using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    class ApplicationLogDaoPostgreSQL:IApplicationLogDao
    {
        public ApplicationLogDaoPostgreSQL ()
        {
        }

        public void parseLasts(String path,int minutes = 60)
        {
            throw new NotImplementedException();
        }

        public void parseAll(String path)
        {
            throw new NotImplementedException();
        }


        public void parseByUuid(string uuid, String path)
        {
            throw new NotImplementedException();
        }
    }
}
