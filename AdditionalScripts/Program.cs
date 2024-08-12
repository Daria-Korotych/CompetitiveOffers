namespace AdditionalScripts;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

public class Program
{
    static void Main()
    {
        var specInfo = Specialities.GetNames();
        var outputDirectory = "C:\\Users\\darya\\RiderProjects\\Competitive_offers\\Competitive_offers";
        var fileName = Path.Combine(outputDirectory, "Specialities.json");

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true // Додає відступи для кращої читабельності JSON
        };

        using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (var writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8))
        {
            var jsonString = JsonSerializer.Serialize(specInfo, options);
            writer.Write(jsonString);
        }
    }
}