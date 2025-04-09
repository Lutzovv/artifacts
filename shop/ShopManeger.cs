using System;
using System.Text;

namespace artifacts;

public class ShopManeger
{
    public List<Artifact> Artifacts { get; } = new List<Artifact>();

    public void LoadAllData()
    {
        try
        {
            LoadData(new XmlProcessor(), "antique.xml");
            LoadData(new JsonProcessor(), "modern.json");
            LoadData(new LegendaryProcessor(), "legends.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR\n{ex.Message}");
        }
    }
    
    
    private void LoadData<T>(IDataProcessor<T> processor, string filePath) where T : Artifact
    {
        try
        {
            var data = processor.LoadData(filePath);
            if (data != null && data.Any())
            {
                Artifacts.AddRange(data.Cast<Artifact>());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR\n{ex.Message}");
        }
    }
    
    
    public void GenerateReport()
    {
        var report = new StringBuilder();
        report.AppendLine("Отчет по артефактам");
            
        var byRarity = GroupByRarity();
        foreach (var group in byRarity)
        {
            report.AppendLine($"\nРедкость: {group.Key}");
            report.AppendLine($"Количество: {group.Value}");
                
            var avgPower = Artifacts
                .Where(a => a.Rarity == group.Key)
                .Average(a => a.PowerLevel);
            report.AppendLine($"Средняя сила: {avgPower:F1}");
                
            var maxPower = Artifacts
                .Where(a => a.Rarity == group.Key)
                .Max(a => a.PowerLevel);
            report.AppendLine($"Максимальная сила: {maxPower}");
        }

        File.WriteAllText("report.txt", report.ToString());
    }
    
    
    public List<LegendaryArtifact> FindCursedArtifacts()
    {
        return Artifacts.OfType<LegendaryArtifact>()
            .Where(a => a.IsCursed && a.PowerLevel > 50)
            .ToList();
    }

    
    public Dictionary<Rarity, int> GroupByRarity()
    {
        return Artifacts.GroupBy(a => a.Rarity)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    
    public List<Artifact> TopByPower(int count)
    {
        return Artifacts.OrderByDescending(a => a.PowerLevel)
            .Take(count)
            .ToList();
    }
}