using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  ServiceLevelAgreementRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create ServiceLevel Agreement Repository  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ServiceLevelAgreementRepository : BaseRepository<ServiceLevelAgreement, ITSDBContext>, IServiceLevelAgreementRepository
    {
        public ServiceLevelAgreementRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
