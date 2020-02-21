using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
	public class UKPostCodeRepository : BaseRepository<UKPostCode, ITSDBContext>, IUKPostCodeRepository 
	{
		public UKPostCodeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public UKPostCode GetPostCodeInfo(string postCode)
        {
            return dbset.SingleOrDefault(pc => pc.PostCode.Equals(postCode, StringComparison.OrdinalIgnoreCase));
        }

	}
}

