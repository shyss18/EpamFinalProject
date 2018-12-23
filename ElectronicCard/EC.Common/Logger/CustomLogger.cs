using System.IO;
using log4net;
using log4net.Config;

namespace EC.Common.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private const string LOGGER_NAME = "CustomLogger";
        private readonly ILog _logger;

        public CustomLogger()
        {
            var config = GetConfigFile("EC.Common.Logger.config");

            if (config.Exists)
            {
                XmlConfigurator.Configure(config);

                _logger = LogManager.GetLogger(LOGGER_NAME);
            }
        }

        private FileInfo GetConfigFile(string configName)
        {

            var currentDirectory = Path.GetDirectoryName("D:\\ElectronicCard\\ElectronicCard\\EC.Common\\");

            var fullPath = string.Format($"{currentDirectory}\\{configName}");

            var fileInfo = new FileInfo(fullPath);

            return fileInfo;
        }

        public void WriteToFile(string message)
        {
            _logger.Info(message);
        }
    }
}
