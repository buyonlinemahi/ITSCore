using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ReferrerProjectTreatmentPricingRepository.cs
 Latest Version:  1.2
  Purpose: create Referrer Project TreatmentPricing Repository  inside itscore project
  Revision History:

   1.0 – 11/09/2012 Satya
 * ==============================================================================================
 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.1
  Description : Add Method Name Getall to Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Add Method Name Getall to Add_ReferrerProjectTreatmentPricing()
  Description : Add Method Name Getall to Update_ReferrerProjectTreatmentPricingByPricingID()
     *
 ==============================================================================================
  Edited By :   Vishal
  Version  :    1.2
  Description : Modify Add  method to add Scope Identy
  ModifiedDate: 11/19/2012

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentPricingRepository : BaseRepository<ReferrerProjectTreatmentPricing, ITSDBContext>, IReferrerProjectTreatmentPricingRepository
    {
        public ReferrerProjectTreatmentPricingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddReferrerProjectTreatmentPricing(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing)
        {
            SqlParameter PricingTypeID = new SqlParameter("@PricingTypeID", referrerProjectTreatmentPricing.PricingTypeID);
            SqlParameter Price = new SqlParameter("@Price", referrerProjectTreatmentPricing.Price.HasValue ? (object)referrerProjectTreatmentPricing.Price.Value : System.DBNull.Value);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentPricing.ReferrerProjectTreatmentID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentPricingRepositoryProcedure.Add_ReferrerProjectTreatmentPricing, PricingTypeID, Price, ReferrerProjectTreatmentID).SingleOrDefault();
        }

        public int UpdateReferrerProjectTreatmentPricingByPricingID(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing)
        {
            SqlParameter PricingID = new SqlParameter("@PricingID", referrerProjectTreatmentPricing.PricingID);
            SqlParameter PricingTypeID = new SqlParameter("@PricingTypeID", referrerProjectTreatmentPricing.PricingTypeID);
            SqlParameter Price = new SqlParameter("@Price", referrerProjectTreatmentPricing.Price.HasValue ? (object)referrerProjectTreatmentPricing.Price.Value : System.DBNull.Value);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentPricing.ReferrerProjectTreatmentID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentPricingRepositoryProcedure.Update_ReferrerProjectTreatmentPricingByPricingID, PricingID, PricingTypeID, Price, ReferrerProjectTreatmentID);
        }

        IEnumerable<ReferrerProjectTreatmentPricing> IReferrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentPricing>(Global.StoredProcedureConst.ReferrerProjectTreatmentPricingRepositoryProcedure.Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID, _ReferrerProjectTreatmentID);
        }

        public IEnumerable<ReferrerPricingValue> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(int referrerProjectTreatmentID, int treatmentCategoryID)
        {
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);

            return Context.Database.SqlQuery<ReferrerPricingValue>(Global.StoredProcedureConst.ReferrerProjectTreatmentPricingRepositoryProcedure.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID, _ReferrerProjectTreatmentID, _TreatmentCategoryID);
        }

        public ReferrerProjectTreatmentPricing GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(int referrerProjectTreatmentID, int pricingTypeID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            SqlParameter PricingTypeID = new SqlParameter("@PricingTypeID", pricingTypeID);

            return Context.Database.SqlQuery<ReferrerProjectTreatmentPricing>(Global.StoredProcedureConst.ReferrerProjectTreatmentPricingRepositoryProcedure.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID, ReferrerProjectTreatmentID, PricingTypeID).SingleOrDefault<ReferrerProjectTreatmentPricing>();
        }
    }
}