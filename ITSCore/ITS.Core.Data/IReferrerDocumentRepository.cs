using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.Data
{
    public interface IReferrerDocumentRepository : IBaseRepository<ReferrerDocument>
    {

        int AddReferrerDocument(ReferrerDocument referrerDocument);
        int AddReferrerDocumentCustom(ReferrerDocument referrerDocument);
        int UpdateReferrerDocument(ReferrerDocument referrerDocument);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDAndDocumentTypeID(int referrerID, int documentTypeID);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(int referrerID, int documentTypeID, int ReferrerProjectTreatmentID);
        IEnumerable<ReferrerDocument> GetReferrerDocumentsByCaseId(int CaseId, int DocumentTypeID);
        IEnumerable<ReferrerDocumentType> GetReferrerDocumentType();
    }
}
