using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ReferrerProjectTreatmentInvoiceRepository.cs                      
 Latest Version:  1.0                                                                                                
 History:                                                                                              
   1.0 – 11/22/2012 Satya 
 * ==============================================================================================
  Description : Add CURD to ReferrerProjectTreatmentInvoiceRepository
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentInvoiceRepository : BaseRepository<ReferrerProjectTreatmentInvoice, ITSDBContext>, IReferrerProjectTreatmentInvoiceRepository
    {
        public ReferrerProjectTreatmentInvoiceRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
        {
            SqlParameter InvoicePrice = new SqlParameter("@InvoicePrice", referrerProjectTreatmentInvoice.InvoicePrice.HasValue ? (object)referrerProjectTreatmentInvoice.InvoicePrice.Value : System.DBNull.Value);
            SqlParameter InvoiceMethodID = new SqlParameter("@InvoiceMethodID", referrerProjectTreatmentInvoice.InvoiceMethodID);
            SqlParameter ManagementFeeEnabled = new SqlParameter("@ManagementFeeEnabled", referrerProjectTreatmentInvoice.ManagementFeeEnabled.HasValue ? (object)referrerProjectTreatmentInvoice.ManagementFeeEnabled.Value : System.DBNull.Value);
            SqlParameter ManagementPrice = new SqlParameter("@ManagementPrice", referrerProjectTreatmentInvoice.ManagementPrice.HasValue ? (object)referrerProjectTreatmentInvoice.ManagementPrice.Value : System.DBNull.Value);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentInvoice.ReferrerProjectTreatmentID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentInvoiceRepositoryProcedure.AddReferrerProjectTreatmentInvoice,InvoicePrice,ManagementPrice, ManagementFeeEnabled,InvoiceMethodID,ReferrerProjectTreatmentID).SingleOrDefault();

        }

        public int UpdateReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
        {
            SqlParameter InvoicePrice = new SqlParameter("@InvoicePrice", referrerProjectTreatmentInvoice.InvoicePrice.HasValue ? (object)referrerProjectTreatmentInvoice.InvoicePrice.Value : System.DBNull.Value);
            SqlParameter InvoiceMethodID = new SqlParameter("@InvoiceMethodID", referrerProjectTreatmentInvoice.InvoiceMethodID);
            SqlParameter ManagementFeeEnabled = new SqlParameter("@ManagementFeeEnabled", referrerProjectTreatmentInvoice.ManagementFeeEnabled.HasValue ? (object)referrerProjectTreatmentInvoice.ManagementFeeEnabled.Value : System.DBNull.Value);
            SqlParameter ManagementPrice = new SqlParameter("@ManagementPrice", referrerProjectTreatmentInvoice.ManagementPrice.HasValue ? (object)referrerProjectTreatmentInvoice.ManagementPrice.Value : System.DBNull.Value);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentInvoice.ReferrerProjectTreatmentID);
            SqlParameter ReferrerProjectTreatmentInvoiceID = new SqlParameter("@ReferrerProjectTreatmentInvoiceID", referrerProjectTreatmentInvoice.ReferrerProjectTreatmentInvoiceID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentInvoiceRepositoryProcedure.UpdateReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID, ReferrerProjectTreatmentInvoiceID ,InvoicePrice,ManagementPrice, ManagementFeeEnabled,InvoiceMethodID,ReferrerProjectTreatmentID);

        }

       public IEnumerable<ReferrerProjectTreatmentInvoice> GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentInvoice>(Global.StoredProcedureConst.ReferrerProjectTreatmentInvoiceRepositoryProcedure.GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID, ReferrerProjectTreatmentID);
      
        }
    }
}
