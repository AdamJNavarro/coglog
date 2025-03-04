using System.Runtime.CompilerServices;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;

System.Net.WebClient wclient = new System.Net.WebClient();

var document = await OpenApiDocument.FromJsonAsync(
    wclient.DownloadString("https://localhost:7195/swagger/v1/swagger.json")
);

Console.WriteLine("Generating CSharp Client");

wclient.Dispose();

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "{controller}Client",
    UseBaseUrl = false,
    GenerateClientClasses = true,
    GenerateClientInterfaces = true,
    CSharpGeneratorSettings =
    {
        Namespace = "CogLog.UI.Services.Base",
        JsonLibrary = CSharpJsonLibrary.SystemTextJson,
        DateTimeType = "System.DateTime",
        GenerateNativeRecords = true,
    },
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

try
{
    var srcPath = ProjectSourcePath.Value;
    var dir = Directory.GetParent(srcPath).FullName;
    var writePath = Path.Combine(dir, "CogLog.UI/Services/Base/ServiceClient.cs");

    File.WriteAllText(writePath, code);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

internal static class ProjectSourcePath
{
    private const string MyRelativePath = nameof(ProjectSourcePath) + ".cs";
    private static string? _lazyValue;

    ///<summary>
    ///The full path to the source directory of the current project.
    ///</summary>
    public static string Value => _lazyValue ??= Calculate();

    private static string Calculate([CallerFilePath] string? path = null)
    {
        // Assert(path!.EndsWith(myRelativePath, StringComparison.Ordinal));
        return path.Substring(0, path.Length - MyRelativePath.Length);
    }
}
