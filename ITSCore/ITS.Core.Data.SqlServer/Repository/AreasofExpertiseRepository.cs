using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  AreasofExpertiseRepository.cs                      
 Latest Version:  1.1                                              
  Purpose: create AreasofExpertise model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 01/01/2013 Vishal 
 * 
* Author         : harpreet Singh
 * Date           : 07-Jan-2013
 * Version        : 1.1
 * Description    : Added GetAllAreasofExpertiseByTreatmentCategoryID Mehtod for AreasofExpertiseTest
 */
namespace ITS.Core.Data.SqlServer.Repository
{
    public class AreasofExpertiseRepository : BaseRepository<AreasofExpertise, ITSDBContext>, IAreasofExpertiseRepository
    {
        public AreasofExpertiseRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }



      


    }
}
