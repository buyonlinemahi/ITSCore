using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
 

namespace ITS.Core.Data.SqlServer.Repository
{

    public class CaseTreatmentPricingRepository : BaseRepository<CaseTreatmentPricing, ITSDBContext>, ICaseTreatmentPricingRepository
    {
        public CaseTreatmentPricingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public int AddCaseTreatmentPricing(CaseTreatmentPricing caseTreatmentPricing)
        {


            SqlParameter CaseID = new SqlParameter("@CaseID", caseTreatmentPricing.CaseID);
            SqlParameter ReferrerPricingID = new SqlParameter("@ReferrerPricingID", caseTreatmentPricing.ReferrerPricingID);
            SqlParameter Price = new SqlParameter("@ReferrerPrice", caseTreatmentPricing.ReferrerPrice);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseTreatmentPricing.DateOfService.HasValue ? (object)caseTreatmentPricing.DateOfService.Value : System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseTreatmentPricing.PatientDidNotAttend.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttend.Value : System.DBNull.Value);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseTreatmentPricing.WasAbandoned.HasValue ? (object)caseTreatmentPricing.WasAbandoned.Value : System.DBNull.Value);
            SqlParameter SupplierPrice = new SqlParameter("@SupplierPrice", caseTreatmentPricing.SupplierPrice);
            SqlParameter Quantity = new SqlParameter("@Quantity", caseTreatmentPricing.Quantity);
            SqlParameter SupplierPriceID = new SqlParameter("@SupplierPriceID", caseTreatmentPricing.SupplierPriceID);
            SqlParameter AuthorizationStatus = new SqlParameter("@AuthorizationStatus", caseTreatmentPricing.AuthorizationStatus.HasValue ? (object)caseTreatmentPricing.AuthorizationStatus : System.DBNull.Value);
            SqlParameter PatientDidNotAttendDate = new SqlParameter("@PatientDidNotAttendDate", caseTreatmentPricing.PatientDidNotAttendDate.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttendDate.Value : System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.AddCaseTreatmentPricing, CaseID, ReferrerPricingID, Price, DateOfService, PatientDidNotAttend, WasAbandoned, SupplierPrice, Quantity, SupplierPriceID, AuthorizationStatus, PatientDidNotAttendDate).SingleOrDefault();
        }

        public int UpdateCaseTreatmentPricing(CaseTreatmentPricing caseTreatmentPricing)
        {

            SqlParameter CaseTreatmentPricingID = new SqlParameter("@CaseTreatmentPricingID", caseTreatmentPricing.CaseTreatmentPricingID);
            SqlParameter CaseID = new SqlParameter("@CaseID", caseTreatmentPricing.CaseID);
            SqlParameter ReferrerPricingID = new SqlParameter("@ReferrerPricingID", caseTreatmentPricing.ReferrerPricingID);
            SqlParameter Price = new SqlParameter("@ReferrerPrice", caseTreatmentPricing.ReferrerPrice);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseTreatmentPricing.DateOfService.HasValue ? (object)caseTreatmentPricing.DateOfService.Value : System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseTreatmentPricing.PatientDidNotAttend.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttend.Value : System.DBNull.Value);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseTreatmentPricing.WasAbandoned.HasValue ? (object)caseTreatmentPricing.WasAbandoned.Value : System.DBNull.Value);
            SqlParameter SupplierPrice = new SqlParameter("@SupplierPrice", caseTreatmentPricing.SupplierPrice);
            SqlParameter Quantity = new SqlParameter("@Quantity", caseTreatmentPricing.Quantity);
            SqlParameter SupplierPriceID = new SqlParameter("@SupplierPriceID", caseTreatmentPricing.SupplierPriceID);
            SqlParameter PatientDidNotAttendDate = new SqlParameter("@PatientDidNotAttendDate", caseTreatmentPricing.PatientDidNotAttendDate.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttendDate.Value : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentPricing, CaseTreatmentPricingID, CaseID, ReferrerPricingID, Price, DateOfService, PatientDidNotAttend, WasAbandoned, SupplierPrice, Quantity, SupplierPriceID, PatientDidNotAttendDate);


        }


        public IEnumerable<CaseTreatmentPricing> GetCaseTreatmentPricingByCaseID(int caseID)
        {
            return
                 Context.Database.SqlQuery<CaseTreatmentPricing>(
                     Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetCaseTreatmentPricingByCaseID,
                     new SqlParameter("@CaseID", caseID)).ToList();
        }

        public int GetCheckCaseTreatmentPricingByCaseID(int caseID, int AssessmentServiceID)
        {
            return
                 Context.Database.SqlQuery<int>(
                     Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetCheckCaseTreatmentPricingByCaseID,
                     new SqlParameter("@CaseID", caseID), new SqlParameter("@AssessmentServiceID", AssessmentServiceID)).SingleOrDefault();
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndIsComplete(int caseID, bool isComplete)
        {
            return
                 Context.Database.SqlQuery<CaseTreatmentPricingType>(
                     Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetCaseTreatmentPricingByCaseIDAndIsComplete,
                     new SqlParameter("@CaseID", caseID), new SqlParameter("@IsComplete", isComplete));
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDCaseSearch(int caseID)
        {
            return
                 Context.Database.SqlQuery<CaseTreatmentPricingType>(
                     Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetCaseTreatmentPricingByCaseIDCaseSearch,
                     new SqlParameter("@CaseID", caseID));
        }


        public int UpdateCaseTreatmentPricingByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing)
        {
            SqlParameter CaseTreatmentPricingID = new SqlParameter("@CaseTreatmentPricingID", caseTreatmentPricing.CaseTreatmentPricingID);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseTreatmentPricing.WasAbandoned.HasValue ? (object)caseTreatmentPricing.WasAbandoned.Value : System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseTreatmentPricing.PatientDidNotAttend.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttend.Value : System.DBNull.Value);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseTreatmentPricing.DateOfService.HasValue ? (object)caseTreatmentPricing.DateOfService.Value : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentPricingByCaseTreatmentPricingID, CaseTreatmentPricingID, WasAbandoned, PatientDidNotAttend, DateOfService);
        }

        public int UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing)
        {
            SqlParameter CaseTreatmentPricingID = new SqlParameter("@CaseTreatmentPricingID", caseTreatmentPricing.CaseTreatmentPricingID);
            SqlParameter WasAbandoned = new SqlParameter("@WasAbandoned", caseTreatmentPricing.WasAbandoned.HasValue ? (object)caseTreatmentPricing.WasAbandoned.Value : System.DBNull.Value);
            SqlParameter PatientDidNotAttend = new SqlParameter("@PatientDidNotAttend", caseTreatmentPricing.PatientDidNotAttend.HasValue ? (object)caseTreatmentPricing.PatientDidNotAttend.Value : System.DBNull.Value);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", caseTreatmentPricing.DateOfService.HasValue ? (object)caseTreatmentPricing.DateOfService.Value : System.DBNull.Value);

            SqlParameter ReferrerPricingID = new SqlParameter("@ReferrerPricingID", caseTreatmentPricing.ReferrerPricingID);
            SqlParameter ReferrerPrice = new SqlParameter("@ReferrerPrice", caseTreatmentPricing.ReferrerPrice);
            SqlParameter SupplierPrice = new SqlParameter("@SupplierPrice", caseTreatmentPricing.SupplierPrice);
            SqlParameter SupplierPriceID = new SqlParameter("@SupplierPriceID", caseTreatmentPricing.SupplierPriceID);
            SqlParameter AuthorizationStatus = new SqlParameter("@AuthorizationStatus", caseTreatmentPricing.AuthorizationStatus.HasValue ? (object)caseTreatmentPricing.AuthorizationStatus : System.DBNull.Value);
            SqlParameter PatientDidNotAttendDate = new SqlParameter("@PatientDidNotAttendDate", caseTreatmentPricing.PatientDidNotAttendDate);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID, CaseTreatmentPricingID, WasAbandoned, PatientDidNotAttend, DateOfService, ReferrerPricingID, ReferrerPrice, SupplierPrice, SupplierPriceID, AuthorizationStatus, PatientDidNotAttendDate);
        }

        public int UpdateCaseTreatmentPricingPriceByReferrerPricingID(CaseTreatmentPricingCaseSearch caseTreatmentPricing)
        {
            int PTId= 0;
            SqlParameter CaseTreatmentPricingID = new SqlParameter("@SupplierPriceID", caseTreatmentPricing.CaseTreatmentPricingID);

            if (caseTreatmentPricing.PricingTypeName == "Initial Assessment")
                PTId = 1;
            else if (caseTreatmentPricing.PricingTypeName == "Review Assessment")
                PTId = 2;
            else if (caseTreatmentPricing.PricingTypeName == "Final Assessment")
                PTId = 3;
            SqlParameter PricingTypeId = new SqlParameter("@PricingTypeId", PTId);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentPricingPriceByReferrerPricingID, CaseTreatmentPricingID, PricingTypeId);
        }

        public int UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(int caseTreatmentPricingID, decimal referrerPrice, int referrerPricingID, DateTime dateOfService)
        {
            SqlParameter CaseTreatmentPricingID = new SqlParameter("@CaseTreatmentPricingID", caseTreatmentPricingID);
            SqlParameter ReferrerPrice = new SqlParameter("@ReferrerPrice", referrerPrice);
            SqlParameter ReferrerPricingID = new SqlParameter("@ReferrerPricingID", referrerPricingID);
            SqlParameter DateOfService = new SqlParameter("@DateOfService", dateOfService);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID, CaseTreatmentPricingID, ReferrerPrice, ReferrerPricingID,DateOfService);
        }


        public IEnumerable<TreatmentReferrerSupplierPricing> GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID)
        {
            SqlParameter referrerProjectTreatmentIDParam = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            SqlParameter supplierIDParam = new SqlParameter("@SupplierID", supplierID);
            SqlParameter treatmentCategoryParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);

            return Context.Database.SqlQuery<TreatmentReferrerSupplierPricing>(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetReferrerAndSupplierPricingBySupplierIDAndTreatmentCategoryIDAndReferrerProjectTreatmentID, referrerProjectTreatmentIDParam, supplierIDParam, treatmentCategoryParam).ToList();
        }

        public TreatmentReferrerSupplierPricing GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID, int pricingTypeID)
        {
            SqlParameter referrerProjectTreatmentIDParam = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            SqlParameter supplierIDParam = new SqlParameter("@SupplierID", supplierID);
            SqlParameter treatmentCategoryParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            SqlParameter pricingTypeIDParam = new SqlParameter("@PricingTypeID", pricingTypeID);

            return Context.Database.SqlQuery<TreatmentReferrerSupplierPricing>(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID, referrerProjectTreatmentIDParam, supplierIDParam, treatmentCategoryParam, pricingTypeIDParam).SingleOrDefault();
        }


        public int DeleteCaseTreatmentPricingByCaseTreatmentPricingID(int caseTreatmentPricingID)
        {
            SqlParameter CaseTreatmentPricingID = new SqlParameter("@CaseTreatmentPricingID", caseTreatmentPricingID);


            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.DeleteCaseTreatmentPricingByCaseTreatmentPricingID, CaseTreatmentPricingID);
        }



        public int DeleteCaseTreatmentPricingByCaseIDCaseStopped(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);


            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.DeleteCaseTreatmentPricingByCaseIDCaseStopped, _caseID);
        }

        public int UpdateCaseTreatmentPricingAuthorisationStatusByCaseID(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);


            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.UpdateCaseTreatmentPricingAuthorisationStatusByCaseID, _caseID);
        }


        public IEnumerable<ReferrerAndSupplierPricing> GetReferrerReferrerAndSupplierTreatmentPricingByCaseID(int caseID, int? PricingTypeID)
        {
            return
          Context.Database.SqlQuery<ReferrerAndSupplierPricing>(
              Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetReferrerReferrerAndSupplierTreatmentPricingByCaseID,
              new SqlParameter("@CaseID", caseID), new SqlParameter("@PricingTypeID", PricingTypeID.HasValue ? (object)PricingTypeID.Value : DBNull.Value));
        }
        
        public EPNATreatmentSession GetEPNATreatmentSessionDetail(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<EPNATreatmentSession>(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetEPNATreatmentSessionDetail, _caseID).SingleOrDefault();
        }

        public TreatmentSessionByCaseID GetTreatmentSessionByCaseID(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<TreatmentSessionByCaseID>(Global.StoredProcedureConst.CaseTreatmentPricingRepositoryProcedure.GetTreatmentSessionByCaseID, _caseID).SingleOrDefault();
        }
    }
}
