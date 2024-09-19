namespace Dealoviy.Infrastructure.Persistence;

public static class FilePathBuilder
{
    private static readonly string DataDirectory = "data";
    
    public static string GetDataFilePath(string fileName)
    {
        var basePath = Directory.GetParent(AppContext.BaseDirectory)? // build level dir
            .Parent? // build configuration level dir (Debug/Release)
            .Parent? // binary output level dir
            .Parent? // project level dir
            .Parent? // solution level dir
            .FullName;
        return Path.Combine(basePath, DataDirectory, fileName);
    }
}