using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseDocumentRepository : BaseRepository<CaseDocument, ITSDBContext>, ICaseDocumentRepository
    {
        public CaseDocumentRepository(IContextFactory<ITSDBContext> contextFactory)
            : base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddCaseDocument(CaseDocument caseDocument)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseDocument.CaseID);
            SqlParameter _documentTypeID = new SqlParameter("@DocumentTypeID", caseDocument.DocumentTypeID);
            SqlParameter _uploadDate = new SqlParameter("@UploadDate", caseDocument.UploadDate);
            SqlParameter _documentName = new SqlParameter("@DocumentName", caseDocument.DocumentName);
            SqlParameter _uploadPath = new SqlParameter("@UploadPath", caseDocument.UploadPath);
            SqlParameter _userID = new SqlParameter("@UserID", caseDocument.UserID ?? null);
            return Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.AddCaseDocument, _caseID, _documentTypeID, _uploadDate, _documentName, _uploadPath, _userID).FirstOrDefault();
        }

        public CaseDocument GetCaseDocumentByCaseIDAndDocumentTypeID(int caseID, int documentTypeID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _documentTypeID = new SqlParameter("@DocumentTypeID", documentTypeID);

            return Context.Database.SqlQuery<CaseDocument>(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.GetCaseDocumentByCaseIDAndDocumentTypeID, _caseID, _documentTypeID).SingleOrDefault();
        }

        public int UpdateCaseDocumentByCaseIDAndDocumentTypeID(CaseDocument caseDocument)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseDocument.CaseID);
            SqlParameter _documentTypeID = new SqlParameter("@DocumentTypeID", caseDocument.DocumentTypeID);
            SqlParameter _uploadDate = new SqlParameter("@UploadDate", caseDocument.UploadDate);
            SqlParameter _documentName = new SqlParameter("@DocumentName", caseDocument.DocumentName);
            SqlParameter _uploadPath = new SqlParameter("@UploadPath", caseDocument.UploadPath);
            SqlParameter _userID = new SqlParameter("@UserID", caseDocument.UserID ?? null);
           return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.UpdateCaseDocumentByCaseIDAndDocumentTypeID, _caseID, _documentTypeID, _uploadDate, _documentName, _uploadPath, _userID);
        }


        public IEnumerable<CaseDocumentUser> GetCaseDocumentUserByCaseID(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);

            return Context.Database.SqlQuery<CaseDocumentUser>(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.GetCaseDocumentUserByCaseID,_caseID);
        }

        public IEnumerable<CaseDocumentUser> GetCaseDocumentForSupplierUserByCaseID(int CaseID)
        {
            SqlParameter paramCaseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<CaseDocumentUser>(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.GetCaseDocumentForSupplierUserByCaseID, paramCaseID);
        }
        public IEnumerable<CaseDocumentUser> GetCaseDocumentForReferrerUserByCaseID(int CaseID)
        {
            SqlParameter paramCaseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<CaseDocumentUser>(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.GetCaseDocumentForReferrerUserByCaseID, paramCaseID);
        }

        public CaseDocument GetFinalUploadByCaseID(int caseID, int documentTypeID)
        {
            return Context.Database.SqlQuery<CaseDocument>(Global.StoredProcedureConst.CaseRepositoryProcedure.GetFinalUploadByCaseID, new SqlParameter("@caseID", caseID), new SqlParameter("@DocumentTypeID", documentTypeID)).SingleOrDefault();
        }

        public int UpdateCaseAndReferrerDocumentByCaseID(CaseDocumentUser caseDocumetnUser)
        {
            /*SqlParameter _caseID = new SqlParameter("@CaseID", caseDocumetnUser.CaseID);
            SqlParameter _documentTypeID = new SqlParameter("@DocumentTypeID", caseDocumetnUser.DocumentTypeID);
            SqlParameter _uploadDate = new SqlParameter("@UploadDate", caseDocumetnUser.UploadDate);
            */
            SqlParameter _CaseDocumentID = new SqlParameter("@CaseDocumentID", caseDocumetnUser.CaseDocumentID);
            SqlParameter _ReferrerDocumentID = new SqlParameter("@ReferrerDocumentID", caseDocumetnUser.ReferrerDocumentID);
            SqlParameter _SupplierCheck = new SqlParameter("@SupplierCheck", caseDocumetnUser.SupplierCheck);
            SqlParameter _ReferrerCheck = new SqlParameter("@ReferrerCheck", caseDocumetnUser.ReferrerCheck);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseDocumentRepositoryProcedures.UpdateCaseAndReferrerDocumentByCaseID, _CaseDocumentID , _ReferrerDocumentID , _SupplierCheck, _ReferrerCheck );
        }
    }
}
