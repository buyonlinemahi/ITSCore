using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    
    
    public class CaseContactImpl : ICaseContact
    {
        private readonly ICaseContactRepository _caseContactRepository;

        public CaseContactImpl(ICaseContactRepository caseContactRepository)
        {
            _caseContactRepository = caseContactRepository;
        }

        public int AddCaseContact(CaseContact caseContact)
        {
            return _caseContactRepository.AddCaseContact(caseContact);
        }

        public IEnumerable<CaseContact> GetCaseContactsByCaseID(int caseID)
        {
            return _caseContactRepository.GetCaseContactsByCaseID(caseID);
        }

        public int UpdateCaseContactByCaseID(CaseContact caseContact)
        {
            return _caseContactRepository.UpdateCaseContactByCaseID(caseContact);
        }

        public void DeleteCaseContactByID(int _caseContactID)
        {
            _caseContactRepository.DeleteCaseContactByID(_caseContactID);
        }
    }
}
