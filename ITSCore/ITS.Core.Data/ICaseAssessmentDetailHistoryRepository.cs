using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentDetailHistoryRepository : IBaseRepository<CaseAssessmentDetailHistory>
    {
        int AddCaseAssessmentDetailHistory(CaseAssessmentDetail caseAssessmentDetailHistory);
       
    }
}


