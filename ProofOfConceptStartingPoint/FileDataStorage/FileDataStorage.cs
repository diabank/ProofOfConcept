using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace FileDataStorage
{
    public class FileDataStorage : IDataStorageAccessor
    {
        public IEnumerable<Reason> GetReasonsFromStorage()
        {
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "Reasons.txt";
                using (var reader = new StreamReader(filePath))
                {
                    var result = reader.ReadToEnd().ToString();
                    var reasons = JsonConvert.DeserializeObject<IEnumerable<Reason>>(result);
                    return reasons;
                }
            }
            catch
            {
                return new List<Reason>();
            }
        }
    }
}
