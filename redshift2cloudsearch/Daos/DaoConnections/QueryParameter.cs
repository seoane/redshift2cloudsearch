using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    class QueryParameter
    {
        public QueryParameter(String name, String value)
        {
            this.name = "@"+name;
            this.value = value;
        }
        public String name { get; set; }
        public String value { get; set; }

     }
}
