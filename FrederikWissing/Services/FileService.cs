using System.Text.Json;
using Spectre.Console;

namespace CarList.Services;

public static class FileService
{
    public static async Task<FileContent?> ReadDictFromFile(string path)
    {
        var fileContentString = await File.ReadAllTextAsync(path);
    
        var fileContent = JsonSerializer.Deserialize<FileContent>(fileContentString);

        return fileContent;
    }

    public static void WriteDictToFile(string path, string currentList, Dictionary<string, List<Car>> data)
    {
        var fileExists = File.Exists(path);
        var overwriteFile = false;

        if (fileExists)
        {
            overwriteFile = AnsiConsole.Confirm("File already exists, do you want to overwrite the existing file?");
        }

        if (!fileExists || (fileExists && overwriteFile))
        {
            try
            {
                using StreamWriter fileWriter = new StreamWriter(path);

                var fileContent = new FileContent
                {
                    CurrentList = currentList,
                    Lists = data
                };
            
                var serializedFileContent = JsonSerializer.Serialize(fileContent);

                fileWriter.WriteLine(serializedFileContent);

                fileWriter.Close();

                AnsiConsole.WriteLine("Data saved in file");
            }
            catch (UnauthorizedAccessException)
            {
                AnsiConsole.MarkupLine($"[maroon]You don't have permission to create or write a file at {path}[/]");
            }
            catch (Exception)
            {
                AnsiConsole.MarkupLine($"[maroon]Couldn't access the specified file at {path}[/]");
            }
        }
    }
}