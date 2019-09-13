using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApi
{
    public class StaticFileReasonProvider : IReasonProvider
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
            catch(Exception Ex)
            {
                return new List<Reason>();
            }
        }
    }
}
