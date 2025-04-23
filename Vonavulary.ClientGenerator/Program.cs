using System.Runtime.CompilerServices;

using NJsonSchema.CodeGeneration.CSharp;

using NSwag;
using NSwag.CodeGeneration.CSharp;

using var httpClient = new HttpClient();
var document = await OpenApiDocument.FromJsonAsync(
    await httpClient.GetStringAsync("https://localhost:7057/swagger/v1/swagger.json")
);

Console.WriteLine("Generating CSharp Client");

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "{controller}Client",
    UseBaseUrl = false,
    GenerateClientClasses = true,
    GenerateClientInterfaces = true,
    CSharpGeneratorSettings =
    {
        Namespace = "Vonavulary.UI.Services.Base",
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
    var writePath = Path.Combine(dir, "Vonavulary.UI/Services/Base/ServiceClient.cs");

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
        if (path is null)
        {
            throw new InvalidOperationException("Could not determine the source path.");
        }
        return path[..^MyRelativePath.Length];
    }
}
