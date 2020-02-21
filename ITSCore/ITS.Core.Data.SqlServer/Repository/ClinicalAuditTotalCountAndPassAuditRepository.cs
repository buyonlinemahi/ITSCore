using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ClinicalAuditTotalCountAndPassAuditRepository.cs                      
 Latest Version:  1.1                                                                                                
 History:                                                                                              
   1.0 – 04/19/2013 Satya 
 * ==============================================================================================
  Description : Add CURD to ClinicalAuditTotalCountAndPassAuditRepository
 */

namespace ITS.Core.Data.SqlServer.Repository
{

    public class ClinicalAuditTotalCountAndPassAuditRepository : BaseRepository<ClinicalAuditTotalCountAndPassAudit, ITSDBContext>, IClinicalAuditTotalCountAndPassAuditRepository
    {
        public ClinicalAuditTotalCountAndPassAuditRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public ClinicalAuditTotalCountAndPassAudit  GetClinicalAuditTotalCountAndPassAuditsBySupplierID(int supplierID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<ClinicalAuditTotalCountAndPassAudit>(Global.StoredProcedureConst.ClinicalAuditTotalCountAndPassAuditRepositoryProcedure.GetClinicalAuditTotalCountAndPassAuditsBySupplierID, _supplierID).SingleOrDefault();
        }
     
    }
}