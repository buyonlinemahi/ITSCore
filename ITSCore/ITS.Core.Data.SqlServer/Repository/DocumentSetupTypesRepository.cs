using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
/* ============================================================================= 
 *  Page Name:  DocumentSetupTypesRepository.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:     create DocumentSetupTypesRepository model  inside itscore project  
 * ======================================================================================
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class DocumentSetupTypesRepository : BaseRepository<DocumentSetupTypes, ITSDBContext>, IDocumentSetupTypesRepository
    {
        public DocumentSetupTypesRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }
    }
}
