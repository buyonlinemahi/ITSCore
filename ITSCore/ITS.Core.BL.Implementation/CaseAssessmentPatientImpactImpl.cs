using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class CaseAssessmentPatientImpactImpl : ICaseAssessmentPatientImpact
    {

        private readonly ICaseAssessmentPatientImpactRepository _caseAssessmentPatientImpact;

        public CaseAssessmentPatientImpactImpl(ICaseAssessmentPatientImpactRepository caseAssessmentPatientImpact)
        {
            _caseAssessmentPatientImpact = caseAssessmentPatientImpact;
        }


        public int UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(CaseAssessmentPatientImpact caseAssessmentPatientImpact)
        {
            return _caseAssessmentPatientImpact.UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(caseAssessmentPatientImpact);
        }


        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactID(int patientImpactID)
        {
            return _caseAssessmentPatientImpact.GetCaseAssessmentPatientImpactsByPatientImpactID(patientImpactID);
        }

        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactValueID(int patientImpactValueID)
        {
            return _caseAssessmentPatientImpact.GetCaseAssessmentPatientImpactsByPatientImpactValueID(patientImpactValueID);
        }

        public IEnumerable<CaseAssessmentPatientImpact> GetAllCaseAssessmentPatientImpacts()
        {
            return _caseAssessmentPatientImpact.GetAll();
        }

        public int AddCaseAssessmentPatientImpact(CaseAssessmentPatientImpact caseAssessmentPatientImpact)
        {           
            return _caseAssessmentPatientImpact.AddCaseAssessmentPatientImpact(caseAssessmentPatientImpact);
        }

        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(int CaseAssessmentDetailID)
        {
            return _caseAssessmentPatientImpact.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(CaseAssessmentDetailID);
        }
    }
}