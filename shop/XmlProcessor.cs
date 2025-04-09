using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace artifacts
{
    public class XmlProcessor : IDataProcessor<AntiqueArtifact>
    {
        public List<AntiqueArtifact> LoadData(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<AntiqueArtifact>), 
                    new XmlRootAttribute("ArrayOfAntiqueArtifact"));
                using var reader = new StreamReader(filePath);
                return (List<AntiqueArtifact>)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR\n{ex.Message}");
                return new List<AntiqueArtifact>();
            }
        }
        

        public void SaveData(List<AntiqueArtifact> data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<AntiqueArtifact>),
                new XmlRootAttribute("ArrayOfAntiqueArtifact"));
            using var writer = new StreamWriter(filePath);
            serializer.Serialize(writer, data);
        }
    }
}
