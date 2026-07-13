using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tholus.Cli.Config;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Strict, WriteIndented = true)]
[JsonSerializable(typeof(TholusConfig))]
public partial class TholusConfigSerializerContext : JsonSerializerContext;
