using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    public interface IApplicationLogDao
    {
        //public ApplicationLog create(SqlConnection connection, ApplicationLog applicationLog);

        //public void remove (SqlConnection connection, long applicationLogUuid);

        //public void update(SqlConnection connection, ApplicationLog applicationLog);

        void parseLasts(String path,int minutes = 240);

        void parseAll(String path);

        void parseByUuid(String uuid, String path);

    }
}
