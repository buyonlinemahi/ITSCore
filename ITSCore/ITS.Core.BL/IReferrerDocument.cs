using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL
{
    public interface IReferrerDocument
    {
        int AddReferrerDocument(ReferrerDocument referrerDocument);
        int AddReferrerDocumentCustom(ReferrerDocument referrerDocument);
        int UpdateReferrerDocument(ReferrerDocument referrerDocument);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDAndDocumentTypeID(int referrerID, int documentTypeID);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(int referrerID, int documentTypeID, int ReferrerProjectTreatmentID);
        int AddReferralDocument(ReferrerDocument referrerDocument);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByCaseId(int CaseId, int DocumentTypeID);
        IEnumerable<ReferrerDocumentType> GetReferrerDocumentType();
    }
}
