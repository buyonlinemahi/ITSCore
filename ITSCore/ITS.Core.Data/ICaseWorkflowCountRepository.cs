using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseWorkflowCountRepository : IBaseRepository<CaseWorkflowCount>
    {
        IEnumerable<CaseWorkflowCount> GetCaseCounts();
        IEnumerable<CaseWorkflowCount> GetCaseCountByTreatmentCategoryID(int treatmentCategoryID);
    
    }
}
