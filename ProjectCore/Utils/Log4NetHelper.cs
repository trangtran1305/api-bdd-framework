using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using ProjectCore.Configurations;
using System;

namespace ProjectCore.Utils
{
    public class Log4NetHelper
    {
        #region private
        private static String _layout = "[%date] [%level] - %message%newline";
        private static ILog _logger;
        private static FileAppender _fileAppender;
        public static TestConfigs _configs = new TestConfigs();
        private static string subPath;
        private static string url;

        private static PatternLayout GetPartternLayout()
        {
            var globalSettings = _configs.GlobalConfig;
            url = globalSettings.BaseUrl;
            subPath = DateTime.Now.ToString("MMMMdd") + "_" + url.Substring(8, 3);
            var pattern = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            pattern.ActivateOptions();
            return pattern;
        }

        private static FileAppender GetRollingFileAppender()
        {
            _fileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPartternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "log\\" + subPath + "\\TestExecution.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15
            };
            _fileAppender.ActivateOptions();
            return _fileAppender;
        }

        #endregion

        #region public
        public static void SetLogFormat(String messageLayout)
        {
            _layout = messageLayout;
        }

        public static ILog GetLogger(Type type)
        {
            if (_fileAppender == null)
                _fileAppender = GetRollingFileAppender();

            if (_logger != null)
                return _logger;

            BasicConfigurator.Configure(_fileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }
        #endregion


    }
}
