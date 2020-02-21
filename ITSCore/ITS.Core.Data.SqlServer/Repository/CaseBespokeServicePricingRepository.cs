using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseBespokeServicePricingRepository : BaseRepository<CaseBespokeServicePricing, ITSDBContext>, ICaseBespokeServicePricingRepository
    {
        public CaseBespokeServicePricingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseBespokeServicePricing(CaseBespokeServicePricing caseBespokeServicePricing)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseBespokeServicePricing.CaseID);
            SqlParameter TreatmentCategoryBespokeServiceID = new SqlParameter("@TreatmentCategoryBespokeServiceID", caseBespokeServicePricing.TreatmentCategoryBespokeServiceID);
            SqlParameter ReferrerPrice = new SqlParameter("@ReferrerPrice", caseBespokeServicePricing.ReferrerPrice);
            SqlParameter SupplierPrice = new SqlParameter("@SupplierPrice", caseBespokeServicePricing.SupplierPrice);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseBespokeServicePricing.DateOfService.HasValue ? (object)caseBespokeServicePricing.DateOfService.Value :System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseBespokeServicePricing.PatientDidNotAttend.HasValue ? (object)caseBespokeServicePricing.PatientDidNotAttend.Value :System.DBNull.Value);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseBespokeServicePricing.WasAbandoned.HasValue ? (object)caseBespokeServicePricing.WasAbandoned.Value :System.DBNull.Value);
         
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.AddCaseBespokeServicePricing, CaseID, TreatmentCategoryBespokeServiceID, ReferrerPrice, SupplierPrice, DateOfService,PatientDidNotAttend ,WasAbandoned);

        }

        public IEnumerable<CaseBespokeServicePricing> GetCaseBespokeServicePricingByCaseID(int caseID)
        {
            return
                 Context.Database.SqlQuery<CaseBespokeServicePricing>(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.GetCaseBespokeServicePricingByCaseID,
                     new SqlParameter("@CaseID", caseID));
        }

        public int UpdateCaseBespokeServicePricingByCaseBespokeServiceID(CaseBespokeServicePricing caseBespokeServicePricing)
        {
            SqlParameter CaseBespokeServiceID = new SqlParameter("@CaseBespokeServiceID", caseBespokeServicePricing.CaseBespokeServiceID);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseBespokeServicePricing.WasAbandoned.HasValue ? (object)caseBespokeServicePricing.WasAbandoned.Value : System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseBespokeServicePricing.PatientDidNotAttend.HasValue ? (object)caseBespokeServicePricing.PatientDidNotAttend.Value : System.DBNull.Value);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseBespokeServicePricing.DateOfService.HasValue ? (object)caseBespokeServicePricing.DateOfService.Value : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.UpdateCaseBespokeServicePricingByCaseBespokeServiceID, CaseBespokeServiceID, WasAbandoned, PatientDidNotAttend, DateOfService);
        }

        public int UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(int caseBespokeServiceID, decimal referrerPrice)
        {
            SqlParameter CaseBespokeServiceID = new SqlParameter("@CaseBespokeServiceID", caseBespokeServiceID);
            SqlParameter ReferrerPrice = new SqlParameter("@ReferrerPrice", referrerPrice);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID, CaseBespokeServiceID, ReferrerPrice);
        }


        public int DeleteCaseBespokeServiceByCaseBespokeServiceID(int caseBespokeServiceID)
        {
            SqlParameter CaseBespokeServiceID = new SqlParameter("@CaseBespokeServiceID", caseBespokeServiceID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.DeleteCaseBespokeServiceByCaseBespokeServiceID, CaseBespokeServiceID);
        }


        public IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndIsComplete(int caseID, bool isComplete)
        {
            return
                 Context.Database.SqlQuery<CaseBespokeServicePricingType>(Global.StoredProcedureConst.CaseBespokeServicePricingRepositoryProcedure.GetCaseBespokeServicePricingByCaseIDAndIsComplete,
                     new SqlParameter("@CaseID", caseID), new SqlParameter("@IsComplete", isComplete));
        }
    }
}
