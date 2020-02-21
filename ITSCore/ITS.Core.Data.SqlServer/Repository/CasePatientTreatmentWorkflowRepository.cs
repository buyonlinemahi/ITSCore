
using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CasePatientTreatmentWorkflowRepository : BaseRepository<CasePatientTreatmentWorkflow, ITSDBContext>, ICasePatientTreatmentWorkflowRepository
    {
        public CasePatientTreatmentWorkflowRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePatientName(string additionalParam, string patientName, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter patientNameParam = new SqlParameter("@PatientName", patientName);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikePatientName, _additionalParam, patientNameParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikePatientNameCount(string additionalParam, string patientName)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter patientNameParam = new SqlParameter("@PatientName", patientName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikePatientNameCount, _additionalParam, patientNameParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeReferrerName(string additionalParam, string referrerName, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter referrerNameParam = new SqlParameter("@ReferrerName", referrerName);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeReferrerName, _additionalParam, referrerNameParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikeReferrerNameCount(string additionalParam, string referrerName)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter referrerNameParam = new SqlParameter("@ReferrerName", referrerName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeReferrerNameCount, _additionalParam, referrerNameParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseNumber(string additionalParam, string caseNumber, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter caseNumberParam = new SqlParameter("@CaseNumber", caseNumber);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeCaseNumber, _additionalParam, caseNumberParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikeCaseNumberCount(string additionalParam, string caseNumber)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter caseNumberParam = new SqlParameter("@CaseNumber", caseNumber);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeCaseNumberCount, _additionalParam, caseNumberParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber(string additionalParam, string referrerReferenceNumber, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter referrerReferenceNumberParam = new SqlParameter("@CaseReferrerReferenceNumber", referrerReferenceNumber);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber, _additionalParam, referrerReferenceNumberParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount(string additionalParam, string referrerReferenceNumber)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter referrerReferenceNumberParam = new SqlParameter("@CaseReferrerReferenceNumber", referrerReferenceNumber);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount, _additionalParam, referrerReferenceNumberParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName(string additionalParam, string treatmentCategoryName, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter treatmentCategoryNameParam = new SqlParameter("@TreatmentCategoryName", treatmentCategoryName);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName, _additionalParam, treatmentCategoryNameParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount(string additionalParam, string treatmentCategoryName)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter treatmentCategoryNameParam = new SqlParameter("@TreatmentCategoryName", treatmentCategoryName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount, _additionalParam, treatmentCategoryNameParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikeTreatmentTypeName(string additionalParam, string treatmentTypeName, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter treatmentTypeNameParam = new SqlParameter("@TreatmentTypeName", treatmentTypeName);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeTreatmentTypeName, _additionalParam, treatmentTypeNameParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount(string additionalParam, string treatmentTypeName)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter treatmentTypeNameParam = new SqlParameter("@TreatmentTypeName", treatmentTypeName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount, _additionalParam, treatmentTypeNameParam).SingleOrDefault();
        }

        public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowLikePostCode(string additionalParam, string postCode, int skip, int take)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter postCodeParam = new SqlParameter("@PostCode", postCode);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikePostCode, _additionalParam, postCodeParam, SkipParam, TakeParam);
        }

        public int GetCasePatientTreatmentWorkflowLikePostCodeCount(string additionalParam, string postCode)
        {
            SqlParameter _additionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter postCodeParam = new SqlParameter("@PostCode", postCode);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowLikePostCodeCount, _additionalParam, postCodeParam).SingleOrDefault();
        }

        public CasePatientReferrerSupplierWorkflow GetCasePatientReferrerSupplierWorkflowByCaseID(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientReferrerSupplierWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientReferrerSupplierWorkflowByCaseID, _caseID).SingleOrDefault();
        }


        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCases(string searchText, int skip, int take)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    SqlParameter SkipParam = new SqlParameter("@Skip", skip);
        //    SqlParameter TakeParam = new SqlParameter("@Take", take);
        //    return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCases, _searchText, SkipParam, TakeParam);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesCount(string searchText)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCasesCount, _searchText).SingleOrDefault();
        //}

        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesActive(string searchText, int skip, int take)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    SqlParameter SkipParam = new SqlParameter("@Skip", skip);
        //    SqlParameter TakeParam = new SqlParameter("@Take", take);
        //    return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCasesActive, _searchText, SkipParam, TakeParam);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesActiveCount(string searchText)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCasesActiveCount ,_searchText).SingleOrDefault();
        //}

        //public IEnumerable<CasePatientTreatmentWorkflow> GetCasePatientTreatmentWorkflowAllCasesInActive(string searchText, int skip, int take)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    SqlParameter SkipParam = new SqlParameter("@Skip", skip);
        //    SqlParameter TakeParam = new SqlParameter("@Take", take);
        //    return Context.Database.SqlQuery<CasePatientTreatmentWorkflow>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCasesInActive, _searchText, SkipParam, TakeParam);
        //}

        //public int GetCasePatientTreatmentWorkflowAllCasesInActiveCount(string searchText)
        //{
        //    SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
        //    return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientTreatmentWorkflowProcedure.GetCasePatientTreatmentWorkflowAllCasesInActiveCount, _searchText).SingleOrDefault();
        //}

    }
}
