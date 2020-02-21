using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  SupplierDocumentRepository.cs                      
 Latest Version:  1.1                                              
  Purpose:  Added a Method(DeleteSupplierDocumentBySupplierDocumentID) to delete the SupplierDocument.                                                        
  Revision History:                                        
                                                           
   1.0 – 12/15/2012 Manjit Singh 
 
   Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.1
 * Description : Added a Method(DeleteSupplierDocumentBySupplierDocumentID) to delete the SupplierDocument.
 
   Edited By : Anuj Batra
 * Date : 26-Feb-2013
 * Version : 1.2
 * Description : Added a Method(UpdateSupplierDocumentNameBySupplierDocumentID) to update the DocumentName.
 */


namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierDocumentRepository : BaseRepository<SupplierDocument, ITSDBContext>, ISupplierDocumentRepository
    {
        public SupplierDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddSupplierDocument(SupplierDocument supplierDocument)
        {

            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", supplierDocument.DocumentTypeID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierDocument.SupplierID);
            SqlParameter _UserID = new SqlParameter("@UserID", supplierDocument.UserID);
            SqlParameter _UploadDate = new SqlParameter("@UploadDate", supplierDocument.UploadDate);
            SqlParameter _DocumentName = new SqlParameter("@DocumentName", supplierDocument.DocumentName);
            SqlParameter _UploadPath = new SqlParameter("@UploadPath", supplierDocument.UploadPath);


            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.AddSupplierDocument, _DocumentTypeID, _SupplierID, _UserID, _UploadDate, _DocumentName, _UploadPath).SingleOrDefault();

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
            SqlParameter _CaseID = new SqlParameter("@CaseId", supplierDocument.CaseId);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.AddSupplierDocumentCustom, _DocumentTypeID, _SupplierID, _UserID, _UploadDate, _DocumentName, _UploadPath, _ReferrerProjectTreatmentID, _CaseID);

        }
         
        public int UpdateSupplierDocument(SupplierDocument supplierDocument)
        {
            SqlParameter _SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierDocument.SupplierDocumentID);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", supplierDocument.DocumentTypeID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierDocument.SupplierID);
            SqlParameter _UserID = new SqlParameter("@UserID", supplierDocument.UserID);
            SqlParameter _UploadDate = new SqlParameter("@UploadDate", supplierDocument.UploadDate);
            SqlParameter _DocumentName = new SqlParameter("@DocumentName", supplierDocument.DocumentName);
            SqlParameter _UploadPath = new SqlParameter("@UploadPath", supplierDocument.UploadPath);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.UpdateSupplierDocument, _SupplierDocumentID, _DocumentTypeID, _SupplierID, _UserID, _UploadDate, _DocumentName, _UploadPath);

        }

        public IEnumerable<SupplierDocumentUser> GetSupplierDocumentBySupplierIDAndDocumentTypeID(int supplierID, int documentTypeID)
        {
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", documentTypeID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierDocumentUser>(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.GetSupplierDocumentBySupplierIDAndDocumentTypeID, _DocumentTypeID, _SupplierID);
        }

        public IEnumerable<SupplierDocument> GetSupplierDocumentByCaseIdAndDocumentTypeId(int CaseId, int documentTypeID)
        {
            SqlParameter _CaseId = new SqlParameter("@CaseId", CaseId);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", documentTypeID);
            return Context.Database.SqlQuery<SupplierDocument>(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.GetSupplierDocumentByCaseIdAndDocumentTypeId, _CaseId, _DocumentTypeID);
        }
        
        public int DeleteSupplierDocumentBySupplierDocumentID(int supplierDocumentId)
        {
            SqlParameter _SupplierDocumentId = new SqlParameter("@SupplierDocumentID", supplierDocumentId);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.DeleteSupplierDocumentBySupplierDocumentID, _SupplierDocumentId);
        }


        public int UpdateSupplierDocumentNameBySupplierDocumentID(int supplierDocumentID, string documentName)
        {
            SqlParameter _SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierDocumentID);
            SqlParameter _DocumentName = new SqlParameter("@DocumentName", documentName);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.UpdateSupplierDocumentNameBySupplierDocumentID, _SupplierDocumentID, _DocumentName);

        }

        public IEnumerable<SupplierDocumentCustomReport> GetSupplierDocumentByCaseId(int CaseId)
        {
            SqlParameter _CaseId = new SqlParameter("@CaseId", CaseId);
            return Context.Database.SqlQuery<SupplierDocumentCustomReport>(Global.StoredProcedureConst.SupplierDocumentRepositoryProcedure.GetSupplierDocumentByCaseId, _CaseId);
        }
        
    }

}
