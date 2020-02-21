    using System;
using System.Collections.Generic;

namespace ITS.Core.BL.Model
{
    public class CaseAssessment
    {
        public int CaseID { get; set; }
        public int AssessmentServiceID { get; set; }
        public bool? HasPatientConsentForm { get; set; }
        public string IncidentAndDiagnosisDescription { get; set; }
        public string NeuralSymptomDescription { get; set; }
        public string RelevantTestUndertaken { get; set; }
        public string PreExistingConditionDescription { get; set; }
        public bool? IsPatientUndergoingTreatment { get; set; }
        public bool? IsPatientTakingMedication { get; set; }
        public bool? PatientRequiresFurtherInvestigation { get; set; }
        public string FactorsAffectingTreatmentDescription { get; set; }
        public string PatientOccupation { get; set; }
        public int PatientRoleID { get; set; }
        public bool? WasPatientWorkingAtTheTimeOfTheAccident { get; set; }
        public DateTime? AnticipatedDateOfDischarge { get; set; }
        public bool? HasPatientHomeExerciseProgramme { get; set; }
        public DateTime AssessmentDate { get; set; }
        public bool? IsPatientSufferingFinancialLoss { get; set; }
        public bool HasPatientPastSymptoms { get; set; }
        public int AssessmentAuthorisationID { get; set; }
        public string AuthorisationDetail { get; set; }
        public bool IsAccepted { get; set; }
        public bool? IsPatientDischarge { get; set; }
        public string DeniedMessage { get; set; }
        public int UserID { get; set; }
        public bool? HasYellowFlags { get; set; }
        public bool? HasRedFlags { get; set; }
        public bool? IsSaved { get; set; }
        public IList<CaseAssessmentPatientImpact> CaseAssessmentPatientImpacts { get; set; }
        public IList<CaseAssessmentPatientInjuryBL> CaseAssessmentPatientInjuriesBL { get; set; }
        public IList<CaseAssessmentPatientInjury> CaseAssessmentPatientInjuries { get; set; }
        public IList<CaseAssessmentProposedTreatmentMethod> CaseAssessmentProposedTreatmentMethods { get; set; }
        public CaseAssessmentRating CaseAssessmentRating { get; set; }
        public CaseAssessmentDetail CaseAssessmentDetail { get; set; }

        public CaseAssessment()
        {
            CaseAssessmentPatientImpacts = new List<CaseAssessmentPatientImpact>();
            CaseAssessmentPatientInjuriesBL = new List<CaseAssessmentPatientInjuryBL>();
            CaseAssessmentProposedTreatmentMethods = new List<CaseAssessmentProposedTreatmentMethod>();
            CaseAssessmentPatientInjuries = new List<CaseAssessmentPatientInjury>();
        }

    }

    public class CaseAssessmentPatientImpact
    {
        public int CaseAssessmentPatientImpactID { get; set; }
        public int PatientImpactID { get; set; }
        public int PatientImpactValueID { get; set; }
        public string Comment { get; set; }
        public int CaseAssessmentDetailID { get; set; }
    }

    public class CaseAssessmentPatientInjury
    {
        public int CaseAssessmentPatientInjuryID { get; set; }
        public string AffectedArea { get; set; }
        public string Restriction { get; set; }
        public string Score { get; set; }
        public int CaseAssessmentDetailID { get; set; }
        public int SymptomDescriptionID { get; set; }
        public int StrengthTestingID { get; set; }
        public int AffectedAreaID { get; set; }
        public int RestrictionRangeID { get; set; }
        public string OtherSymptomDesciption { get; set; }
    }

    public class CaseAssessmentRating
    {
        public int CaseAssessmentRatingID { get; set; }
        public int CaseID { get; set; }
        public int AssessmentServiceID { get; set; }
        public decimal Rating { get; set; }
        public DateTime RatingDate { get; set; }
    }

    public class CaseAssessmentDetail
    {
        public int CaseAssessmentDetailID { get; set; }
        public int AssessmentServiceID { get; set; }
        public int CaseID { get; set; }
        public bool? HasThePatientHadTimeOff { get; set; }
        public string AbsentDetail { get; set; }
        public int AbsentPeriod { get; set; }
        public int? AbsentPeriodDurationID { get; set; }
        public bool? HasThePatientReturnedToWork { get; set; }
        public int PatientImpactOnWorkID { get; set; }
        public int PatientWorkstatusID { get; set; }
        public int PatientRecommendedTreatmentSessions { get; set; }
        public string PatientRecommendedTreatmentSessionsDetail { get; set; }
        public int PatientTreatmentPeriod { get; set; }
        public int? PatientTreatmentPeriodDurationID { get; set; }
        public bool? IsFurtherTreatmentRecommended { get; set; }
        public int? PatientLevelOfRecoveryID { get; set; }
        public int SessionsPatientAttended { get; set; }
        public string DatesOfSessionAttended { get; set; }
        public int SessionsPatientFailedToAttend { get; set; }
        public int? FollowingTreatmentPatientLevelOfRecoveryID { get; set; }
        public string AdditionalInformation { get; set; }
        public bool? HasCompliedHomeExerciseProgramme { get; set; }
        public string PatientTreatmentPeriodDetail { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int? PractitionerID { get; set; }
        public string EvidenceOfClinicalReasoning { get; set; }
        public bool? IsFurtherInvestigationOrOnwardReferralRequired { get; set; }
        public string FurtherInvestigationOrOnwardReferral { get; set; }
        public string EvidenceOfTreatmentRecommendations { get; set; }
        public int TreatmentPeriodTypeID { get; set; }
        public DateTime? PatientDateOfReturn { get; set; }
        public string PatientRecommendationReturn { get; set; }
        public bool? IsPatientReturnToPreInjuryDuties { get; set; }
        public DateTime? PatientPreInjuryDutiesDate { get; set; }
        public string MainFactors { get; set; }
    }

    public class CaseAssessmentProposedTreatmentMethod
    {
        public int CaseID { get; set; }
        public int ProposedTreatmentMethodID { get; set; }
    }

    public class ReferrerCaseAssessmentModification
    {
        public int ReferrerCaseAssessmentModificationID { get; set; }
        public int CaseID { get; set; }
        public int TreatmentSession { get; set; }
        public int AssessmentServiceID { get; set; }
    }

    public class EPNATreatmentSession
    {
        public int SessionsAuthorised { get; set; }
        public int SessionsAttended { get; set; }
    }
}