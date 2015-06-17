using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Web.Script.Serialization;

namespace redshift2cloudsearch
{
    public class ApplicationLogDaoODBC:IApplicationLogDao
    {
        public ApplicationLogDaoODBC ()
        {
            
        }

        public void parseAll(String path)
        {
            String applicationLogJson = "[";
            int index = 0;
            int fileName = 0;
            String queryString = "Select * from application_logs";
            List<QueryParameter> _queryParameters = new List<QueryParameter>();

            OdbcDataReader _dataReader = ODBCConnection.query("dsn=" + ConfigurationManager.AppSettings["ODBCdsn"], queryString, _queryParameters);
            if (_dataReader.HasRows)
                while (_dataReader.Read())
                {
                    ApplicationLog applicationLog = new ApplicationLog(_dataReader);
                    applicationLogJson += applicationLog2Json(applicationLog) + ",";
                    if (index==999) {
                         IOUtils.writeFile(applicationLogJson, path+fileName+".json");
                         fileName++;
                         index = 0;
                    }
                    index++;
                }
            _dataReader.Close();
            applicationLogJson = applicationLogJson.Remove(applicationLogJson.Length - 1) + "]";
        }

        public void parseLasts(String path,int minutes)
        {
            String applicationLogJson = "[";
            long timestamp = DateTime.Now.AddMinutes(-minutes).Ticks - new DateTime(1970, 1, 1).Ticks;
            timestamp /= TimeSpan.TicksPerSecond;
           
            String queryString = "Select * from application_logs where log_timestamp >= ?";
            List<QueryParameter> _queryParameters = new List<QueryParameter>();
            QueryParameter queryParameter = new QueryParameter("@log_timestamp", timestamp.ToString());
            _queryParameters.Add(queryParameter);

            OdbcDataReader _dataReader = ODBCConnection.query("dsn=" + ConfigurationManager.AppSettings["ODBCdsn"], queryString, _queryParameters);
            if (_dataReader.HasRows)
                while (_dataReader.Read())
                {
                   ApplicationLog applicationLog = new ApplicationLog(_dataReader);
                   applicationLogJson += applicationLog2Json(applicationLog)+",";
                }
            _dataReader.Close();
            applicationLogJson = applicationLogJson.Remove(applicationLogJson.Length - 1) + "]";
            IOUtils.writeFile(applicationLogJson, path +"lasts.json");
        }

        public void parseByUuid(string uuid, String path)
        {

                string queryString = "Select * from application_logs where uuid = ?";
                ApplicationLog applicationLog = null;
                List<QueryParameter> _queryParameters = new List<QueryParameter>();
                QueryParameter queryParameter = new QueryParameter("@uuid",uuid);
                _queryParameters.Add(queryParameter);

                OdbcDataReader _dataReader = ODBCConnection.query("dsn=" + ConfigurationManager.AppSettings["ODBCdsn"], queryString, _queryParameters);
                if(_dataReader.HasRows)
                    while (_dataReader.Read())
                    {
                        applicationLog = new ApplicationLog(_dataReader);
                    }
                _dataReader.Close();
        }

        static string applicationLog2Json(ApplicationLog obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            string type = @"""tpye"":""add""";
            string id = @"""id"":""" + obj.uuid + @"""";
            string fields = @"""fields"":";
            return "{" + type + "," + id + "," + fields + json + "}";
        }
    }
}
