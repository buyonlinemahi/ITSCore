using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  TreatmentTypeRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create Treatment Type model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 01/01/2013 Robin Singh 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentTypeRepository : BaseRepository<TreatmentType, ITSDBContext>, ITreatmentTypeRepository
    {
        public TreatmentTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


    }
}
