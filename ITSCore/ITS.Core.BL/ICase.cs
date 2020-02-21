using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;

#region Comment
/*
 * 
 Latest Version : 1.1
 * 
 * 
 Page Name:  ICase.cs                      
 Latest Version:  1.0
 Author : Robin Singh
===================================================================================
 * 
    * Modified By : Pardeep Kumar
    * Description : Added new Method UpdateCaseIsTreatmentRequired
    * Date        : 29-06-2013 
    * Version     : 1.1 
*/
#endregion

namespace ITS.Core.BL
{
    public interface ICase
    {
        int AddCase(Case caseObj);
        int UpdateCaseByCaseID(Case caseObj);
        int DeleteCaseByCaseID(int caseID);
        Case GetCaseByCaseID(int caseID);
        Case GetCaseByPatientID(int PatientID);
        Employment GetEmploymentByEmploymentID(int EmploymentID);
        Policie GetPolicyByPolicyID(int _policyID);
        IEnumerable<Case> GetCaseByLikeCaseNumber(string caseNumber);
        int UpdateCaseWorkflowByCaseID(int caseID, int workflowID);
        int UpdateCaseWorkflowByCaseIDStoppedCase(int caseID);
        IEnumerable<Case> GetReferrerCasesByWorkflowID(int workflowID, int referrerID);
        DrugTest GetDrugTestByCaseID(int caseID);
        int AddNewReferral(Case caseObj, Patient patient, int userID, Solicitor solicitor, InjuredPartyRepresentative objInjuredPartyRepresentative, Employment objEmployment, Policie objPolicie, EmployeeDetail objDetail,PolicyOpenDetail policyOpenDetail = null, DrugTest objDrugTest = null,JobDemand objJobDemand = null);
        int UpdateReferral(Case caseObj, Patient patient, int userID, Solicitor solicitor = null, InjuredPartyRepresentative objInjuredPartyRepresentative = null, Employment objEmployment = null, Policie objPolicie = null, EmployeeDetail objDetail = null,PolicyOpenDetail policyOpenDetail = null, DrugTest objDrugTest = null, JobDemand objJobDemand = null);
        IEnumerable<Case> GetCasesByWorkFlowID(int workflowID);
        bool UpdateCaseWorkFlow(int caseID, int userID);
        bool UpdateCaseWorkFlowStoppedCase(int caseID, int userID);
        int AddBookIA(int caseID, DateTime patientContactDate, int? supplierAssignedUser, CaseAppointmentDate caseAppointmentDates, string InnovateNote);
        int UpdateCaseSupplier(int caseID, int supplierID);
        int UpdateCaseIsTreatmentRequired(int caseID, bool isTreatmentRequired);
        int UpdateCaseInvoiceDate(DateTime invoiceDate, int caseID);
        ReferrerAndSupplierPricing GetReferrerAndSupplierPricingVat(int caseID);
        ReferrerAndSupplierPricing GetReferrerAndSupplierPricingTriageAssessment(int caseID);
        IEnumerable<ReferrerAndSupplierPricing> GetReferrerAndSupplierPricing(int caseID);
        bool UpdateCaseWorkflowCustomByCaseID(int caseID,int userID, int workflowID);
        int GetReferrerProjectTreatmentDocumentSetup(int caseID, int AssessmentServiceID);
        int GetCaseAssessmentCustomsByCaseID(int caseID);
        IntialAssessmentReportDetail GetIntialAssessmentReportDetailsByCaseID(int caseID);
        EvaluateDelegatedAuthorisationCost GetEvaluateDelegatedAuthorisationCost(int caseID, int assessmentTypeID);
        IntialAssessmentReportDetail GetInitialReviewAssessmentByCaseID(int caseID);
        int DeletePatientContactAttemptByID(int CasePatientContactAttemptID);
        IEnumerable<CasePatientContactAttempt> GetUnsuccessfulContactDate(int caseID);
        IEnumerable<CasePatientContactAttempt> GetPatientContactDate(int caseID);
        NotificationBubble GetNotificationBubbleCountBySupplierID(int _supplierID);
        IEnumerable<BLCaseReferrerAssignedUser> GetCaseReferrerAssignedUsersByCaseID(int CaseID);
        int AddCaseReferrerAssignedUser(CaseReferrerAssignedUser _CaseReferrerAssignedUser);
        int DeleteCaseReferrerAssignedUserByID(int id);
        PolicyOpenDetail GetPolicyOpenDetailByID(int _ID);
        IEnumerable<Gip> GetAllGips();
        IEnumerable<Tpd> GetAllTpds();
        IEnumerable<Iip> GetAllIips();
        IEnumerable<ElRehab> GetAllElRehabs();
    }
}
