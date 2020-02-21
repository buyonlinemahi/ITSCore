using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class CaseNoteImpl : ICaseNote
    {

        private readonly ICaseNoteRepository _caseNote;

        public CaseNoteImpl(ICaseNoteRepository caseNote)
        {
            _caseNote = caseNote;
        }

        public int AddCaseNote(CaseNote caseNote)
        {
            return _caseNote.AddCaseNote(caseNote);
        }

        public IEnumerable<CaseNoteUser> GetCaseNotesByCaseID(int caseID)
        {
            return _caseNote.GetCaseNotesByCaseID(caseID);
        }

        public CaseNote GetCaseNoteByCaseIDAndWorkflowID(int caseID, int workflowID)
        {
            return _caseNote.GetCaseNoteByCaseIDAndWorkflowID(caseID, workflowID);
        }
    }
}