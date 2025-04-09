using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artifacts
{
    public class LegendaryProcessor : IDataProcessor<LegendaryArtifact>
    {
        public List<LegendaryArtifact> LoadData(string filePath)
        {
            var artifacts = new List<LegendaryArtifact>();
            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length != 5) continue;

                    artifacts.Add(new LegendaryArtifact
                    {
                        Name = parts[0],
                        PowerLevel = int.Parse(parts[1]),
                        Rarity = Enum.Parse<Rarity>(parts[2]),
                        CurseDescription = parts[3],
                        IsCursed = bool.Parse(parts[4])
                    });
                }
                return artifacts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR\n{ex.Message}");
                return artifacts;
            }
        }

        public void SaveData(List<LegendaryArtifact> data, string filePath)
        {
            var lines = data.Select(a => 
                $"{a.Name}|{a.PowerLevel}|{a.Rarity}|{a.CurseDescription}|{a.IsCursed}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
