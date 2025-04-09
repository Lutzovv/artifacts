using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artifacts
{
    public interface IExplortable
    {
        public string ExportToJson();
        public string ExportToXml();

    }
}
