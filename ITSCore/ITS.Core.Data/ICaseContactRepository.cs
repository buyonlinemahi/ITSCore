using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseContactRepository : IBaseRepository<CaseContact>
    {
        int AddCaseContact(CaseContact caseContact);
        IEnumerable<CaseContact> GetCaseContactsByCaseID(int caseID);
        int UpdateCaseContactByCaseID(CaseContact caseContact);

        void DeleteCaseContactByID(int _caseContactID);
    }
}
