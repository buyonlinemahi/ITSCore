using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseNoteRepository : IBaseRepository<CaseNote>
    {
        int AddCaseNote(CaseNote caseNote);
        IEnumerable<CaseNoteUser> GetCaseNotesByCaseID(int caseID);
        CaseNote GetCaseNoteByCaseIDAndWorkflowID(int _caseID, int _workflowID);
    }
}
