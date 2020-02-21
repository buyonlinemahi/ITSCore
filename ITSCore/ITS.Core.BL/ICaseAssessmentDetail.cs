
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICaseAssessmentDetail
    {
          int AddCaseAssessmentDetail(CaseAssessmentDetail caseAssessmentDetail);
          IEnumerable<CaseAssessmentDetail> GetAllCaseAssessmentDetailByCaseID(int caseID);

          IEnumerable<CaseAssessmentDetail> GetQASubmitedCaseAssessmentDetailsByCaseID(int caseID);
    }
}