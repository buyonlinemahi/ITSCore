using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Author : Satya
    * Latest Version : 1.0
    * Reason :- Interface For AssessmentType  
    * Created on 11-10-2012 
 
 Revision History
 Version : 1.0 ,Satya, 11-10-2012 
 Description: Add Method For AssessmentType
*/
#endregion

namespace ITS.Core.Data
{
    public interface ICasePatientTreatmentWorkflowRepository : IBaseRepository<CasePatientTreatmentWorkflow>
    {
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePatientName(string additionalParam, string patientName, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikePatientNameCount(string additionalParam, string patientName);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeReferrerName(string additionalParam, string referrerName, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikeReferrerNameCount(string additionalParam, string referrerName);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseNumber(string additionalParam, string caseNumber, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikeCaseNumberCount(string additionalParam, string caseNumber);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber(string additionalParam, string referrerReferenceNumber, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount(string additionalParam, string referrerReferenceNumber);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName(string additionalParam, string treatmentCategoryName, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount(string additionalParam, string treatmentCategoryName);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentTypeName(string additionalParam, string treatmentTypeName, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount(string additionalParam, string treatmentTypeName);
        IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePostCode(string additionalParam, string postCode, int skip, int take);
        int GetCasePatientTreatmentWorkflowLikePostCodeCount(string additionalParam, string postCode);

        CasePatientReferrerSupplierWorkflow GetCasePatientReferrerSupplierWorkflowByCaseID(int caseID);

        //IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCases(string searchText, int skip, int take);
        //int GetCasePatientTreatmentWorkflowAllCasesCount(string searchText);
        //IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesActive(string searchText, int skip, int take);
        //int GetCasePatientTreatmentWorkflowAllCasesActiveCount(string searchText);
        //IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesInActive(string searchText, int skip, int take);
        //int GetCasePatientTreatmentWorkflowAllCasesInActiveCount(string searchText);
    }
}
