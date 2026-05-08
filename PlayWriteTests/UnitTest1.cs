using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace PlayWriteTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        List<Organizzazione> organizzazioneRecord = new();
        private RecordVideoSize? RecordVideoSize;

        [Test(Description = "Verifica il totale delle UO nella dashboard")]
        public async Task DashboardOrgTotaleUO()
        {
            // ExtentReports setup
            //
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "index.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            //var htmlReporter = new ExtentSparkReporter("TestResults/index.html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            //
            await Page.GotoAsync("https://vermarko.github.io/Test/dashboard.html");
            Console.WriteLine("[OK] Titolo della pagina: " + await Page.TitleAsync());
            //
            RecordVideoSize = new() { Width = 1280, Height = 720 };
            var baseDir = TestContext.CurrentContext.WorkDirectory;
            var screenshotDir = Path.Combine(baseDir, "Screenshot");
            Directory.CreateDirectory(screenshotDir);
            
            var filePath = Path.Combine(screenshotDir, "screenshot.png");
            
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = filePath,
                FullPage = true
            });
           /* Directory.CreateDirectory("./../../../Screenshot");
            await Page.ScreenshotAsync(new PageScreenshotOptions
             {
                 Path = "./../../../Screenshot/screenshot.png",
                 FullPage = true
             });
             */
            // locator cards
            var card = Page.Locator("div.e-card");
            // conteggio cards pagina
            int count = await card.CountAsync();
            //
            var result = new Dictionary<string, string>();

            for (int i = 0; i < count; i++)
            {
                var currentCard = card.Nth(i);

                var title = await currentCard.Locator(".e-card-title").First.InnerTextAsync();
                var value = await currentCard.Locator(".sipro-badge-size-10.text-dark").First.InnerTextAsync();

                if (!string.IsNullOrWhiteSpace(title))
                    result[title.Trim()] = value.Trim();
            }
            var test = extent.CreateTest("Mio Primo Test Playwright");
            //foreach (var kvp in result)
            //{
            //    Console.WriteLine($"Titolo: {kvp.Key}, Valore: {kvp.Value}");
            //}
            //
            // locator per prendere la prima card:
            var card1 = Page.Locator("div.e-card").Nth(0);
            var totNumeroUO = card1.Locator(".sipro-badge-size-10.text-dark").First;
            // Console.WriteLine("Totale Numero UO: " + await totNumeroUO.InnerTextAsync());

            //
            // estrazione testo
            //var valore = await card1.Locator(".sipro-badge-size-10.text-dark").First.InnerTextAsync();
            //var titolo = await card1.Locator(".e-card-title").First.InnerTextAsync();
            //
            //**************************//EXCEL CSV//Organizzazione
            var basePath = AppContext.BaseDirectory;
            var inputFileOrganiz = Path.Combine(basePath, "Data", "Organizzazione.csv");
            using var readerOrg = new StreamReader(inputFileOrganiz);
            using var csv1 = new CsvReader(readerOrg, CultureInfo.InvariantCulture);
            //
            var organizRecord = csv1.GetRecords<Organizzazione>(); // lista

            foreach (var record in organizRecord) // per Lista

            {
                organizzazioneRecord.Add(record);
            }
            //
            Confronto(organizzazioneRecord
                [0], result);
            //
            string? TotUOcsv = organizzazioneRecord[0].TotUO;

            string? testTotUOcsv = TotUOcsv;
            //
            //await Expect(numeroUO).ToHaveTextAsync("44");
            await Expect(totNumeroUO).ToContainTextAsync(TotUOcsv!);
            Console.WriteLine($"✔ Totale Numero UO: {await totNumeroUO.InnerTextAsync()}");
            //
            test.Pass("Il test è passato con successo!");
            extent.Flush();
            //
        }
        public void Confronto(
          Organizzazione orgCsv,
            Dictionary<string, string> dizEstratti)
        {

            foreach (var prop in typeof(Organizzazione).GetProperties())
            {
                // Nome della colonna nel CSV (NameAttribute)
                //var name = prop.GetCustomAttributes(typeof(NameAttribute), false)
                //               .Cast<NameAttribute>()
                //               .FirstOrDefault()?.Names?.FirstOrDefault() ?? prop.Name;
                var displayAttr = prop.GetCustomAttributes(typeof(DisplayAttribute), false)
                              .Cast<DisplayAttribute>()
                              .FirstOrDefault();
                var chiaveDizionario = displayAttr?.Name ?? prop.Name; // Nome della card da cercare nel dizionario

                // Valore nel modello CSV
                var expected = prop.GetValue(orgCsv)?.ToString()?.Trim() ?? "";

                // Valore estratto dalle card
                if (!dizEstratti.TryGetValue(chiaveDizionario, out var actual))
                {
                    Console.WriteLine($"❌ Manca la card: {chiaveDizionario}");
                    Assert.Fail($"❌ Manca la card: {chiaveDizionario}");
                    //  continue;
                }
                if (actual != expected)
                {
                    Assert.AreEqual(expected, actual,
                     $"❌ {chiaveDizionario}: atteso {expected}, trovato {actual}");
                }
                else
                {
                    Assert.AreEqual(expected, actual,
                     $"✔ {chiaveDizionario}: OK ({actual})");
                }
            }
        }
                //// Confronto
                //if (actual != expected)
                //{
                //   // Console.WriteLine($"❌ {chiaveDizionario}: atteso {expected}, trovato {actual}");
                //    Assert.AreEqual(expected, actual, $"Discrepanza trovata nel campo: {chiaveDizionario}");
                //}
                //else
                //{
                //    // Console.WriteLine($"✔ {chiaveDizionario}: OK ({actual})");
                //    Assert.AreEqual(expected, actual, $"Conferma: {chiaveDizionario} è corretto");
                //}
 public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                RecordVideoDir = "./../../../Videos/",
                RecordVideoSize = new() { Width = 1280, Height = 720 }
            };
        }
    }
}
