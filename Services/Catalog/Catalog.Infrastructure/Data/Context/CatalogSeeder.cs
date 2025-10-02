using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Context
{
    public class CatalogSeeder
    {
        public static async Task SeedFromFileAsync<T>(IMongoCollection<T> collection, string fileName)
        {
            var hasCatalog = await collection.Find(_ => true).AnyAsync();
            if (hasCatalog)
                return;

            // اطبع الدليل الحالي للمساعدة في تصحيح الأخطاء
            //  var pathFile = "/src/Services/Catalog/Catalog.Infrastructure/Data/SeedData/Catalog.json";
            var pathFile = Path.Combine("SeedData", fileName);

            // استخدم المسار الكامل كما نسخته في Dockerfile
            //  var pathFile = Path.Combine("Data", "SeedData", "Catalog.json");

            if (!File.Exists(pathFile))
            {
                Console.WriteLine($"[ERROR] Seed file not found at path: {pathFile}");
                return;
            }

            try
            {
                var jsontData = await File.ReadAllTextAsync(pathFile);
                var items = JsonSerializer.Deserialize<List<T>>(jsontData);

                if (items?.Any() == true)
                {
                    await collection.InsertManyAsync(items);
                    Console.WriteLine($"✅ Seeded {items.Count} items from {fileName}");
                }
                else
                {
                    Console.WriteLine($"[WARN] {fileName} is empty or invalid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EXCEPTION] Error reading or deserializing seed file: {ex.Message}");
            }
        }
    }
}
