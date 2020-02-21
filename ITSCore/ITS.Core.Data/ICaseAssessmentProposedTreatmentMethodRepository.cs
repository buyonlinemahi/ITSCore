using Core.Base.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentProposedTreatmentMethodRepository : IBaseRepository<CaseAssessmentProposedTreatmentMethod>
    {

        int AddCaseAssessmentProposedTreatmentMethod(int caseID, int proposedTreatmentMethodID);
        int DeleteCaseAssessmentProposedTreatmentMethodByCaseID(int caseID);
        IEnumerable<CaseAssessmentProposedTreatmentMethod> GetCaseAssessmentProposedTreatmentMethodsByCaseID(int caseID);
        int UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID(int CaseID, int AssessmentServiceID, DateTime AssessmentDate);
        System.Collections.Generic.IEnumerable<ReportModels.CaseAssessmentProposedTreatmentMethodsAndValues> GetCaseAssessmentProposedTreatmentMethodsAndValuesByCaseID(int caseID, string reportType);
    }
}
