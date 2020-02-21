namespace ITS.Core.BL.Implementation.Global
{
    public class GlobalConst
    {
        public struct WorkFlow
        {
            public const int ReferralSubmitted = 10;
            public const int ReferralAccepted = 20;
            public const int PatientContacted = 30;
            public const int ReferredtoSupplier = 40;
            public const int ReferreredtoTriageSupplier = 42;
            public const int InitialAssessmentBooked = 50;
            public const int InitialAssessmentBookedCustom = 52;
            public const int InitialAssessmentSupplierCustom = 55; 
            public const int InitialAssessmentAttended = 60; //not used anymore
            public const int TriageAssessmentSubmittedtoInnovate = 65;
            public const int InitialAssessmentSubmittedtoInnovate = 70;
            public const int InitialAssessmentSubmittedtoInnovateCustom = 72;
            public const int ReportNotAccepted = 80;
            public const int ReportNotAcceptedCustom = 82;
            public const int InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation = 90;
            public const int InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisationCustom = 92;
            public const int AuthorisationSenttoInnovate = 100;
            public const int AuthorisationSenttoInnovateCustom = 102;
            public const int PatientInTreatment = 105;
            public const int PatientInTreatmentCustom = 107;
            public const int AuthorisationSenttoSupplierOrPatientinTreatment = 110;
            public const int AuthorisationSenttoSupplierOrPatientinTreatmentCustom = 115;
            public const int ReviewAssessmentAttended = 120;
            public const int ReviewAssessmentReportSubmittedtoInnovate = 130;
            public const int ReviewAssessmentReportSubmittedtoInnovateCustom = 132;
            public const int ReviewAssessmentReportNotAccepted = 140;
            public const int ReviewAssessmentReportNotAcceptedCustom = 142;
            public const int ReviewAssessmentReportSubmittedtoReferrer = 150;
            public const int ReviewAssessmentReportSubmittedtoReferrerCustom = 152;
            public const int FinalAssessmentReportSubmittedtoInnovate = 160;
            public const int FinalAssessmentReportSubmittedtoInnovateCustom = 162;
            public const int FinalAssessmentReportNotAccepted = 170;
            public const int FinalAssessmentReportNotAcceptedCustom = 172;
            public const int FinalAssessmentReportSubmittedtoReferrer = 180;
            public const int FinalAssessmentReportSubmittedtoReferrerCustom = 182;
            public const int CaseStopped = 200;
            public const int CaseStoppedSenttoSupplier = 205;
            public const int CaseCompleted = 210;
            public const int CaseCompletedCustom = 212;
            public const int InvoiceSent = 220;
                     
        }
        
        public struct EventType
        {
            public const int WORKFLOW = 1;
            public const int TASK = 2;
        }

        public struct Status
        {
            public const int Complete = 1;
            public const int Pending = 2;
        }

        public struct WorkflowEventDescription
        {
            public const string ReferralSubmitted = "Referral Submitted";
            public const string ReferralAccepted = "Referral Accepted";
            public const string PatientContacted = "Patient Contacted";
            public const string ReferredtoSupplier = "Referred to Supplier";
            public const string ReferreredtoTriageSupplier = "Referred to Triage Supplier";
            public const string InitialAssessmentBooked = "Initial Assessment Booked";
            public const string InitialAssessmentBookedCustom = "Initial Assessment Booked Custom";
            public const string InitialAssessmentSupplierCustom = "Initial Assessment Supplier Custom";
            public const string InitialAssessmentAttended = "Initial Assessment Attended";
            public const string TriageAssessmentSubmittedtoInnovate = "Triage Assessment Submitted to Innovate";
            public const string InitialAssessmentSubmittedtoInnovate = "Initial Assessment Submitted to Innovate"; 
            public const string InitialAssessmentSubmittedtoInnovateCustom = "Initial Assessment Submitted to Innovate Custom";
            public const string ReportNotAccepted = "Report Not Accepted";
            public const string ReportNotAcceptedCustom = "Report Not Accepted Custom";                      
            public const string InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation = "Initial Assessment Report Submitted to Referrer Or Awaiting Authorisation";
            public const string InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisationCustom = "Initial Assessment Report Submitted to Referrer Or Awaiting Authorisation Custom";
            public const string AuthorisationSenttoInnovate = "Authorisation Sent to Innovate";
            public const string AuthorisationSenttoInnovateCustom = "Authorisation Sent to Innovate Custom";
            public const string PatientInTreatment = "Patient in Treatment";
            public const string PatientInTreatmentCustom = "Patient in Treatment Custom";
            public const string AuthorisationSenttoSupplierOrPatientinTreatment = "Authorisation Sent to Supplier Or Patient in Treatment";
            public const string AuthorisationSenttoSupplierOrPatientinTreatmentCustom = "Authorisation Sent to Supplier / Patient in Treatment Custom";
            public const string ReviewAssessmentAttended = "Review Assessment Attended";
            public const string ReviewAssessmentReportSubmittedtoInnovate = "Review Assessment Report Submitted to Innovate";
            public const string ReviewAssessmentReportSubmittedtoInnovateCustom = "Review Assessment Report Submitted to Innovate Custom";
            public const string ReviewAssessmentReportNotAccepted = "Review Assessment Report Not Accepted";
            public const string ReviewAssessmentReportNotAcceptedCustom = "Review Assessment Report Not Accepted Custom";
            public const string ReviewAssessmentReportSubmittedtoReferrer = "Review Assessment Report Submitted to Referrer";
            public const string ReviewAssessmentReportSubmittedtoReferrerCustom ="Review Assessment Report Submitted to Referrer Custom";
            public const string FinalAssessmentReportSubmittedtoInnovate = "Final Assessment Report Submitted to Innovate";
            public const string FinalAssessmentReportSubmittedtoInnovateCustom = "Final Assessment Report Submitted to Innovate Custom";
            public const string FinalAssessmentReportNotAccepted = "Final Assessment Report Not Accepted";
            public const string FinalAssessmentReportNotAcceptedCustom = "Final Assessment Report Not Accepted Custom";
            public const string FinalAssessmentReportSubmittedtoReferrer = "Final Assessment Report Submitted to Referrer";
            public const string FinalAssessmentReportSubmittedtoReferrerCustom = "Final Assessment Report Submitted to Referrer Custom";
            public const string FinalAssessmentAttended = "Final Assessment Attended";            
            public const string CaseStopped = "Case Stopped";
            public const string CaseStoppedSenttoSupplier = "Case Stopped Sent to Supplier";
            public const string CaseCompleted = "Case Completed";
            public const string CaseCompletedCustom = "Case Completed Custom";
            public const string InvoiceSent = "Invoice Sent";
            
        }

        public struct AppSetting
        {
            public const int FAILEDATTEMPTCOUNT = 5;
        }

        public struct AssessmentAuthorisation
        {
            public const int APPROVED = 1;
            public const int MODIFIED = 2;
            public const int DENIED = 3;
        }

        public struct CaseAssessment
        {
            public const int AssessmentAuthorisationID = 1;
            public const int AssessmentServiceID = 1;
        }

        public struct AssessmentService
        {
            public const int InitialAssessment = 1;
            public const int ReviewAssessment = 2;
            public const int FinalAssessment = 3;

        }

        public struct DocumentType
        {
            public const int Registration = 1;
            public const int Insurance = 2;
            public const int SupplierAudit = 3;
            public const int SupplierClinicalAudit = 4;
            public const int Referral = 5;
            public const int Triage = 6;
        }

        public struct PricingType
        {
            public const int INITIALASSESSMENT = 1;
            public const int REVIEWASSESSMENT = 2;
            public const int FINALASSESSMENT = 3;
            public const int TREATMENTSESSION = 4;
            public const int DIDNOTSHOW = 5;
            public const int VAT = 7;
            public const int TRIAGEASSESSMENT = 15;
            
        }


        public struct DelegatedAuthorisationType
        {
            public const int Session = 1;
            public const int Cost = 2;


        }
        
    }
}