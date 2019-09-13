using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Dapper;

namespace DapperDataStorage
{
    public class DapperDataStorage : IDataStorageAccessor
    {
        private IDbConnection db;


        public IEnumerable<Reason> GetReasonsFromStorage()
        {
            var reasons = this.db.Query<Reason>("SELECT * FROM tblReason");
            return reasons.ToList();
        }

    }
}
