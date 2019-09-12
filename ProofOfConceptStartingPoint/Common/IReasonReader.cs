using System.Collections.Generic;

namespace Common
{
    public interface IReasonReader
    {
        IEnumerable<Reason> GetReasons();
        Reason GetAReason(int id);
    }
}
