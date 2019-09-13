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
            //Get Reason Provider processor
            //MEF to retrieve ServiceOrderProcessor Library implementing IBatchable
            //var builder = new RegistrationBuilder();
            //builder.ForTypesDerivedFrom<IBatchable>().Export<IBatchable>();
            //var aggregateCatalog = new AggregateCatalog();

            ////Look through Processors\AI\ Directory
            //aggregateCatalog.Catalogs.Add(
            //    new DirectoryCatalog(@".\Processors\AI.Internet.Calix\", builder)); ;

            ////Container
            //var Container = new CompositionContainer(aggregateCatalog);

            ////Create and Launch
            //var myBatch = Container.GetExport<IBatchable>().Value;
            //this.Response = myBatch.ProcessBatchOrder(task.SQLConnCM);


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
