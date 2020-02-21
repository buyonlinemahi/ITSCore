using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  TreatmentCategoryRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create TreatmentCategory model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentCategoryRepository : BaseRepository<TreatmentCategory, ITSDBContext>, ITreatmentCategoryRepository
    {
        public TreatmentCategoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
