﻿using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class AffectedAreaRepository: BaseRepository<AffectedArea, ITSDBContext>, IAffectedAreaRepository
    {
        public AffectedAreaRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
