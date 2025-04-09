using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace artifacts
{
    public class JsonProcessor : IDataProcessor<ModernArtifact>
    {
        public List<ModernArtifact> LoadData(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<ModernArtifact>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки JSON: {ex.Message}");
                return new List<ModernArtifact>();
            }
        }

        
        public void SaveData(List<ModernArtifact> data, string filePath)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
