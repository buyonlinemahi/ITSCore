using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierTreatmentPricingRepository : BaseRepository<SupplierTreatmentPricing, ITSDBContext>, ISupplierTreatmentPricingRepository
    {
        public SupplierTreatmentPricingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingBySupplierTreatmentId(int supplierTreatmentID)
        {
            SqlParameter _SupplierTreatmentID = new SqlParameter("@SupplierTreatmentID ", supplierTreatmentID);
            return Context.Database.SqlQuery<SupplierTreatmentPricing>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetSupplierTreatmentPricingBySupplierTreatmentId, _SupplierTreatmentID);
        }


        public int AddSupplierTreatmentPricing(SupplierTreatmentPricing supplierTreatmentPricing)
        {

            SqlParameter _PricingTypeID = new SqlParameter("@PricingTypeID ", supplierTreatmentPricing.PricingTypeID);
            SqlParameter _Price = new SqlParameter("@Price ", supplierTreatmentPricing.Price.HasValue ? (object)supplierTreatmentPricing.Price.Value : System.DBNull.Value);
            SqlParameter _SupplierTreatmentID = new SqlParameter("@SupplierTreatmentId ", supplierTreatmentPricing.SupplierTreatmentID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.AddSupplierTreatmentPricing, _PricingTypeID, _Price, _SupplierTreatmentID).SingleOrDefault();

        }

        public int UpdateSupplierTreatmentPricingByPricingID(SupplierTreatmentPricing supplierTreatmentPricing)
        {

            SqlParameter _PricingTypeID = new SqlParameter("@PricingTypeID ", supplierTreatmentPricing.PricingTypeID);
            SqlParameter _Price = new SqlParameter("@Price ", supplierTreatmentPricing.Price.HasValue ? (object)supplierTreatmentPricing.Price.Value : System.DBNull.Value);
            SqlParameter _SupplierTreatmentID = new SqlParameter("@SupplierTreatmentId ", supplierTreatmentPricing.SupplierTreatmentID);
            SqlParameter _PricingID = new SqlParameter("@PricingID ", supplierTreatmentPricing.PricingID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.UpdateSupplierTreatmentPricingByPricingID, _PricingTypeID, _Price, _SupplierTreatmentID, _PricingID);

        }


        public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
        {
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierSupplierTreatmentsAndSupplierTreatmenPricing>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetTriageSuppliersTreamentPricingByTreatmentCategoryID, _TreatmentCategoryID);
        }

        public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricingResult> GetSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
        {
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierSupplierTreatmentsAndSupplierTreatmenPricingResult>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetSuppliersTreamentPricingByTreatmentCategoryID, _TreatmentCategoryID);
        }


        public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
        {
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierSupplierTreatmentsAndSupplierTreatmenPricing>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID, _TreatmentCategoryID);
        }


        public IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID(int treatmentCategoryID, int supplierID)
        {
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID ", supplierID);
            return Context.Database.SqlQuery<SupplierTreatmentPricing>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID, _TreatmentCategoryID, _SupplierID);
        }



        public IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(int supplierTreatmentID, int treatmentCategoryID)
        {
            SqlParameter _SupplierTreatmentID = new SqlParameter("@SupplierTreatmentID ", supplierTreatmentID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierPricingValue>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID, _SupplierTreatmentID, _TreatmentCategoryID);

        }

        public IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID(int supplierID, int treatmentCategoryID, int pricingTypeID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID ", supplierID);
            SqlParameter _treatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            SqlParameter _pricingTypeID = new SqlParameter("@PricingTypeID ", pricingTypeID);
            return Context.Database.SqlQuery<SupplierPricingValue>(Global.StoredProcedureConst.SupplierTreatmentPricingRepositoryProcedure.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID, _supplierID,_treatmentCategoryID,_pricingTypeID);

        }
    }
}
