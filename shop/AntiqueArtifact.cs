using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace artifacts
{
    public class AntiqueArtifact : Artifact
    {
        public int Age { get; set; }
        public string OriginRealm { get; set; }

        public override string Serialize()
        {
            return $"";
        }

        public override string ExportToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override string ExportToXml()
        {
            var serializer = new XmlSerializer(typeof(AntiqueArtifact));
            using var writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}
