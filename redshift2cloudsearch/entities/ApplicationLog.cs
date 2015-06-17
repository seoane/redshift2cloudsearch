using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    public class ApplicationLog
    {
        public string uuid { get; set; }
        public string computer_username { get; set; }
        public int company_id { get; set; }
        public string ip_private_internal_1 { get; set; }
        public string ip_private_internal_2 { get; set; }
        public string ip_private_internal_3 { get; set; }
        public string ip_external { get; set; }
        public long log_timestamp { get; set; }
        public long to_timestamp { get; set; }
        public string to_timezone { get; set; }
        public long from_timestamp { get; set; }
        public string from_timezone { get; set; }
        public string machine_name { get; set; }
        public int office_id { get; set; }
        public int request_id { get; set; }
        public int user_id { get; set; }
        public int application_id { get; set; }
        public int application_version_id { get; set; }
        public int os_application_id { get; set; }
        public int os_application_version_id { get; set; }
        public float avg_cpu { get; set; }
        public float avg_mem { get; set; }
        public float max_cpu { get; set; }
        public float max_mem { get; set; }
        public float min_cpu { get; set; }
        public float min_mem { get; set; }
        public string process_name { get; set; }
        public string window_title { get; set; }
        public string detail { get; set; }
        public string document { get; set; }
        public string client_version { get; set; }
        public string context { get; set; }
        public float kiply_avg_cpu { get; set; }
        public float kiply_avg_mem { get; set; }
        public float kiply_max_cpu { get; set; }
        public float kiply_max_mem { get; set; }
        public float kiply_min_cpu { get; set; }
        public float kiply_min_mem { get; set; }

        private int DbStringToInt(DbDataReader dataReader,int index)
        {
            try
            {
                string arg = dataReader.GetString(index);
                return int.Parse(arg);
            }
            catch { return -1; }
        }

        private float DbStringToFloat(DbDataReader dataReader, int index)
        {
            try
            {
                string arg = dataReader.GetString(index);
                return float.Parse(arg);
            }
            catch { return -1; }
        }

        private string DbStringToString(DbDataReader dataReader, int index)
        {
            try
            {
                string arg = dataReader.GetString(index);
                return arg;
            }
            catch { return ""; }
        }
        
        public ApplicationLog(DbDataReader dataReader)
        {
            uuid = DbStringToString(dataReader,0);
            computer_username = DbStringToString(dataReader, 1);
            company_id = DbStringToInt(dataReader, 2);
            ip_private_internal_1 = DbStringToString(dataReader, 3);
            ip_private_internal_2 = DbStringToString(dataReader, 4);
            ip_private_internal_3 = DbStringToString(dataReader, 5);
            ip_external= DbStringToString(dataReader,6);
            log_timestamp= DbStringToInt(dataReader,7);
            machine_name= DbStringToString(dataReader,8);
            office_id = DbStringToInt(dataReader,9);
            request_id = DbStringToInt(dataReader,10);
            user_id = DbStringToInt(dataReader,11);
            application_id = DbStringToInt(dataReader,12);
            application_version_id= DbStringToInt(dataReader,13);
            os_application_id = DbStringToInt(dataReader,14);
            os_application_version_id = DbStringToInt(dataReader,15);
            avg_cpu= DbStringToFloat(dataReader,16);
            avg_mem= DbStringToFloat(dataReader,17);
            from_timestamp = DbStringToInt(dataReader,18);
            from_timezone= DbStringToString(dataReader,19);
            max_cpu= DbStringToFloat(dataReader,20);
            max_mem= DbStringToFloat(dataReader,21);
            min_cpu= DbStringToFloat(dataReader,22);
            min_mem= DbStringToFloat(dataReader,23);
            process_name= DbStringToString(dataReader,24);
            to_timestamp = DbStringToInt(dataReader,25);
            to_timezone= DbStringToString(dataReader,27);
            window_title= DbStringToString(dataReader,28);
            detail= DbStringToString(dataReader,29);
            document= DbStringToString(dataReader,30);
            client_version= DbStringToString(dataReader,31);
            context= DbStringToString(dataReader,32);
            kiply_max_cpu= DbStringToFloat(dataReader,33);
            kiply_max_mem= DbStringToFloat(dataReader,34);
            kiply_min_cpu= DbStringToFloat(dataReader,35);
            kiply_min_mem= DbStringToFloat(dataReader,36);
            kiply_avg_cpu= DbStringToFloat(dataReader,37);
            kiply_avg_mem = DbStringToFloat(dataReader,38);
        }
    }
}
