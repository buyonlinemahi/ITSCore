using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICaseDocument
    {
        int AddCaseDocument(CaseDocument caseDocument);
        CaseDocument GetTriageCaseDocumentByCaseID(int caseID);
        CaseDocument GetReferralCaseDocumentByCaseID(int caseID);
        int UpdateTriageCaseDocumentByCaseID(CaseDocument caseDocument);
        IEnumerable<CaseDocumentUser> GetCaseDocumentUserByCaseID(int caseID);
        IEnumerable<CaseDocumentUser> GetCaseDocumentForSupplierUserByCaseID(int caseID);        
        CaseDocument GetFinalUploadByCaseID(int caseID, int documentTypeID);
        int UpdateCaseAndReferrerDocumentByCaseID(CaseDocumentUser caseDocumnetUser);
        IEnumerable<CaseDocumentUser> GetCaseDocumentForReferrerUserByCaseID(int caseID);
    }
}
