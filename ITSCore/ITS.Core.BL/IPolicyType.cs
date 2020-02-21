using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IPolicyType
    {
        IEnumerable<Data.Model.PolicyType> GetAllPolicyType();
    }
}
