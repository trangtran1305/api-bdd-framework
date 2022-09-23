using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectCore.Utils
{
    public static class FileSearch
    {
        public static string BaseFolder { get; private set; }
        public static ILog logger = Log4NetHelper.GetLogger(typeof(FileSearch));

        /// <summary>
        /// Searches the folder structure for data storage folders
        /// </summary>
        public static string GetFullPath(String folder)
        {
            string path = "undefined";
            path = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = $"{path}{folder}";
            try
            {

                Boolean search = true;
                while (search)
                {
                    if (!Directory.Exists(filePath))
                    {
                        path = path.Substring(0, path.LastIndexOf("\\"));
                        logger.Info($"the folder structure for data storage folders is {path}");
                    }
                    else
                    {
                        search = false;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                throw new Exception($"{e.Message}, path is {path}...checking if {path}\\{folder} exists");
            }

            return filePath;

        }
    }
}
