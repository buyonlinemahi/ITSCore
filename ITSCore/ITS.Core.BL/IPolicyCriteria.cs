using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IPolicyCriteria
    {
        IEnumerable<Data.Model.PolicyCriteria> GetAllPolicyCriteria();
    }
}
