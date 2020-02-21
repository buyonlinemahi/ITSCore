using System;

namespace ITS.Core.Data.Model.Reports
{
    public class CaseAssessments
    {
           public int AssessmentServiceID {get;set;}
           public int CaseID { get; set; }
           public bool HasPatientConsentForm { get; set; }
           public string IncidentAndDiagnosisDescription {get;set;}
           public string NeuralSymptomDescription {get;set;}
           public string PreExistingConditionDescription {get;set;}
           public bool IsPatientTakingMedication { get; set; }
           public string FactorsAffectingTreatmentDescription {get;set;}
           public bool IsPatientUndergoingTreatment { get; set; }
           public bool PatientRequiresFurtherInvestigation { get; set; }
           public int PatientRoleID {get;set;}
           public string PatientOccupation {get;set;}
           public bool? WasPatientWorkingAtTheTimeOfTheAccident { get; set; }
           public bool IsPatientSufferingFinancialLoss { get; set; }
           public DateTime? AnticipatedDateOfDischarge { get; set; }
           public bool HasPatientHomeExerciseProgramme {get;set;}
           public bool HasPatientPastSymptoms { get; set; }
           public int AssessmentAuthorisationID {get;set;}
           public bool IsAccepted {get;set;}
           public string AuthorisationDetail {get;set;}
           public bool IsPatientDischarge {get;set;}
           public string DeniedMessage {get;set;}
           public bool HasYellowFlags {get;set;}
           public int UserID {get;set;}
           public bool HasRedFlags {get;set;}
           public string PatientRoleName {get;set;}
    }
}
