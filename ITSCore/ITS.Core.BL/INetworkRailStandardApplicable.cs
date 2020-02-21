using System.Collections.Generic;

namespace ITS.Core.BL
{
   public interface INetworkRailStandardApplicable
    {
       IEnumerable<Data.Model.NetworkRailStandardApplicable> GetAllNetworkRailStandardApplicable();
    }
}
