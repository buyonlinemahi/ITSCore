using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class PolicyTypeImpl : IPolicyType
    {
        private readonly IPolicyTypeRepository _IPolicyTypeRepository;

        public PolicyTypeImpl(IPolicyTypeRepository IPolicyTypeRepository)
        {
            _IPolicyTypeRepository = IPolicyTypeRepository;
        }

        public IEnumerable<Data.Model.PolicyType> GetAllPolicyType()
        {
            return _IPolicyTypeRepository.GetAll();
        }
    }
}
