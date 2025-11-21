using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ExcelUpdater
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Excel Updater";
            Console.WriteLine("Excel-Updater wird gestartet...\n");

            var updater = new GitHubUpdater();
            CancellationTokenSource cts = new CancellationTokenSource();

            // Ladebalken starten
            var loading = Task.Run(() => ShowLoadingBar(cts.Token));

            bool success = await updater.UpdateFileAsync();

            // Ladebalken stoppen
            cts.Cancel();
            await Task.Delay(200);

            Console.WriteLine("\n");

            if (success)
            {
                Console.WriteLine("Update erfolgreich abgeschlossen.");
            }
            else
            {
                Console.WriteLine("Kein Update installiert (kein Release oder aktuellste Version).");
            }

            // Excel-Datei IMMER öffnen
            string excelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExcelDoubleEntrySystem.xlsm");

            if (File.Exists(excelPath))
            {
                Console.WriteLine("Update abgeschlossen.");
                Console.WriteLine("\nDrücken Sie eine Taste, um 'ExcelDoubleEntrySystem.xlsm' zu öffnen.");
                Console.ReadKey();
                Process.Start(new ProcessStartInfo(excelPath) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("Die Excel-Datei wurde nicht gefunden: " + excelPath);
            }  
        }

        static void ShowLoadingBar(CancellationToken token)
        {
            int max = 30;
            while (!token.IsCancellationRequested)
            {
                for (int i = 0; i <= max; i++)
                {
                    if (token.IsCancellationRequested)
                        return;

                    Console.Write("\rLade: [" + new string('#', i) + new string('-', max - i) + "]");
                    Thread.Sleep(50);
                }
            }
        }
    }
}
