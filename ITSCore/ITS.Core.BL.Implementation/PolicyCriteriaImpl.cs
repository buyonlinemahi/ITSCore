using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class PolicyCriteriaImpl : IPolicyCriteria
    {
         private readonly IPolicyCriteriaRepository _IPolicyCriteriaRepository;

        public PolicyCriteriaImpl(IPolicyCriteriaRepository IPolicyCriteriaRepository)
        {
            _IPolicyCriteriaRepository = IPolicyCriteriaRepository;
        }

        public IEnumerable<Data.Model.PolicyCriteria> GetAllPolicyCriteria()
        {
            return _IPolicyCriteriaRepository.GetAll();
        }
    }
}
