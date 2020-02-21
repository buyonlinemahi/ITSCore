using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  AssessmentServiceRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create AssessmentService model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/10/2012 Satya 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class AssessmentServiceRepository : BaseRepository<AssessmentService, ITSDBContext>, IAssessmentServiceRepository
    {
        public AssessmentServiceRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
