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
            if (args.Length != 0) path = args[1];
            IApplicationLogDao _applicationLogDao = DaoFactory.getApplicationLogDao();
            //_applicationLogDao.parseLasts(path, 576000);
            _applicationLogDao.parseAll(path);
            Console.ReadLine();
        }
    }
}
