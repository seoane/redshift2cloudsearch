using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "D://Descargas/Jsons/";
            if (args.Length != 0) path = args[0];
            IApplicationLogDao _applicationLogDao = DaoFactory.getApplicationLogDao();
            _applicationLogDao.parseAll(path);
        }
    }
}
