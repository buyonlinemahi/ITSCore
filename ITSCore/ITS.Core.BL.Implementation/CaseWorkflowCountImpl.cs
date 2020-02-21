using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    
    
    public class CaseWorkflowCountImpl : ICaseWorkflowCount
    {
        private readonly ICaseWorkflowCountRepository _caseWorkflowCountRepository;

        public CaseWorkflowCountImpl(ICaseWorkflowCountRepository caseWorkflowCountRepository)
        {
            _caseWorkflowCountRepository = caseWorkflowCountRepository;
        }

        public IEnumerable<CaseWorkflowCount> GetCaseCounts()
        {
            return _caseWorkflowCountRepository.GetCaseCounts();
        }


        public IEnumerable<CaseWorkflowCount> GetCaseCountByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _caseWorkflowCountRepository.GetCaseCountByTreatmentCategoryID(treatmentCategoryID);
        }
    }
}
