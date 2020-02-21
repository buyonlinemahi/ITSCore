using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ISupplierTreatmentRepository : IBaseRepository<SupplierTreatment>
    {
        int AddSupplierTreatment(SupplierTreatment supplierTreatment);
        int UpdateSupplierTreatmentBySupplierTreatmentID(SupplierTreatment supplierTreatment);
        IEnumerable<SupplierTreatment> GetSupplierTreatmentBySupplierID(int supplierId);
        SupplierTreatment GetSupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID(SupplierTreatment supplierTreatment);
        IEnumerable<PriceAverage> GetSupplierPriceAverage(int supplierID, int treatmentCategoryID);
    }
}
