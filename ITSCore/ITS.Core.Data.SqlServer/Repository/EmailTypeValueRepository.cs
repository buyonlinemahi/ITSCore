using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class EmailTypeValueRepository : BaseRepository<EmailTypeValue, ITSDBContext>, IEmailTypeValueRepository
    {
        public EmailTypeValueRepository(IContextFactory<ITSDBContext> contextFactory)
            : base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public IEnumerable<EmailTypeValue> GetAllEmailTypeValue()
        {
            return dbset.AsEnumerable<EmailTypeValue>();
        }
    }
}
