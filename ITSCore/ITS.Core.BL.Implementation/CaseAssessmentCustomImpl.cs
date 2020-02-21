using ITS.Core.Data;
using DLModel = ITS.Core.Data.Model;


namespace ITS.Core.BL.Implementation
{
    public class CaseAssessmentCustomImpl : ICaseAssessmentCustom
    {
        private readonly ICaseAssessmentCustomRepository _caseAssessmentCustomRepository;


        public CaseAssessmentCustomImpl( ICaseAssessmentCustomRepository caseAssessmentCustomRepository)
        {
           
            _caseAssessmentCustomRepository = caseAssessmentCustomRepository;
        }

        public int AddCaseAssessmentCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom)
        {
            int caseid = _caseAssessmentCustomRepository.AddCaseAssessmentCustom(caseAssessmentCustom);
            return caseid;
        }
        public int UpdateCaseAssessmentCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom)
        {
            int caseid = _caseAssessmentCustomRepository.UpdateCaseAssessmentCustom(caseAssessmentCustom);
            return caseid;
        }
        public int UpdateCaseRiewAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom)
        {
            int caseid = _caseAssessmentCustomRepository.UpdateCaseRiewAssessmentMessageCustom(caseAssessmentCustom);
            return caseid;
        }
        public int UpdateCaseInitialAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom)
        {
            int caseid = _caseAssessmentCustomRepository.UpdateCaseInitialAssessmentMessageCustom(caseAssessmentCustom);
            return caseid;
        }
        public int UpdateCaseFinalAssessmentMessageCustom(ITS.Core.Data.Model.CaseAssessmentCustom caseAssessmentCustom)
        {
            int caseid = _caseAssessmentCustomRepository.UpdateCaseFinalAssessmentMessageCustom(caseAssessmentCustom);
            return caseid;
        }
        public DLModel.CaseAssessmentCustom GetCaseAssessmentCustomByCaseID(int CaseID)
        {
            return _caseAssessmentCustomRepository.GetCaseAssessmentCustomByCaseID(CaseID);
        }
    }
}
