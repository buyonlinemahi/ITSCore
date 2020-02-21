using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class PasswordHistoryRepository : BaseRepository<PasswordHistory, ITSDBContext>, IPasswordHistoryRepository
   {
       public PasswordHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
           base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
       {
       }
       public IEnumerable<PasswordHistory> GetPasswordHistoryByUserID(int UserID)
       {
           SqlParameter userid = new SqlParameter("@UserID", UserID);
           return Context.Database.SqlQuery<PasswordHistory>(Global.StoredProcedureConst.PasswordHistoryRepositoryProcedure.GetPasswordHistoryByUserID, userid);
       }
   }
}
