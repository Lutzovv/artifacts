using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artifacts
{
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public abstract class Artifact : IExplortable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PowerLevel { get; set; }
        public Rarity Rarity { get; set; }
        
        public abstract string Serialize();
        public abstract string ExportToJson();
        public abstract string ExportToXml();
    }
}
