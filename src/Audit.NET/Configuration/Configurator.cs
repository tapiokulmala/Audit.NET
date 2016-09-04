using System;
using Audit.Core.Providers;

namespace Audit.Core.Configuration
{
    public class Configurator : IConfigurator
    {
        public ICreationPolicyConfigurator UseFileLogProvider(Action<IFileLogProviderConfigurator> config)
        {
            var fileLogConfig = new FileLogProviderConfigurator();
            config.Invoke(fileLogConfig);
            return UseFileLogProvider(fileLogConfig._directoryPath, fileLogConfig._filenamePrefix);
        }
        public ICreationPolicyConfigurator UseCustomProvider(AuditDataProvider provider)
        {
            AuditConfiguration.SetDataProvider(provider);
            return new CreationPolicyConfigurator();
        }
#if NET45
        public ICreationPolicyConfigurator UseEventLogProvider(string logName = "Application", string sourcePath = "Application", string machineName = ".")
        {
            AuditConfiguration.SetDataProvider(new EventLogDataProvider()
            {
                LogName = logName,
                SourcePath = sourcePath,
                MachineName = machineName
            });
            return new CreationPolicyConfigurator();
        }
        public ICreationPolicyConfigurator UseEventLogProvider(Action<IEventLogProviderConfigurator> config)
        {
            var eventLogConfig = new EventLogProviderConfigurator();
            config.Invoke(eventLogConfig);
            return UseEventLogProvider(eventLogConfig._logName, eventLogConfig._sourcePath, eventLogConfig._machineName);
        }
#endif
        public ICreationPolicyConfigurator UseFileLogProvider(string directoryPath = "", string filenamePrefix = "")
        {
            AuditConfiguration.SetDataProvider(new FileDataProvider()
            {
                DirectoryPath = directoryPath,
                FilenamePrefix = filenamePrefix
            });
            return new CreationPolicyConfigurator();
        }
    }
}