using System.Text.Json;
using Tholus.Cli.Logging;

namespace Tholus.Cli.Config;

public class TholusConfig
{
    public static readonly string ConfigFilePath;
    public static TholusConfig Instance { get; private set; } = null!;

    static TholusConfig()
    {
        string logFileFolder = Path.Join(
            // Environment.GetFolderPath calls ShGetKnownFolderName, which always returns a rooted path
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Constants.TholusDataFolderName);

        if (!Directory.Exists(logFileFolder))
            Directory.CreateDirectory(logFileFolder);

        ConfigFilePath = Path.Join(logFileFolder, "config.json");
    }

    public LogLevel LogLevel { get; set; } = LogLevel.Info;

    public int RunCount { get; set; }

    internal static async Task ReadConfig()
    {
        if (!File.Exists(ConfigFilePath))
        {
            Instance = new TholusConfig();
            await WriteConfig();
            return;
        }

        await using (FileStream configStream = File.OpenRead(ConfigFilePath))
        {
            if (configStream.Length > 0 && await JsonSerializer.DeserializeAsync(
                configStream, TholusConfigSerializerContext.Default.TholusConfig
            ) is { } config)
            {
                Instance = config;
                return;
            }
        }

        Instance = new TholusConfig();
        await WriteConfig();
    }

    internal static async Task WriteConfig()
    {
        if (Instance is null)
            throw new InvalidOperationException("Attempted to write an uninitialized config!");

        await using FileStream writeStream = File.OpenWrite(ConfigFilePath);
        await JsonSerializer.SerializeAsync(
            writeStream,
            Instance,
            TholusConfigSerializerContext.Default.TholusConfig
        );
    }
}
