using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{

    public class CasePatientTreatmentWorkflowImpl : ICasePatientTreatmentWorkflow
    {

        private readonly ICasePatientTreatmentWorkflowRepository _casePatientTreatmentWorkflowRepository;

        public CasePatientTreatmentWorkflowImpl(ICasePatientTreatmentWorkflowRepository casePatientTreatmentWorkflowRepository)
        {
            _casePatientTreatmentWorkflowRepository = casePatientTreatmentWorkflowRepository;
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePatientName(string additionalParam, string patientName, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikePatientName(additionalParam, patientName, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikePatientNameCount(string additionalParam, string patientName)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikePatientNameCount(additionalParam,patientName);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeReferrerName(string additionalParam, string referrerName, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeReferrerName(additionalParam, referrerName, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikeReferrerNameCount(string additionalParam, string referrerName)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeReferrerNameCount(additionalParam, referrerName);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseNumber(string additionalParam, string caseNumber, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeCaseNumber(additionalParam, caseNumber, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikeCaseNumberCount(string additionalParam, string caseNumber)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeCaseNumberCount(additionalParam, caseNumber);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber(string additionalParam, string referrerReferenceNumber, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber(additionalParam, referrerReferenceNumber, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount(string additionalParam, string referrerReferenceNumber)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount(additionalParam, referrerReferenceNumber);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName(string additionalParam, string treatmentCategoryName, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName(additionalParam, treatmentCategoryName, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount(string additionalParam, string treatmentCategoryName)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount(additionalParam, treatmentCategoryName);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentTypeName(string additionalParam, string treatmentTypeName, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeTreatmentTypeName(additionalParam, treatmentTypeName, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount(string additionalParam, string treatmentTypeName)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount(additionalParam, treatmentTypeName);
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePostCode(string additionalParam, string postCode, int skip, int take)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikePostCode(additionalParam, postCode, skip, take);
        }

        public int GetCasePatientTreatmentWorkflowLikePostCodeCount(string additionalParam, string postCode)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowLikePostCodeCount(additionalParam, postCode);
        }


        public CasePatientReferrerSupplierWorkflow GetCasePatientReferrerSupplierWorkflowByCaseID(int caseID)
        {
            return _casePatientTreatmentWorkflowRepository.GetCasePatientReferrerSupplierWorkflowByCaseID(caseID);
        }

        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCases(string searchText, int skip, int take)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCases(searchText ,skip, take);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesCount(string searchText)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCasesCount(searchText);
        //}

        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesActive(string searchText,int skip, int take)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCasesActive(searchText, skip, take);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesActiveCount(string searchText)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCasesActiveCount(searchText);
        //}

        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesInActive(string searchText, int skip, int take)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCasesInActive(searchText,skip, take);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesInActiveCount(string searchText)
        //{
        //    return _casePatientTreatmentWorkflowRepository.GetCasePatientTreatmentWorkflowAllCasesInActiveCount(searchText);
        //}


    }
}