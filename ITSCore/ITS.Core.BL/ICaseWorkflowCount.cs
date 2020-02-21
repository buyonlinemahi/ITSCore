using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseWorkflowCount
    {
        IEnumerable<CaseWorkflowCount> GetCaseCounts();
        IEnumerable<CaseWorkflowCount> GetCaseCountByTreatmentCategoryID(int treatmentCategoryID);
    }
}
