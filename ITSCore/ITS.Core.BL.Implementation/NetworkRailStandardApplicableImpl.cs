using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
   public class NetworkRailStandardApplicableImpl : INetworkRailStandardApplicable
    {
       private readonly INetworkRailStandardApplicableRepository _INetworkRailStandardApplicableRepository;

       public NetworkRailStandardApplicableImpl(INetworkRailStandardApplicableRepository INetworkRailStandardApplicableRepository)
        {
            _INetworkRailStandardApplicableRepository = INetworkRailStandardApplicableRepository;
        }

       public IEnumerable<Data.Model.NetworkRailStandardApplicable> GetAllNetworkRailStandardApplicable()
        {
            return _INetworkRailStandardApplicableRepository.GetAll();
        }
    }
}
