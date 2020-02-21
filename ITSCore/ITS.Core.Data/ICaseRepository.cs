using Core.Base.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;

/*
Latest Version:1.1
 * Author : Robin Singh
 * Date : 01/03/2013
 * Task : #380
 * Description : Add Case Interface Repository
 * Description : Add Curd Method for Case Model.
 * 
    * Modified By : Pardeep Kumar
    * Description : Added new Method UpdateCaseIsTreatmentRequired
    * Date        : 29-06-2013 
    * Version     : 1.1 

 */
namespace ITS.Core.Data
{
    public interface ICaseRepository : IBaseRepository<Case>
    {
        int AddCase(Case caseObj);
        int UpdateCaseByCaseID(Case caseObj);
        int DeleteCaseByCaseID(int caseID);
        int UpdateCaseWorkflowByCaseID(int caseID, int workflowID);
        int UpdateCaseWorkflowCustomByCaseID(int caseID,int userID, int workflowID);
        int UpdateCaseWorkflowByCaseIDStoppedCase(int caseID);
        Case GetCaseByCaseID(int caseID);
        Case GetCaseByPatientID(int PatientID);
        IEnumerable<Case> GetCaseByLikeCaseNumber(string caseNumber);
        IEnumerable<Case> GetReferrerCasesByWorkflowID(int workflowID, int referrerID);
        IEnumerable<Case> GetCasesByWorkFlowID(int workflowID);
        int UpdateCaseSupplier(int caseID, int supplierID);
        IEnumerable<SupplierCasePatient> GetSupplierCasesAndPatientByWorkflowID(int supplierID, int workflowID);
        int UpdateCasePatientContactDateByCaseID(int caseID, DateTime patientContactDate, int? supplierAssignedUser, string innovateNote);
        int UpdateCaseIsTreatmentRequired(int caseID, bool isTreatmentRequired);
        int UpdateCaseInvoiceDate(DateTime invoiceDate, int caseID);
        int GetReferrerProjectTreatmentDocumentSetup(int caseID, int AssessmentServiceID);
        int GetCaseAssessmentCustomsByCaseID(int caseID);
        IntialAssessmentReportDetail GetIntialAssessmentReportDetailsByCaseID(int caseID);
        EvaluateDelegatedAuthorisationCost GetEvaluateDelegatedAuthorisationCost(int caseID, int assessmentTypeID);
        IntialAssessmentReportDetail GetInitialReviewAssessmentByCaseID(int caseID);
        IEnumerable<CasePatientContactAttempt> GetUnsuccessfulContactDate(int caseID);
        IEnumerable<CasePatientContactAttempt> GetPatientContactDate(int caseID);
        IEnumerable<BLCaseReferrerAssignedUser> GetCaseReferrerAssignedUsersByCaseID(int CaseID);
        int AddCaseReferrerAssignedUser(CaseReferrerAssignedUser _CaseReferrerAssignedUser);
        int DeleteCaseReferrerAssignedUserByID(int id); 
    }
}
