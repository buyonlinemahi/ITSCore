using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
	public class SupplierDistanceRankingRepository : BaseRepository<SupplierDistanceRanking, ITSDBContext>, ISupplierDistanceRankingRepository 
	{
		public SupplierDistanceRankingRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierDistanceRanking> GetSupplierWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID)
        {
            SqlParameter radiansLatitudeParam = new SqlParameter("@RadiansLatitude", radiansLat);
            SqlParameter radiansLongitudeParam = new SqlParameter("@RadiansLongitude", radiansLong);
            SqlParameter distanceKMParam = new SqlParameter("@DistanceKM", distanceKM);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierDistanceRanking>(Global.StoredProcedureConst.SupplierDistanceRankingRepositoryProcedure.GetSuppliersWithinArea, radiansLatitudeParam, radiansLongitudeParam, distanceKMParam, treatmentCategoryIDParam).ToList();
        }

        public IEnumerable<SupplierDistanceRanking> GetSupplierSupplierTreatmentsAndSupplierTreatmenPricingWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID)
        {
            SqlParameter radiansLatitudeParam = new SqlParameter("@RadiansLatitude", radiansLat);
            SqlParameter radiansLongitudeParam = new SqlParameter("@RadiansLongitude", radiansLong);
            SqlParameter distanceKMParam = new SqlParameter("@DistanceKM", distanceKM);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return Context.Database.SqlQuery<SupplierDistanceRanking>(Global.StoredProcedureConst.SupplierDistanceRankingRepositoryProcedure.GetSupplierSupplierTreatmentsAndSupplierTreatmenPricingWithinArea, radiansLatitudeParam, radiansLongitudeParam, distanceKMParam, treatmentCategoryIDParam).ToList();
        }


        public IEnumerable<SuppliersName> GetAllSupplierWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID)
        {
            SqlParameter radiansLatitudeParam = new SqlParameter("@RadiansLatitude", radiansLat);
            SqlParameter radiansLongitudeParam = new SqlParameter("@RadiansLongitude", radiansLong);
            SqlParameter distanceKMParam = new SqlParameter("@DistanceKM", distanceKM);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return Context.Database.SqlQuery<SuppliersName>(Global.StoredProcedureConst.SupplierDistanceRankingRepositoryProcedure.GetAllSupplierWithinArea, radiansLatitudeParam, radiansLongitudeParam, distanceKMParam, treatmentCategoryIDParam).ToList();
        }


        public IEnumerable<SupplierDistanceRanking> GetSupplierWithinAreaBySupplierID(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID, int supplierID)
        {
            SqlParameter radiansLatitudeParam = new SqlParameter("@RadiansLatitude", radiansLat);
            SqlParameter radiansLongitudeParam = new SqlParameter("@RadiansLongitude", radiansLong);
            SqlParameter distanceKMParam = new SqlParameter("@DistanceKM", distanceKM);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            SqlParameter supplierIDParam = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierDistanceRanking>(Global.StoredProcedureConst.SupplierDistanceRankingRepositoryProcedure.GetSupplierWithinAreaBySupplierID, radiansLatitudeParam, radiansLongitudeParam, distanceKMParam, treatmentCategoryIDParam, supplierIDParam).ToList();
           
        }
    }
}

