using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerDocumentRepository : BaseRepository<ReferrerDocument, ITSDBContext>, IReferrerDocumentRepository
    {
        public ReferrerDocumentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddReferrerDocument(ReferrerDocument referrerDocument)
        {
            SqlParameter[] _referrerDocument = { new SqlParameter("@ReferrerID", referrerDocument.ReferrerID),
                                        new SqlParameter("@DocumentTypeID", referrerDocument.DocumentTypeID),
                                        new SqlParameter("@UploadDate", referrerDocument.UploadDate),
                                        new SqlParameter("@UserID", referrerDocument.UserID),
                                        new SqlParameter("@UploadPath", referrerDocument.UploadPath),                                        
                                        new SqlParameter("@ReferrerDocumentTypeID", referrerDocument.ReferrerDocumentTypeID),
                                        new SqlParameter("@CaseID", referrerDocument.CaseID),                                        
                                        new SqlParameter("@DocumentDate", referrerDocument.DocumentDate),                                        
                                        new SqlParameter("@DocumentName", referrerDocument.DocumentName),  
                                        new SqlParameter("@SupplierCheck", referrerDocument.SupplierCheck),
                                        new SqlParameter("@ReferrerCheck",referrerDocument.ReferrerCheck)

                                       
                                       };
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.AddReferrerDocument, _referrerDocument).SingleOrDefault();
        }

        public int UpdateReferrerDocument(ReferrerDocument referrerDocument)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerDocument.ReferrerID);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", referrerDocument.DocumentTypeID);
            SqlParameter _UploadDate = new SqlParameter("@UploadDate", referrerDocument.UploadDate);
            SqlParameter _UserID = new SqlParameter("@UserID", referrerDocument.UserID);
            SqlParameter _UploadPath = new SqlParameter("@UploadPath", referrerDocument.UploadPath);
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerDocument.ReferrerProjectTreatmentID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.UpdateReferrerDocument, _ReferrerID, _DocumentTypeID, _UploadDate, _UserID, _UploadPath, _ReferrerProjectTreatmentID);
        }

        public int AddReferrerDocumentCustom(ReferrerDocument referrerDocument)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerDocument.ReferrerID);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", referrerDocument.DocumentTypeID);
            SqlParameter _UploadDate = new SqlParameter("@UploadDate", referrerDocument.UploadDate);
            SqlParameter _UserID = new SqlParameter("@UserID", referrerDocument.UserID);
            SqlParameter _UploadPath = new SqlParameter("@UploadPath", referrerDocument.UploadPath);
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerDocument.ReferrerProjectTreatmentID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.AddReferrerDocumentCustom, _ReferrerID, _DocumentTypeID, _UploadDate, _UserID, _UploadPath, _ReferrerProjectTreatmentID).SingleOrDefault();
        }

        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDAndDocumentTypeID(int referrerID, int documentTypeID)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", documentTypeID);

            return Context.Database.SqlQuery<ReferrerDocument>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.GetReferrerDocumentsByReferrerIDAndDocumentTypeID, _ReferrerID, _DocumentTypeID);
        }
        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(int referrerID, int documentTypeID, int referrerProjectTreatmentID)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", documentTypeID);
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);

            return Context.Database.SqlQuery<ReferrerDocument>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID, _ReferrerID, _DocumentTypeID, _ReferrerProjectTreatmentID);
        }
        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByCaseId(int CaseId, int DocumentTypeID)
        {
            SqlParameter _CaseId = new SqlParameter("@CaseID", CaseId);
            SqlParameter _DocumentTypeID = new SqlParameter("@DocumentTypeID", DocumentTypeID);
            return Context.Database.SqlQuery<ReferrerDocument>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.GetReferrerDocumentsByCaseId, _CaseId, _DocumentTypeID);
        }

        public IEnumerable<ReferrerDocumentType> GetReferrerDocumentType()
        {
            return Context.Database.SqlQuery<ReferrerDocumentType>(Global.StoredProcedureConst.ReferrerDocumentRepositoryProcedures.GetReferrerDocumentType).ToList();
        }
    }
}
