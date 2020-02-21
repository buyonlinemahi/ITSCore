using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseContactRepository : BaseRepository<CaseContact, ITSDBContext>, ICaseContactRepository
    {
        public CaseContactRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseContact(CaseContact caseContact)
        {
            return
                Convert.ToInt32(Context.Database.SqlQuery<decimal>(
                    Global.StoredProcedureConst.CaseContactRepositoryProcedures.AddCaseContact,
                    new SqlParameter("@CaseID", caseContact.CaseID),
                    new SqlParameter("@UserID", caseContact.UserID)).SingleOrDefault());
        }

        public IEnumerable<CaseContact> GetCaseContactsByCaseID(int caseID)
        {
            return
                Context.Database.SqlQuery<CaseContact>(
                    Global.StoredProcedureConst.CaseContactRepositoryProcedures.GetCaseContactsByCaseID,
                    new SqlParameter("@CaseID", caseID));
        }
        public int UpdateCaseContactByCaseID(CaseContact caseContact)
        {
            return
                Convert.ToInt32(Context.Database.SqlQuery<decimal>(
                    Global.StoredProcedureConst.CaseContactRepositoryProcedures.UpdateCaseContactByCaseID,
                    new SqlParameter("@CaseID", caseContact.CaseID),
                    new SqlParameter("@UserID", caseContact.UserID)).SingleOrDefault());
        }

        public void DeleteCaseContactByID(int _caseContactID)
        {
            int res = Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseContactRepositoryProcedures.DeleteCaseContactByID, new SqlParameter("@CaseContactID", _caseContactID));
        }
 
    }
}
