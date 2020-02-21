using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;

/*
 Page Name:  AssessmentTypeRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create AssessmentType model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/10/2012 Satya 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class AssessmentTypeRepository : BaseRepository<AssessmentType, ITSDBContext>, IAssessmentTypeRepository
    {
        public AssessmentTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
