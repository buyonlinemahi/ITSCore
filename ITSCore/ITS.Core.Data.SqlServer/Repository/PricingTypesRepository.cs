using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;


#region Comment
/*
    * Author : Vishal Sen
    * Latest Version : 1.0
    * Reason :-Create Pricing Type model inside itscore project            
    * Created on 11-07-2012 
 
 Revision History
      
*/
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class PricingTypesRepository : BaseRepository<PricingType, ITSDBContext>, IPricingTypesRepository
    {
        public PricingTypesRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }       
    }
}
