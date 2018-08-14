using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BanVeXe_Web.Queries.Files
{
    public class FileQuerries
    {
        public static string readFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return null;
        }
    }
}
