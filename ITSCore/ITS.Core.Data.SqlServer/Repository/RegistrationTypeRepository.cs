using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  RegistrationTypeRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create Registration Type model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 12/21/2012 Vishal 

 */

namespace ITS.Core.Data.SqlServer.Repository
{

    public class RegistrationTypeRepository : BaseRepository<RegistrationType, ITSDBContext>, IRegistrationTypeRepository
    {
        public RegistrationTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
