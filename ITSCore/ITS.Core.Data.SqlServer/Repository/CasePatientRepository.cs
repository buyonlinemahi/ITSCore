using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CasePatientRepository : BaseRepository<CasePatient, ITSDBContext>, ICasePatientRepository
    {
        public CasePatientRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public CasePatient GetCasePatientByCaseIDAndWorkflowID(int caseID, int workFlowID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _WorkFlowID = new SqlParameter("@WorkflowID", workFlowID);
            return Context.Database.SqlQuery<CasePatient>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetCasePatientByCaseIDAndWorkflowID, _CaseID, _WorkFlowID).SingleOrDefault<CasePatient>();
        }

        public CasePatientTreatment GetPatientAndCaseByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientTreatment>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetPatientAndCaseByCaseID, _CaseID).SingleOrDefault<CasePatientTreatment>();
        }

        public IEnumerable<ReferrerSupplierCases> GetCaseSearchLikePatientName(string patientName)
        {
            SqlParameter _patientName = new SqlParameter("@PatientName", patientName);
            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetCaseSearchLikePatientName, _patientName);
        }

        public IEnumerable<ReferrerSupplierCases> GetCaseSearchLikeReferrerReferenceNumber(string referrerReferenceNumber)
        {
            SqlParameter _referrerReferenceNumber = new SqlParameter("@ReferrerReferenceNumber", referrerReferenceNumber);
            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetCaseSearchLikeReferrerReferenceNumber, _referrerReferenceNumber);
        }

        public IEnumerable<CasePatientSearch> GetCasePatientLikeCaseNumber(string caseNumber)
        {
            SqlParameter _CaseNumber = new SqlParameter("@CaseNumber", caseNumber);
            return Context.Database.SqlQuery<CasePatientSearch>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetCasePatientLikeCaseNumber, _CaseNumber);
        }

        public CasePatientReferrer GetCasePatientReferrerByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientReferrer>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetCasePatientReferrerByCaseID, _CaseID).SingleOrDefault<CasePatientReferrer>();
        }

        public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndReferrerID(string additionalParam, string patientName, int referrerID, int userID, int skip, int take)
        {
            SqlParameter AdditionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter PatientName = new SqlParameter("@PatientName", patientName);
            SqlParameter ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikePatientNameAndReferrerID, AdditionalParam, PatientName, ReferrerID, UserID, SkipParam, TakeParam);
        }

        public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikePatientNameAndSupplierID(string patientName, int supplierID,int userID, int skip, int take)
        {
            SqlParameter PatientName = new SqlParameter("@PatientName", patientName);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikePatientNameAndSupplierID, PatientName, SupplierID,UserID, SkipParam, TakeParam);
        }

        public int GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount(string patientName, int supplierID,int userID)
        {
            SqlParameter PatientName = new SqlParameter("@PatientName", patientName);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount, PatientName, SupplierID,UserID).SingleOrDefault();
        }

        public int GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount(string additionalParam,string patientName, int referrerID,int userID)
        {
            SqlParameter AdditionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter PatientName = new SqlParameter("@PatientName", patientName);
            SqlParameter ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount, AdditionalParam, PatientName, ReferrerID, UserID).FirstOrDefault();
        }

        public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID(string additionalParam,string referrerReferenceNumber, int referrerID,int userID, int skip, int take)
        {
            SqlParameter AdditionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter ReferrerReferenceNumber = new SqlParameter("@ReferrerReferenceNumber", referrerReferenceNumber);
            SqlParameter ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID, AdditionalParam, ReferrerReferenceNumber, ReferrerID, UserID, SkipParam, TakeParam);
        }

        public int GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount(string additionalParam, string referrerReferenceNumber, int referrerID,int userID)
        {
            SqlParameter AdditionalParam = new SqlParameter("@AdditionalParam", additionalParam);
            SqlParameter ReferrerReferenceNumber = new SqlParameter("@ReferrerReferenceNumber", referrerReferenceNumber);
            SqlParameter ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount,AdditionalParam, ReferrerReferenceNumber, ReferrerID,UserID).SingleOrDefault();
        }

        public IEnumerable<ReferrerSupplierCases> GetReferrerSupplierCaseLikeCaseNumberAndSupplierID(string caseNumber, int supplierID,int userID, int skip, int take)
        {
            SqlParameter CaseNumber = new SqlParameter("@CaseNumber", caseNumber);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikeCaseNumberAndSupplierID, CaseNumber, SupplierID, UserID, SkipParam, TakeParam);
        }

        public int GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount(string caseNumber, int supplierID,int userID)
        {
            SqlParameter CaseNumber = new SqlParameter("@CaseNumber", caseNumber);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount, CaseNumber, SupplierID, UserID).SingleOrDefault();
        }


        public ReportModels.PatientAndCase GetPatientAndCaseByCaseIDReports(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<ReportModels.PatientAndCase>(Global.StoredProcedureConst.CasePatientRepositoryProcedure.GetPatientAndCaseByCaseIDReports, _CaseID).SingleOrDefault<ReportModels.PatientAndCase>();
        }

    }
}