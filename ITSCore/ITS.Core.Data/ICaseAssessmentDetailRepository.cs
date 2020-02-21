using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentDetailRepository : IBaseRepository<CaseAssessmentDetail>
    {
        int AddCaseAssessmentDetail(CaseAssessmentDetail caseAssessmentDetail);
        int UpdateCaseAssessmentDetailByCaseAssessmentDetailID(CaseAssessmentDetail caseAssessmentDetail);
        IEnumerable<CaseAssessmentDetail> GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID(int caseID,int assessmentServiceID);
        IEnumerable<CaseAssessmentDetail> GetAllCaseAssessmentDetailByCaseID(int caseID);
         
        CaseAssessmentDetail GetCaseAssessmentDetailByCaseAssessmentDetailID(int caseAssessmentDetailID);
        ReportModels.CaseAssessmentsDetails GetCaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID);

    }
}

