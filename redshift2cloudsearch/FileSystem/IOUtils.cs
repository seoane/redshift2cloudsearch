using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redshift2cloudsearch
{
    class IOUtils
    {
        public static void writeFile(String content, String path)
        {
            TextWriter tw = new StreamWriter(path, true);
            tw.Write(content);
            tw.Close();
        }

    }
}
