using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
   public class CasePatientImpl : ICasePatient
    {
       private readonly ICasePatientRepository _casePatientRepository;

       public CasePatientImpl(ICasePatientRepository casePatientRepository)
         {
             _casePatientRepository = casePatientRepository;
         }


       public CasePatient GetBookIACasePatientByCaseID(int caseID)
       {
           return _casePatientRepository.GetCasePatientByCaseIDAndWorkflowID(caseID, Global.GlobalConst.WorkFlow.ReferredtoSupplier);    


       }

       public CasePatientTreatment GetPatientAndCaseByCaseID(int caseID)
       {
           return _casePatientRepository.GetPatientAndCaseByCaseID(caseID);   
       }



       public IEnumerable<ReferrerSupplierCases> GetCaseSearchLikePatientName(string patientName)
       {
           return _casePatientRepository.GetCaseSearchLikePatientName(patientName);   
       }

       public IEnumerable<ReferrerSupplierCases> GetCaseSearchLikeReferrerReferenceNumber(string referrerReferenceNumber)
       {
           return _casePatientRepository.GetCaseSearchLikeReferrerReferenceNumber(referrerReferenceNumber);   
       }


       public IEnumerable<CasePatientSearch> GetCasePatientLikeCaseNumber(string caseNumber)
       {
           return _casePatientRepository.GetCasePatientLikeCaseNumber(caseNumber);  
       }


       public CasePatientReferrer GetCasePatientReferrerByCaseID(int caseID)
       {
           return _casePatientRepository.GetCasePatientReferrerByCaseID(caseID); 
       }


       public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndReferrerID(string additionalParam,string patientName, int referrerID,int userID, int skip, int take)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikePatientNameAndReferrerID(additionalParam,patientName, referrerID,userID, skip, take);  
       }

       public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndSupplierID(string patientName, int supplierID,int userID, int skip, int take)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikePatientNameAndSupplierID(patientName, supplierID, userID, skip, take);  
       }

       public int GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount(string patientName, int supplierID,int userID)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount(patientName, supplierID,userID);  
       }

       public int GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount(string additionalParam,string patientName, int referrerID,int userID)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount(additionalParam, patientName, referrerID, userID);  
       }

       public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID(string additionalParam,string referrerReferenceNumber, int referrerID,int userID, int skip, int take)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID(additionalParam,referrerReferenceNumber, referrerID,userID, skip, take);  
       }

       public int GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount(string additionalParam,string referrerReferenceNumber, int referrerID,int userID)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount(additionalParam, referrerReferenceNumber, referrerID, userID);  
       }

       public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeCaseNumberAndSupplierID(string caseNumber, int supplierID,int userID, int skip, int take)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikeCaseNumberAndSupplierID(caseNumber, supplierID,userID, skip, take);  
       }

       public int GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount(string caseNumber, int supplierID,int userID)
       {
           return _casePatientRepository.GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount(caseNumber, supplierID,userID);  
       }
    }


     
      

      


}
