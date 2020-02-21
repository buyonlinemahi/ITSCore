using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{

    public class CaseNoteRepository : BaseRepository<CaseNote, ITSDBContext>, ICaseNoteRepository
    {
        public CaseNoteRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddCaseNote(CaseNote caseNote)
        {
            SqlParameter Note = new SqlParameter("@Note", caseNote.Note);
            SqlParameter CaseID = new SqlParameter("@CaseID", caseNote.CaseID);
            SqlParameter UserID = new SqlParameter("@UserID", caseNote.UserID);
            SqlParameter WorkflowID = new SqlParameter("@WorkflowID", caseNote.WorkflowID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseNoteRepositoryProcedure.AddCaseNote, Note, CaseID, UserID, WorkflowID);
        }

        public IEnumerable<CaseNoteUser> GetCaseNotesByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseNoteUser>(Global.StoredProcedureConst.CaseNoteRepositoryProcedure.GetCaseNotesByCaseID, CaseID);
        }

        public CaseNote GetCaseNoteByCaseIDAndWorkflowID(int _caseID, int _workflowID)
        {
            SqlParameter CaseID = new SqlParameter("@caseID", _caseID);
            SqlParameter WorkflowID = new SqlParameter("@workflowID", _workflowID);
            return Context.Database.SqlQuery<CaseNote>(Global.StoredProcedureConst.CaseNoteRepositoryProcedure.GetCaseNoteByCaseIDAndWorkflowID, CaseID, WorkflowID).SingleOrDefault();            
        }        
    }
}