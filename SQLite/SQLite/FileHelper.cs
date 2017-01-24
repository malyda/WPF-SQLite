using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    class FileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine("/", filename);
        }
    }
}
