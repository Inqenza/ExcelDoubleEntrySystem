// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Threading.Tasks;
using Octokit;

public class GitHubUpdater
{
    private readonly string owner = "Inqenza";
    private readonly string repo = "ExcelDoubleEntrySystem";
    private readonly string fileName = "ExcelDoubleEntrySystem.xlsm";
    private readonly string localPath = AppDomain.CurrentDomain.BaseDirectory;

    public async Task UpdateFileAsync()
    {
        try
        {
            Console.WriteLine("Prüfe GitHub-Releases...");

            var github = new GitHubClient(new ProductHeaderValue("MeinApp"));
            var latestRelease = await github.Repository.Release.GetLatest(owner, repo);

            if (latestRelease.Assets.Count == 0)
            {
                Console.WriteLine("Keine Dateien im Release gefunden.");
                return;
            }

            var asset = latestRelease.Assets[0]; // Annahme: erster Asset
            var downloadUrl = asset.BrowserDownloadUrl;

            Console.WriteLine($"Lade Datei herunter: {asset.Name}");

            using (var client = new System.Net.Http.HttpClient())
            {
                var content = await client.GetByteArrayAsync(downloadUrl);
                var finalPath = Path.Combine(localPath, fileName);

                await File.WriteAllBytesAsync(finalPath, content);
            }

            Console.WriteLine("Datei wurde erfolgreich aktualisiert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler beim Update:");
            Console.WriteLine(ex.Message);
        }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Updater gestartet...");

        var updater = new GitHubUpdater();

        await updater.UpdateFileAsync();

        Console.WriteLine("Vorgang abgeschlossen. Taste drücken zum Beenden.");
        Console.ReadKey();
    }
}