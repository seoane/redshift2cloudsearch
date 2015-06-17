using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    class ODBCConnection
    {
        public static OdbcConnection openConnection(string connectionString)
        {
            return new OdbcConnection(connectionString);
        }

        public static OdbcDataReader query(String connectionString,String queryString, List<QueryParameter> _queryParameters)
        {
            OdbcCommand command = new OdbcCommand(queryString);

            if (_queryParameters !=null  && _queryParameters.Count > 0 ) {
                foreach (QueryParameter queryParameter in _queryParameters)
                {
                    command.Parameters.AddWithValue(queryParameter.name, queryParameter.value);
                }
            }

            OdbcConnection conn = openConnection(connectionString);
            
            command.Connection = conn;
            conn.Open();
            return command.ExecuteReader();
            
        }
    }

}
