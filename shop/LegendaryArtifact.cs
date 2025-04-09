using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace artifacts
{
    public class LegendaryArtifact : Artifact
    {
        public string CurseDescription { get; set; }
        public bool IsCursed { get; set; }

        public override string Serialize()
        {
            return "aboba";
        }

        public override string ExportToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override string ExportToXml()
        {
            var serializer = new XmlSerializer(typeof(LegendaryArtifact));
            using var writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}
