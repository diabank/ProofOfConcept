using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace DataWebApi
{
    public class StaticReasonProvider : IReasonProvider
    {
        //TODO: Found a way to get System.ComponentModel.Composition.Registration for .Net Core
        //public IEnumerable<Reason> GetReasonsFromStorage()
        //{
        //Get IDataStorageAccessor
        //MEF to retrieve Library implementing IDataStorageAccessor
        //var builder = new RegistrationBuilder();
        //builder.ForTypesDerivedFrom<IDataStorageAccessor>().Export<IDataStorageAccessor>();
        //var aggregateCatalog = new AggregateCatalog();

        ////Look through Directory
        //aggregateCatalog.Catalogs.Add(
        //    new DirectoryCatalog(@".\", builder)); ;

        ////Container
        //var Container = new CompositionContainer(aggregateCatalog);

        ////Create and Launch
        //var dataStorage = Container.GetExport<IDataStorageAccessor>().Value;
        //return myBatch.GetReasonsFromStorage();
        //}

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
