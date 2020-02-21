using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseDocumentRepository : IBaseRepository<CaseDocument>
    {
        int AddCaseDocument(CaseDocument caseDocument);
        CaseDocument GetCaseDocumentByCaseIDAndDocumentTypeID(int caseID, int documentTypeID);
        int UpdateCaseDocumentByCaseIDAndDocumentTypeID(CaseDocument caseDocument);
        IEnumerable<CaseDocumentUser> GetCaseDocumentUserByCaseID(int caseID);
        IEnumerable<CaseDocumentUser> GetCaseDocumentForSupplierUserByCaseID(int CaseID);
        CaseDocument GetFinalUploadByCaseID(int caseID, int documentTypeID);
        int UpdateCaseAndReferrerDocumentByCaseID(CaseDocumentUser caseDocumentUser);
        IEnumerable<CaseDocumentUser> GetCaseDocumentForReferrerUserByCaseID(int CaseID);
    }
}
