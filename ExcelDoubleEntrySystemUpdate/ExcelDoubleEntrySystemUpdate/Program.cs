// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Threading.Tasks;
using Octokit;

public class GitHubUpdater
{
    private readonly string owner = "Inqenza";
    private readonly string repo = "ExcelDoubleEntrySystem";
    private readonly string filePath = "ExcelDoubleEntrySystem.xlsm";
    private readonly string localPath = "AppDomain.CurrentDomain.BaseDirectory";

    public async Task UpdateFileAsync()
    {
        var github = new GitHubClient(new ProductHeaderValue("MeinApp"));
        var latestRelease = await github.Repository.Release.GetLatest(owner, repo);
        var asset = latestRelease.Assets[0]; // Annahme: Wir laden den ersten Asset herunter
        var downloadUrl = asset.BrowserDownloadUrl;

        using (var client = new System.Net.Http.HttpClient())
        {
            var content = await client.GetByteArrayAsync(downloadUrl);
            await File.WriteAllBytesAsync(Path.Combine(localPath, filePath), content);
        }

        Console.WriteLine("Datei wurde erfolgreich aktualisiert.");
    }
}