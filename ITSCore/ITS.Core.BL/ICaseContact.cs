using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseContact
    {
        int AddCaseContact(CaseContact caseContact);
        IEnumerable<CaseContact> GetCaseContactsByCaseID(int caseID);
        int UpdateCaseContactByCaseID(CaseContact caseContact);

        void DeleteCaseContactByID(int _caseContactID);
    }
}
