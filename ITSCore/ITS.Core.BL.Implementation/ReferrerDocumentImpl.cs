using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;


namespace ITS.Core.BL.Implementation
{
    public class ReferrerDocumentImpl : IReferrerDocument
    {
        private readonly IReferrerDocumentRepository _referrerDocumentRepository;

        public ReferrerDocumentImpl(IReferrerDocumentRepository referrerDocumentRepository)
        {
            _referrerDocumentRepository = referrerDocumentRepository;
        }

        public int AddReferrerDocument(ReferrerDocument referrerDocument)
        {
            return _referrerDocumentRepository.AddReferrerDocument(referrerDocument);
        }

        public int AddReferrerDocumentCustom(ReferrerDocument referrerDocument)
        {
            return _referrerDocumentRepository.AddReferrerDocumentCustom(referrerDocument);
        }

        public int UpdateReferrerDocument(ReferrerDocument referrerDocument)
        {
            return _referrerDocumentRepository.UpdateReferrerDocument(referrerDocument);
        }

        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDAndDocumentTypeID(int referrerID, int documentTypeID)
        {
            return _referrerDocumentRepository.GetReferrerDocumentsByReferrerIDAndDocumentTypeID(referrerID, documentTypeID);
        }

        public int AddReferralDocument(ReferrerDocument referrerDocument)
        {
            referrerDocument.DocumentTypeID = 5;
            return _referrerDocumentRepository.AddReferrerDocument(referrerDocument);
        }
        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(int referrerID, int documentTypeID, int ReferrerProjectTreatmentID)
        {
            return _referrerDocumentRepository.GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID(referrerID, documentTypeID, ReferrerProjectTreatmentID).ToList();
        }

        public IEnumerable<ReferrerDocument> GetReferrerDocumentsByCaseId(int CaseId,int DocumentTypeID)
        {
            return _referrerDocumentRepository.GetReferrerDocumentsByCaseId(CaseId, DocumentTypeID).ToList();
        }

        public IEnumerable<ReferrerDocumentType> GetReferrerDocumentType()
        {
            return _referrerDocumentRepository.GetReferrerDocumentType();
        }
      
    }
}
