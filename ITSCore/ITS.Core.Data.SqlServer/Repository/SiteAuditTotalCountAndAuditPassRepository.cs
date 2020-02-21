using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  SiteAuditTotalCountAndAuditPassRepository.cs                      
 Latest Version:  1.1                                                                                                
 History:                                                                                              
   1.0 – 04/19/2013 Satya 
 * ==============================================================================================
  Description : Add CURD to SiteAuditTotalCountAndAuditPassRepository
 */

namespace ITS.Core.Data.SqlServer.Repository
{

    public class SiteAuditTotalCountAndAuditPassRepository : BaseRepository<SiteAuditTotalCountAndAuditPass, ITSDBContext>, ISiteAuditTotalCountAndAuditPassRepository
    {
        public SiteAuditTotalCountAndAuditPassRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public SiteAuditTotalCountAndAuditPass GetSiteAuditTotalCountAndAuditPassBySupplierID(int supplierID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SiteAuditTotalCountAndAuditPass>(Global.StoredProcedureConst.SiteAuditTotalCountAndAuditPassRepositoryProcedure.GetSiteAuditTotalCountAndAuditPassBySupplierID, _supplierID).SingleOrDefault();
        }
     
    }
}