using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.Data
{
	public interface ISupplierDistanceRankingRepository : IBaseRepository<SupplierDistanceRanking>
	{
        IEnumerable<SupplierDistanceRanking> GetSupplierWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID);
        IEnumerable<SuppliersName> GetAllSupplierWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID);
        IEnumerable<SupplierDistanceRanking> GetSupplierSupplierTreatmentsAndSupplierTreatmenPricingWithinArea(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID);
        IEnumerable<SupplierDistanceRanking> GetSupplierWithinAreaBySupplierID(double radiansLat, double radiansLong, int distanceKM, int treatmentCategoryID, int supplierID);
        
	}
}
