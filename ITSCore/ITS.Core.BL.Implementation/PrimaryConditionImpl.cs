using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
   public class PrimaryConditionImpl:IPrimaryCondition
    {
        private readonly IPrimaryConditionRepository _iPrimaryConditionRepository;

        public PrimaryConditionImpl(IPrimaryConditionRepository iPrimaryConditionRepository)
        {
            _iPrimaryConditionRepository = iPrimaryConditionRepository;
        }

        public IEnumerable<PrimaryCondition> GetAllPrimaryCondition()
        {
            return _iPrimaryConditionRepository.GetAll();
 
        }
    }
}

