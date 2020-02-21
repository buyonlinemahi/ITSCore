using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{
    public interface ICasePatientRepository : IBaseRepository<CasePatient>
    {
        CasePatient GetCasePatientByCaseIDAndWorkflowID(int caseID, int workFlowID);

        CasePatientTreatment GetPatientAndCaseByCaseID(int caseID);

        IEnumerable<ReferrerSupplierCases> GetCaseSearchLikePatientName(string patientName);

        IEnumerable<ReferrerSupplierCases> GetCaseSearchLikeReferrerReferenceNumber(string referrerReferenceNumber);

        IEnumerable<CasePatientSearch> GetCasePatientLikeCaseNumber(string caseNumber);

        CasePatientReferrer GetCasePatientReferrerByCaseID(int caseID);

        IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndReferrerID(string additionalParam, string patientName, int referrerID, int userID, int skip, int take);

        IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndSupplierID(string patientName, int supplierID, int userID, int skip, int take);

        int GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount(string patientName, int supplierID, int userID);

        int GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount(string additionalParam,string patientName, int referrerID,int userID);

        IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID(string additionalParam, string referrerReferenceNumber, int referrerID,int userID, int skip, int take);

        int GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount(string additionalParam, string referrerReferenceNumber, int referrerID,int userID);

        IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeCaseNumberAndSupplierID(string caseNumber, int supplierID, int userID, int skip, int take);

        int GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount(string caseNumber, int supplierID, int userID);
        ReportModels.PatientAndCase GetPatientAndCaseByCaseIDReports(int caseID);
    }
}