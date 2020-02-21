using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation
{
    public class CaseAssessmentDetailImpl : ICaseAssessmentDetail
    {
        private readonly ICaseAssessmentDetailRepository _caseAssessmentDetailRepository;
        private readonly ICaseAssessmentDetailHistoryRepository _caseAssessmentDetailHistoryRepository;

        private readonly ICaseRepository _caseRepository;

        public CaseAssessmentDetailImpl(ICaseAssessmentDetailRepository caseAssessmentDetailRepository, ICaseAssessmentDetailHistoryRepository caseAssessmentDetailHistoryRepository, ICaseRepository caseRepository)
        {
            _caseAssessmentDetailHistoryRepository = caseAssessmentDetailHistoryRepository;
            _caseAssessmentDetailRepository = caseAssessmentDetailRepository;
            _caseRepository = caseRepository;
        }

        public int AddCaseAssessmentDetail(CaseAssessmentDetail caseAssessmentDetail)
        {
            int caseAssessmentDetailID = _caseAssessmentDetailRepository.AddCaseAssessmentDetail(caseAssessmentDetail);
            caseAssessmentDetail.CaseAssessmentDetailID = caseAssessmentDetailID;
            _caseAssessmentDetailHistoryRepository.AddCaseAssessmentDetailHistory(caseAssessmentDetail);
            return caseAssessmentDetailID;
        }

        public System.Collections.Generic.IEnumerable<CaseAssessmentDetail> GetAllCaseAssessmentDetailByCaseID(int caseID)
        {
            return _caseAssessmentDetailRepository.GetAllCaseAssessmentDetailByCaseID(caseID);
        }

        public IEnumerable<CaseAssessmentDetail> GetQASubmitedCaseAssessmentDetailsByCaseID(int caseID)
        {
            var CaseAssessmentDetails = _caseAssessmentDetailRepository.GetAllCaseAssessmentDetailByCaseID(caseID).ToList();
            int workflowID = _caseRepository.GetCaseByCaseID(caseID).WorkflowID;

            if (CaseAssessmentDetails != null && CaseAssessmentDetails.Count > 0)
            {
                switch (CaseAssessmentDetails.Last().AssessmentServiceID)
                {
                    case 1:
                        //if (workflowID != Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment)// 80 check will be added for Reject initial assessment report reject.
                        if (workflowID < 90)
                        {
                            CaseAssessmentDetails.Remove(CaseAssessmentDetails.ToList().LastOrDefault());
                        }
                        break;
                    case 2:
                        //if (workflowID != Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment) // 140 check will be added for Reject review assessment report reject
                        if (workflowID < 150)
                        {
                            CaseAssessmentDetails.Remove(CaseAssessmentDetails.ToList().LastOrDefault());
                        }
                        break;
                    case 3:
                        //if (workflowID != Global.GlobalConst.WorkFlow.CaseCompleted && workflowID != Global.GlobalConst.WorkFlow.InvoiceSent) // 170 check will be added for Final assessment report reject
                        if (workflowID < 180) 
                        {
                            CaseAssessmentDetails.Remove(CaseAssessmentDetails.ToList().LastOrDefault());
                        }
                        break;
                }
            }
            return CaseAssessmentDetails.AsEnumerable();
        }
    }
}