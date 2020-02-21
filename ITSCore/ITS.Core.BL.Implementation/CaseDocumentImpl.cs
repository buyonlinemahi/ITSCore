using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{

    public class CaseDocumentImpl : ICaseDocument
    {

        private readonly ICaseDocumentRepository _caseDocumentRepository;

        public CaseDocumentImpl(ICaseDocumentRepository caseDocumentRepository)
        {
            _caseDocumentRepository = caseDocumentRepository;

        }

        public int AddCaseDocument(CaseDocument caseDocument)
        {
            return _caseDocumentRepository.AddCaseDocument(caseDocument);
        }

        public int UpdateTriageCaseDocumentByCaseID(CaseDocument caseDocument)
        {
            caseDocument.DocumentTypeID = Global.GlobalConst.DocumentType.Triage;
            return _caseDocumentRepository.UpdateCaseDocumentByCaseIDAndDocumentTypeID(caseDocument);
        }

        public CaseDocument GetTriageCaseDocumentByCaseID(int caseID)
        {
            int documentTypeID = Global.GlobalConst.DocumentType.Triage;
            return _caseDocumentRepository.GetCaseDocumentByCaseIDAndDocumentTypeID(caseID, documentTypeID);
        }

        public CaseDocument GetReferralCaseDocumentByCaseID(int caseID)
        {
            int documentTypeID = Global.GlobalConst.DocumentType.Referral;
            return _caseDocumentRepository.GetCaseDocumentByCaseIDAndDocumentTypeID(caseID, documentTypeID);
        }

        public IEnumerable<CaseDocumentUser> GetCaseDocumentUserByCaseID(int caseID)
        {
            return _caseDocumentRepository.GetCaseDocumentUserByCaseID(caseID);
        }

        public IEnumerable<CaseDocumentUser> GetCaseDocumentForSupplierUserByCaseID(int caseID)
        {
            return _caseDocumentRepository.GetCaseDocumentForSupplierUserByCaseID(caseID);
        }
        public IEnumerable<CaseDocumentUser> GetCaseDocumentForReferrerUserByCaseID(int caseID)
        {
            return _caseDocumentRepository.GetCaseDocumentForReferrerUserByCaseID(caseID);
        }

        public CaseDocument GetFinalUploadByCaseID(int caseID, int documentTypeID)
        {
            return _caseDocumentRepository.GetFinalUploadByCaseID(caseID, documentTypeID);
        }
        public int UpdateCaseAndReferrerDocumentByCaseID(CaseDocumentUser caseDocumentUser)
        {
            return _caseDocumentRepository.UpdateCaseAndReferrerDocumentByCaseID(caseDocumentUser);
        }
    }
}
