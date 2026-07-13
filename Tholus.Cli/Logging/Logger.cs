using System.Runtime.CompilerServices;
using Tholus.Cli.Config;

namespace Tholus.Cli.Logging;

public static class Logger
{
    public static readonly string LogFilePath;
    private static readonly StreamWriter LogFileWriter;
    private static readonly Lock LogFileWriterLock = new();

    static Logger()
    {
        string logFileFolder = Path.Join(
            // Environment.GetFolderPath calls ShGetKnownFolderName, which always returns a rooted path
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Constants.TholusDataFolderName);

        if (!Directory.Exists(logFileFolder))
            Directory.CreateDirectory(logFileFolder);

        LogFilePath = Path.Join(logFileFolder, $"{DateTime.Now:yyyy-MM-dd}.log");
        LogFileWriter = new StreamWriter(LogFilePath, append: true);
    }

    public static void Error(
        string message,
        [CallerFilePath] string? callerFile = null,
        [CallerLineNumber] int callerLine = 0)
        => Log(LogLevel.Error, message, callerFile, callerLine);

    public static void Warn(
        string message,
        [CallerFilePath] string? callerFile = null,
        [CallerLineNumber] int callerLine = 0)
        => Log(LogLevel.Warn, message, callerFile, callerLine);

    public static void Info(
        string message,
        [CallerFilePath] string? callerFile = null,
        [CallerLineNumber] int callerLine = 0)
        => Log(LogLevel.Info, message, callerFile, callerLine);

    public static void Debug(
        string message,
        [CallerFilePath] string? callerFile = null,
        [CallerLineNumber] int callerLine = 0)
        => Log(LogLevel.Debug, message, callerFile, callerLine);

    public static void Log(
        LogLevel level,
        string message,
        [CallerFilePath] string? callerFile = null,
        [CallerLineNumber] int callerLine = 0)
    {
        if (level < TholusConfig.Instance.LogLevel)
            return;

        // AsSpan() is an extension method, so this is safe
        ReadOnlySpan<char> fileNameSpan = Path.GetFileName(callerFile.AsSpan());
        if (fileNameSpan.IsEmpty)
            fileNameSpan = "unknown";

        lock (LogFileWriterLock)
            LogFileWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level,-5}] {fileNameSpan}:{callerLine} - {message}");
    }

    internal static void FlushAndClose()
    {
        lock (LogFileWriterLock)
            LogFileWriter.Dispose();
    }
}
