using System.Configuration;

namespace AU2023DynamoToolkitToolbar.Utilities;

public class ConfigManager
{
    private readonly string _assemblyLocation;

    /// <summary>
    /// Loads config file settings for libraries that use assembly.dll.config files
    /// </summary>
    /// <param name="assemblyLocation">The full path or UNC location of the loaded file that contains the manifest.</param>
    public ConfigManager(string assemblyLocation)
    {
        _assemblyLocation = assemblyLocation;
    }

    public Configuration Configuration => ConfigurationManager.OpenExeConfiguration(_assemblyLocation);

    public string GetAppSetting(string key)
    {
        string result = string.Empty;
        if (Configuration == null) return result;

        KeyValueConfigurationElement keyValueConfigurationElement = Configuration.AppSettings.Settings[key];
        if (keyValueConfigurationElement == null) return result;

        string value = keyValueConfigurationElement.Value;
        if (!string.IsNullOrEmpty(value)) result = value;
        return result;
    }
}
