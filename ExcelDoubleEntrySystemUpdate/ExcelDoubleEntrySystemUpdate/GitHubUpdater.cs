using Octokit;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExcelUpdater
{
    public class GitHubUpdater
    {
        private readonly string owner = "Inqenza";
        private readonly string repo = "ExcelDoubleEntrySystem";
        private readonly string targetFile = "ExcelDoubleEntrySystem.xlsm";
        private readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;

        public async Task<bool> UpdateFileAsync()
        {
            try
            {
                Console.WriteLine("Prüfe GitHub auf neue Version...");

                var client = new GitHubClient(new ProductHeaderValue("ExcelUpdater"));

                Release latest = null;

                try
                {
                    latest = await client.Repository.Release.GetLatest(owner, repo);
                }
                catch (NotFoundException)
                {
                    Console.WriteLine("Es existiert noch kein GitHub-Release in diesem Repository.");
                    return false;
                }

                if (latest.Assets.Count == 0)
                {
                    Console.WriteLine("Kein XLSM im Release gefunden.");
                    return false;
                }

                var asset = latest.Assets.FirstOrDefault(a =>
                    a.Name.EndsWith(".xlsm", StringComparison.OrdinalIgnoreCase));

                if (asset == null)
                {
                    Console.WriteLine("Keine XLSM-Datei im Release.");
                    return false;
                }

                Console.WriteLine("Gefundene Datei: " + asset.Name);
                Console.WriteLine("Lade Datei herunter...");

                using var http = new HttpClient();
                byte[] data = await http.GetByteArrayAsync(asset.BrowserDownloadUrl);

                string fullPath = Path.Combine(basePath, targetFile);
                string backupPath = fullPath + ".backup";

                // Backup erstellen
                if (File.Exists(fullPath))
                {
                    File.Copy(fullPath, backupPath, true);
                    Console.WriteLine("Backup erstellt.");
                }

                File.WriteAllBytes(fullPath, data);

                Console.WriteLine("Datei erfolgreich aktualisiert.");

                // Backup löschen
                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                    Console.WriteLine("Backup gelöscht.");
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("FEHLER:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
