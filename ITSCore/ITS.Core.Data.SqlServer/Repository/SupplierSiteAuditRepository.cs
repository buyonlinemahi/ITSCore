


using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#region Comment
/*
 Page Name: SupplierSiteAuditRepository.cs                      
 Latest Version:  1.0
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 12-24-2012
  Version : 1.0
  Description : Add following Interfaces For SupplierSiteAudit
 
 * GetSupplierSiteAuditBySupplierDocumentID
 * GetSupplierSiteAuditBySupplierID
 * GetSupplierSiteAuditByUserID
 * GetSupplierSiteAuditBySupplierSiteAuditID
 * UpdateSupplierSiteAuditBySupplierSiteAuditID
 * AddSupplierSiteAudit
 * DeleteSupplierSiteAuditBySupplierSiteAuditID
===================================================================================

*/
#endregion
namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierSiteAuditRepository : BaseRepository<SupplierSiteAudit, ITSDBContext>, ISupplierSiteAuditRepository
    {
        public SupplierSiteAuditRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierDocumentID(int supplierDocumentID)
        {
            SqlParameter _supplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierDocumentID);
            return Context.Database.SqlQuery<SupplierSiteAudit>(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.GetSupplierSiteAuditBySupplierDocumentID, _supplierDocumentID);

        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditBySupplierID(int supplierID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierSiteAudit>(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.GetSupplierSiteAuditBySupplierID, _supplierID);

        }

        public IEnumerable<SupplierSiteAudit> GetSupplierSiteAuditByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<SupplierSiteAudit>(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.GetSupplierSiteAuditByUserID, _userID);

        }

        public SupplierSiteAudit GetSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID)
        {
            SqlParameter _supplierSiteAuditID = new SqlParameter("@SupplierSiteAuditID ", supplierSiteAuditID);
            return Context.Database.SqlQuery<SupplierSiteAudit>(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.GetSupplierSiteAuditBySupplierSiteAuditID, _supplierSiteAuditID).SingleOrDefault<SupplierSiteAudit>();

        }

        public int UpdateSupplierSiteAuditBySupplierSiteAuditID(SupplierSiteAudit supplierSiteAudit)
        {
            SqlParameter SupplierSiteAuditID = new SqlParameter("@SupplierSiteAuditID ", supplierSiteAudit.SupplierSiteAuditID);
            SqlParameter AuditNotes = new SqlParameter("@AuditNotes ", supplierSiteAudit.AuditNotes);
            SqlParameter AuditDate = new SqlParameter("@AuditDate ", supplierSiteAudit.AuditDate);
            SqlParameter AuditPass = new SqlParameter("@AuditPass ", supplierSiteAudit.AuditPass);
            SqlParameter UserID = new SqlParameter("@UserID ", supplierSiteAudit.UserID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID ", supplierSiteAudit.SupplierDocumentID.HasValue ? (object)supplierSiteAudit.SupplierDocumentID.Value : System.DBNull.Value);
            SqlParameter SupplierID = new SqlParameter("@SupplierID ", supplierSiteAudit.SupplierID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.UpdateSupplierSiteAuditBySupplierSiteAuditID, SupplierSiteAuditID,AuditNotes,AuditDate,AuditPass,UserID,SupplierDocumentID,SupplierID);
    
        }

        public int AddSupplierSiteAudit(SupplierSiteAudit supplierSiteAudit)
        {
           
            SqlParameter AuditNotes = new SqlParameter("@AuditNotes ", supplierSiteAudit.AuditNotes);
            SqlParameter AuditDate = new SqlParameter("@AuditDate ", supplierSiteAudit.AuditDate);
            SqlParameter AuditPass = new SqlParameter("@AuditPass ", supplierSiteAudit.AuditPass);
            SqlParameter UserID = new SqlParameter("@UserID ", supplierSiteAudit.UserID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID ", supplierSiteAudit.SupplierDocumentID.HasValue ? (object)supplierSiteAudit.SupplierDocumentID.Value : System.DBNull.Value);
            SqlParameter SupplierID = new SqlParameter("@SupplierID ", supplierSiteAudit.SupplierID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.AddSupplierSiteAudit,AuditNotes,AuditDate,AuditPass,UserID,SupplierDocumentID,SupplierID).SingleOrDefault();

        }

        public int DeleteSupplierSiteAuditBySupplierSiteAuditID(int supplierSiteAuditID)
        {
            SqlParameter _supplierSiteAuditID = new SqlParameter("@SupplierSiteAuditID", supplierSiteAuditID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierSiteAuditRepositoryProcedure.DeleteSupplierSiteAuditBySupplierSiteAuditID, _supplierSiteAuditID);

        }
    }
}