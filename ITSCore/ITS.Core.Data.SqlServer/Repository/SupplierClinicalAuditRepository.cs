using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  SupplierClinicalAuditRepository.cs                      
 Latest Version:  1.1                                                                                                
 History:                                                                                              
   1.0 – 12/29/2012 Vishal 
 * ==============================================================================================
  Description : Add CURD to SupplierClinicalAuditRepository
 * 
 * 
 * Modified by    : Pardeep Kumar
 * Date           : 11-Feb-2013
 * Latest version : 1.1
 * Description    : Updated the parameters of method AddSupplierClinicalAudit as ReferrerID is removed from the table SupplierClinicalAudit
 *                : Updated the parameters of method UpdateSupplierClinicalAuditBySupplierClinicalAuditID as ReferrerID is removed from the table SupplierClinicalAudit
 */

namespace ITS.Core.Data.SqlServer.Repository
{

    public class SupplierClinicalAuditRepository : BaseRepository<SupplierClinicalAudit, ITSDBContext>, ISupplierClinicalAuditRepository
    {
        public SupplierClinicalAuditRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddSupplierClinicalAudit(SupplierClinicalAudit supplierClinicalAudit)
        {
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierClinicalAudit.SupplierID);
            SqlParameter AuditPass = new SqlParameter("@AuditPass", supplierClinicalAudit.AuditPass);
            SqlParameter UserID = new SqlParameter("@UserID", supplierClinicalAudit.UserID);
            SqlParameter AuditDate = new SqlParameter("@AuditDate", supplierClinicalAudit.AuditDate);
            SqlParameter CaseID = new SqlParameter("@CaseID", supplierClinicalAudit.CaseID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierClinicalAudit.SupplierDocumentID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.AddSupplierClinicalAudit, SupplierID, AuditPass, UserID, AuditDate, CaseID, SupplierDocumentID).SingleOrDefault();

        }
        public int AddSupplierDocumentCustom(SupplierDocument supplierDocument)
        {

            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", supplierDocument.DocumentTypeID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierDocument.SupplierID);
            SqlParameter _UserID = new SqlParameter("@UserID", supplierDocument.UserID);
            SqlParameter _UploadDate = new SqlParameter("@UploadDate", supplierDocument.UploadDate);
            SqlParameter _DocumentName = new SqlParameter("@DocumentName", supplierDocument.DocumentName);
            SqlParameter _UploadPath = new SqlParameter("@UploadPath", supplierDocument.UploadPath);
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", supplierDocument.ReferrerProjectTreatmentID);
            SqlParameter _CaseId = new SqlParameter("@ReferrerProjectTreatmentID", supplierDocument.CaseId);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.AddSupplierDocumentCustom, _DocumentTypeID, _SupplierID, _UserID, _UploadDate, _DocumentName, _UploadPath, _ReferrerProjectTreatmentID, _CaseId).SingleOrDefault();

        }
        public int UpdateSupplierClinicalAuditBySupplierClinicalAuditID(SupplierClinicalAudit supplierClinicalAudit)
        {
            SqlParameter SupplierClinicalAuditID = new SqlParameter("@SupplierClinicalAuditID", supplierClinicalAudit.SupplierClinicalAuditID);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierClinicalAudit.SupplierID);
            SqlParameter AuditPass = new SqlParameter("@AuditPass", supplierClinicalAudit.AuditPass);
            SqlParameter UserID = new SqlParameter("@UserID", supplierClinicalAudit.UserID);
            SqlParameter AuditDate = new SqlParameter("@AuditDate", supplierClinicalAudit.AuditDate);
            SqlParameter CaseID = new SqlParameter("@CaseID", supplierClinicalAudit.CaseID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierClinicalAudit.SupplierDocumentID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.UpdateSupplierClinicalAuditBySupplierClinicalAuditID, SupplierClinicalAuditID, SupplierID, AuditPass, UserID, AuditDate, CaseID, SupplierDocumentID);
        }

        public IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<SupplierClinicalAudit>(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.GetSupplierClinicalAuditByUserID, _userID);
        }

        public IEnumerable<SupplierClinicalAudit> GetSupplierClinicalAuditBySupplierID(int supplierID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierClinicalAudit>(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.GetSupplierClinicalAuditBySupplierID, _supplierID);
        }


        public int DeleteSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID)
        {
            SqlParameter _SupplierClinicalAuditID = new SqlParameter("@SupplierClinicalAuditID", supplierClinicalAuditID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.DeleteSupplierClinicalAuditBySupplierClinicalAuditID, _SupplierClinicalAuditID);
  
        }

        public SupplierClinicalAudit GetSupplierClinicalAuditBySupplierClinicalAuditID(int supplierClinicalAuditID)
        {
            SqlParameter _SupplierClinicalAuditID = new SqlParameter("@SupplierClinicalAuditID", supplierClinicalAuditID);
            return Context.Database.SqlQuery<SupplierClinicalAudit>(Global.StoredProcedureConst.SupplierClinicalAuditRepositoryProcedure.GetSupplierClinicalAuditBySupplierClinicalAuditID, _SupplierClinicalAuditID).SingleOrDefault();
        }
    }
}