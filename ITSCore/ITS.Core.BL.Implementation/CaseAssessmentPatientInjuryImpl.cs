using ITS.Core.BL.Model;
using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class CaseAssessmentPatientInjuryImpl : ICaseAssessmentPatientInjury
    {
        private readonly ICaseAssessmentPatientInjuryRepository _caseAssessmentPatientInjuryRepository;
        private readonly IAffectedArea _affectedArea;
        private readonly IRestrictionRange _restrictionRange;
        private readonly IStrengthTesting _strengthTesting;
        private readonly ISymptomDescription _symptomDescription;

        public CaseAssessmentPatientInjuryImpl(ICaseAssessmentPatientInjuryRepository caseAssessmentPatientInjuryRepository, IAffectedArea affectedArea,
            IRestrictionRange restrictionRange, IStrengthTesting strengthTesting, ISymptomDescription symptomDescription)
        {
            _caseAssessmentPatientInjuryRepository = caseAssessmentPatientInjuryRepository;
            _affectedArea = affectedArea;
            _restrictionRange = restrictionRange;
            _strengthTesting = strengthTesting;
            _symptomDescription = symptomDescription;
        }

        public int AddCaseAssessmentPatientInjury(Data.Model.CaseAssessmentPatientInjury caseAssessmentPatientInjury)
        {
            return _caseAssessmentPatientInjuryRepository.AddCaseAssessmentPatientInjury(caseAssessmentPatientInjury);
        }

        public int UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(Data.Model.CaseAssessmentPatientInjury caseAssessmentPatientInjury)
        {
            return _caseAssessmentPatientInjuryRepository.UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(caseAssessmentPatientInjury);
        }

        public IEnumerable<CaseAssessmentPatientInjuryBL> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(int caseAssessmentID)
        {
            IEnumerable<Data.Model.CaseAssessmentPatientInjury> PatientInjuryDL = _caseAssessmentPatientInjuryRepository.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(caseAssessmentID);
            IList<CaseAssessmentPatientInjuryBL> patientInjuryBL = new List<CaseAssessmentPatientInjuryBL>();
            foreach (Data.Model.CaseAssessmentPatientInjury PatientInjury in PatientInjuryDL)
            {
                patientInjuryBL.Add(new CaseAssessmentPatientInjuryBL
                {
                    CaseAssessmentPatientInjuryID = PatientInjury.CaseAssessmentPatientInjuryID,
                    AffectedArea = PatientInjury.AffectedArea,
                    Restriction = PatientInjury.Restriction,
                    Score = PatientInjury.Score,
                    CaseAssessmentDetailID = PatientInjury.CaseAssessmentDetailID,
                    SymptomDescriptionName = PatientInjury.SymptomDescriptionID == 0 ?  "" : _symptomDescription.GetSymptomDescriptionDesciptionByID(PatientInjury.SymptomDescriptionID),
                    StrengthTestingDescription = PatientInjury.StrengthTestingID == 0 ? "" :_strengthTesting.GetStrengthTestingDesciptionByID(PatientInjury.StrengthTestingID),
                    AffectedAreaDescription = PatientInjury.AffectedAreaID == 0 ? "" : _affectedArea.GetAffectedAreaDesciptionByID(PatientInjury.AffectedAreaID),
                    RestrictionRangeDescription = PatientInjury.RestrictionRangeID == 0 ? "" :_restrictionRange.GetRestrictionRangeDesciptionByID(PatientInjury.RestrictionRangeID),
                    SymptomDescriptionID = PatientInjury.SymptomDescriptionID,
                    StrengthTestingID = PatientInjury.StrengthTestingID,
                    AffectedAreaID = PatientInjury.AffectedAreaID,
                    RestrictionRangeID = PatientInjury.RestrictionRangeID,
                    OtherSymptomDesciption = PatientInjury.OtherSymptomDesciption,
                });
            }
            return patientInjuryBL;

        }
    }
}

    
   