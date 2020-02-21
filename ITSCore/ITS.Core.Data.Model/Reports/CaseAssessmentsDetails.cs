using System;

namespace ITS.Core.Data.Model.Reports
{
    public class CaseAssessmentsDetails
    {

        public int CaseAssessmentDetailID {get;set;}
        public int AssessmentServiceID {get;set;}
        public int CaseID {get;set;}
        public bool? HasThePatientHadTimeOff {get;set;}
        public string AbsentDetail {get;set;}
        public int AbsentPeriod {get;set;}
        public bool? HasThePatientReturnedToWork {get;set;}
        public int PatientRecommendedTreatmentSessions {get;set;}
        public string PatientRecommendedTreatmentSessionsDetail {get;set;}
        public int PatientTreatmentPeriod {get;set;}
        public string PatientTreatmentPeriodDetail {get;set;}
        public bool IsFurtherTreatmentRecommended {get;set;}
        public int SessionsPatientAttended {get;set;}
        public string DatesOfSessionAttended {get;set;}
        public int SessionsPatientFailedToAttend {get;set;}
        public string AdditionalInformation {get;set;}
        public string HasCompliedHomeExerciseProgramme {get;set;}
        public DateTime AssessmentDate {get;set;}
        public string PatientImpactOnWorkName {get;set;}
        public string PatientWorkstatusName {get;set;}
        public string PatientTreatmentPeriodDuration {get;set;}
        public string PatientLevelOfRecoveryName {get;set;}
        public int? FollowingTreatmentPatientLevelOfRecovery {get;set;}
        public string PractitionerFirstName {get;set;}
        public string PractitionerLastName {get;set;}
        public string AbsentPeriodDuration { get; set; }
    }
}
