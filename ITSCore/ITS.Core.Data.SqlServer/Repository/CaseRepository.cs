using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#region Comment
/*Latest Version : 1.2

    * Author : Robin Singh
    * Reason :-Create CaseRepository    
    * Created on 01-03-2013
 
    * Modified By : Pardeep Kumar
    * Description : Added new Method UpdateCaseIsTreatmentRequired
    * Date        : 29-06-2013 
    * Version     : 1.2 

*/
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseRepository : BaseRepository<Case, ITSDBContext>, ICaseRepository
    {
        public CaseRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCase(Case caseObj)
        {
            SqlParameter[] sqlparam ={
            new SqlParameter("@PatientID", caseObj.PatientID)
            ,new SqlParameter("@ReferrerID", caseObj.ReferrerID)
            ,new SqlParameter("@ReferrerProjectID", caseObj.ReferrerProjectID)
            ,new SqlParameter("@ReferrerProjectTreatmentID", caseObj.ReferrerProjectTreatmentID)
            ,new SqlParameter("@TreatmentTypeID", caseObj.TreatmentTypeID)
            ,new SqlParameter("@CaseReferrerReferenceNumber",  (object)caseObj.CaseReferrerReferenceNumber ?? DBNull.Value)
            ,new SqlParameter("@CaseSpecialInstruction", (object)caseObj.CaseSpecialInstruction ?? DBNull.Value)
            ,new SqlParameter("@CaseReferrerDueDate", caseObj.CaseReferrerDueDate)
            ,new SqlParameter("@WorkflowID", caseObj.WorkflowID)
            ,new SqlParameter("@IsTriage", caseObj.IsTriage)
            ,new SqlParameter("@InjuryType",  !string.IsNullOrEmpty(caseObj.InjuryType) ? (object)  caseObj.InjuryType : System.DBNull.Value)
            ,new SqlParameter("@SendInvoiceTo", caseObj.SendInvoiceTo)
            ,new SqlParameter("@SendInvoiceName", caseObj.SendInvoiceName)
            ,new SqlParameter("@SendInvoiceEmail", caseObj.SendInvoiceEmail)
            ,new SqlParameter("@ReferrerAssignedUser", caseObj.ReferrerAssignedUser)
            ,new SqlParameter("@SupplierAssignedUser", caseObj.SupplierAssignedUser)
            ,new SqlParameter("@InnovateNote", !string.IsNullOrEmpty(caseObj.InnovateNote) ? (object) caseObj.InnovateNote : System.DBNull.Value)
            ,new SqlParameter("@OfficeLocationID", (object)caseObj.OfficeLocationID ?? DBNull.Value)            
            ,new SqlParameter("@EmployeeDetailID", (object)caseObj.EmployeeDetailID?? DBNull.Value)
            ,new SqlParameter("@DrugTestID", (object)caseObj.DrugTestID?? DBNull.Value)
            ,new SqlParameter("@JobDemandID", (object)caseObj.JobDemandID?? DBNull.Value)
            ,new SqlParameter("@IsNewPolicyTypeID", (object)caseObj.IsNewPolicyTypeID?? DBNull.Value)
            ,new SqlParameter("@NewPolicyReferenceNumber", (object)caseObj.NewPolicyReferenceNumber)
        };
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseRepositoryProcedure.Add_Case, sqlparam).SingleOrDefault();

        }

        public int UpdateCaseWorkflowByCaseID(int caseID, int workflowID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _WorkflowID = new SqlParameter("@WorkflowID", workflowID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseWorkflowByCaseID, _CaseID, _WorkflowID);
        }

        public int GetReferrerProjectTreatmentDocumentSetup(int caseID, int AssessmentServiceID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", AssessmentServiceID);
            return Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetReferrerProjectTreatmentDocumentSetup, _CaseID, _AssessmentServiceID).SingleOrDefault();
        }
        public int GetCaseAssessmentCustomsByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetCaseAssessmentCustomsByCaseID, _CaseID).SingleOrDefault();
        }

        public IntialAssessmentReportDetail GetIntialAssessmentReportDetailsByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<IntialAssessmentReportDetail>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetIntialAssessmentReportDetailsByCaseID, _CaseID).SingleOrDefault<IntialAssessmentReportDetail>();
        }

        public IntialAssessmentReportDetail GetInitialReviewAssessmentByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<IntialAssessmentReportDetail>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetInitialReviewAssessmentByCaseID, _CaseID).SingleOrDefault<IntialAssessmentReportDetail>();
        }
        public EvaluateDelegatedAuthorisationCost GetEvaluateDelegatedAuthorisationCost(int caseID, int assessmentTypeID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _assessmentTypeID = new SqlParameter("@AssessmentTypeID", assessmentTypeID);
            return Context.Database.SqlQuery<EvaluateDelegatedAuthorisationCost>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetEvaluateDelegatedAuthorisationCost, _caseID, _assessmentTypeID).SingleOrDefault();
        }

        public int UpdateCaseWorkflowCustomByCaseID(int caseID, int userID, int workflowID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            SqlParameter _WorkflowID = new SqlParameter("@WorkflowID", workflowID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseWorkflowCustomByCaseID, _CaseID, _UserID, _WorkflowID);
        }



        public int UpdateCaseWorkflowByCaseIDStoppedCase(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseWorkflowByCaseIDStoppedCase, _CaseID);
        }

        public int UpdateCaseByCaseID(Case caseObj)
        {
            SqlParameter[] sqlparam ={
            new SqlParameter("@CaseID", caseObj.CaseID)
            ,new SqlParameter("@PatientID", caseObj.PatientID)
            ,new SqlParameter("@ReferrerID", caseObj.ReferrerID)
            ,new SqlParameter("@ReferrerProjectID", caseObj.ReferrerProjectID)
            ,new SqlParameter("@ReferrerProjectTreatmentID", caseObj.ReferrerProjectTreatmentID)
            ,new SqlParameter("@TreatmentTypeID", caseObj.TreatmentTypeID)
            ,new SqlParameter("@CaseReferrerReferenceNumber", (object)caseObj.CaseReferrerReferenceNumber ?? DBNull.Value)
            ,new SqlParameter("@CaseSpecialInstruction", (object)caseObj.CaseSpecialInstruction ?? DBNull.Value)
            ,new SqlParameter("@CaseReferrerDueDate", caseObj.CaseReferrerDueDate)
            ,new SqlParameter("@WorkflowID", caseObj.WorkflowID)
            ,new SqlParameter("@IsTriage", caseObj.IsTriage)
            ,new SqlParameter("@InjuryType",  !string.IsNullOrEmpty(caseObj.InjuryType) ? (object)  caseObj.InjuryType : System.DBNull.Value)
            ,new SqlParameter("@SendInvoiceTo", caseObj.SendInvoiceTo)
            ,new SqlParameter("@SendInvoiceName", caseObj.SendInvoiceName)
            ,new SqlParameter("@SendInvoiceEmail", caseObj.SendInvoiceEmail)
            ,new SqlParameter("@ReferrerAssignedUser", caseObj.ReferrerAssignedUser)
            ,new SqlParameter("@SupplierAssignedUser", caseObj.SupplierAssignedUser)
            ,new SqlParameter("@InnovateNote", !string.IsNullOrEmpty(caseObj.InnovateNote) ? (object) caseObj.InnovateNote : System.DBNull.Value)
            ,new SqlParameter("@OfficeLocationID", (object)caseObj.OfficeLocationID ?? DBNull.Value)            
            ,new SqlParameter("@EmployeeDetailID", (object)caseObj.EmployeeDetailID?? DBNull.Value)
            ,new SqlParameter("@DrugTestID", (object)caseObj.DrugTestID?? DBNull.Value)
            ,new SqlParameter("@JobDemandID", (object)caseObj.JobDemandID?? DBNull.Value)
            ,new SqlParameter("@IsNewPolicyTypeID", (object)caseObj.IsNewPolicyTypeID?? DBNull.Value)
            ,new SqlParameter("@NewPolicyReferenceNumber", (object)caseObj.NewPolicyReferenceNumber)
        };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.Update_CaseByCaseID, sqlparam);
        }

        public int DeleteCaseByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.Delete_CaseByCaseID, _CaseID);
        }

        public Case GetCaseByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<Case>(Global.StoredProcedureConst.CaseRepositoryProcedure.Get_CaseByCaseID, _CaseID).SingleOrDefault<Case>();

        }

        public Case GetCaseByPatientID(int PatientID)
        {
            SqlParameter _PatientID = new SqlParameter("@PatientID", PatientID);
            return Context.Database.SqlQuery<Case>(Global.StoredProcedureConst.CaseRepositoryProcedure.Get_CaseByPatientID, _PatientID).SingleOrDefault<Case>();

        }

        public IEnumerable<Case> GetCaseByLikeCaseNumber(string caseNumber)
        {
            SqlParameter _CaseNumber = new SqlParameter("@CaseNumber", caseNumber);
            return Context.Database.SqlQuery<Case>(Global.StoredProcedureConst.CaseRepositoryProcedure.Get_CaseByLikeCaseNumber, _CaseNumber);
        }

        public IEnumerable<Case> GetReferrerCasesByWorkflowID(int workflowID, int referrerID)
        {
            SqlParameter _workflowID = new SqlParameter("@WorkflowID", workflowID);
            SqlParameter _referrerID = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<Case>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetReferrerCasesByWorkflowID, _workflowID, _referrerID);
        }

        public IEnumerable<Case> GetCasesByWorkFlowID(int workflowID)
        {
            SqlParameter _workflowID = new SqlParameter("@WorkflowID", workflowID);
            return Context.Database.SqlQuery<Case>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetCasesByWorkFlowID, _workflowID);
        }

        public int UpdateCaseSupplier(int caseID, int supplierID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseSupplier, _CaseID, _SupplierID);
        }

        public IEnumerable<SupplierCasePatient> GetSupplierCasesAndPatientByWorkflowID(int supplierID, int workflowID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            SqlParameter _workflowID = new SqlParameter("@WorkflowID", workflowID);

            return Context.Database.SqlQuery<SupplierCasePatient>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetSupplierCasesAndPatientByWorkflowID, _supplierID, _workflowID);
        }

        public int UpdateCasePatientContactDateByCaseID(int caseID, DateTime patientContactDate, int? supplierAssignedUser, string innovateNote)
        {
            return
                Context.Database.ExecuteSqlCommand(
                    Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCasePatientContactDateByCaseID,
                    new SqlParameter("@CaseID", caseID),
                    new SqlParameter("@PatientContactDate", patientContactDate),
                    new SqlParameter("@SupplierAssignedUser", supplierAssignedUser != null ? supplierAssignedUser.Value : 0),
                    new SqlParameter("@InnovateNote", innovateNote != null ? innovateNote : DBNull.Value.ToString())
                    );
        }

        public int UpdateCaseIsTreatmentRequired(int caseID, bool isTreatmentRequired)
        {
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseIsTreatmentRequired, new SqlParameter("@IsTreatmentRequired", isTreatmentRequired)
            , new SqlParameter("@CaseID", caseID));
        }


        public int UpdateCaseInvoiceDate(DateTime invoiceDate, int caseID)
        {
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.UpdateCaseInvoiceDate, new SqlParameter("@InvoiceDate", invoiceDate)
           , new SqlParameter("@CaseID", caseID));
        }
        
        public IEnumerable<CasePatientContactAttempt> GetUnsuccessfulContactDate(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientContactAttempt>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetUnsuccessfulContactDate, _caseID);
        }

        public IEnumerable<CasePatientContactAttempt> GetPatientContactDate(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientContactAttempt>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetPatientContactDate, _caseID);
        }

        public IEnumerable<BLCaseReferrerAssignedUser> GetCaseReferrerAssignedUsersByCaseID(int CaseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", CaseID);            
            return Context.Database.SqlQuery<BLCaseReferrerAssignedUser>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetCaseReferrerAssignedUsersByCaseID, _caseID).ToList();
        }

        public int AddCaseReferrerAssignedUser(CaseReferrerAssignedUser _CaseReferrerAssignedUser)
        {
            SqlParameter[] param = {
                    new SqlParameter("@CaseID", _CaseReferrerAssignedUser.CaseID),
                    new SqlParameter("@UserID", _CaseReferrerAssignedUser.UserID)
                };

            var res = Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseRepositoryProcedure.AddCaseReferrerAssignedUser, param).FirstOrDefault();            
            
            return Int32.Parse(res.ToString());
        }

        public int DeleteCaseReferrerAssignedUserByID(int id)
        {
            SqlParameter[] param = {
                    new SqlParameter("@CaseReferrerAssignedUserID", id)
                };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseRepositoryProcedure.DeleteCaseReferrerAssignedUserByID, param);
        }
    }
}
