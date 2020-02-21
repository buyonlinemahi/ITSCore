using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseNote
    {
        int AddCaseNote(CaseNote caseNote);
        IEnumerable<CaseNoteUser> GetCaseNotesByCaseID(int caseID);
        CaseNote GetCaseNoteByCaseIDAndWorkflowID(int caseID, int workflowID);
    }
}
