using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;


#region Comment
/*
    * Author : Satya
    * Latest Version : 1.0
    * Reason :-Create InvoiceMethod model inside itscore project            
    * Created on 11-22-2012 
 
 Revision History
      
*/
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class InvoiceMethodRepository : BaseRepository<InvoiceMethod, ITSDBContext>, IInvoiceMethodRepository
    {
        public InvoiceMethodRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }       
    }
}
