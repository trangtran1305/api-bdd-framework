using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectCore.ApiCore.Common
{
    public class FileUtils
    {
        private static Dictionary<string, string> defaultConfiguration = new Dictionary<string, string>();

       
        public static String GetPayLoadSource(String FilePath)
        {
            return Constants.GetConfiguration("path.resource") + FilePath;
        }

        public static String ReadFile(String filePath)
        {
            string path = GetPayLoadSource(filePath);
            string content = File.ReadAllText(path);
            return content;
        }        
    }
}
