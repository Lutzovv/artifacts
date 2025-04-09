using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artifacts
{
    internal interface IDataProcessor<T>
    {
        public List<T> LoadData(string filePath);
        public void SaveData(List<T> data, string filePath);

    }
}
