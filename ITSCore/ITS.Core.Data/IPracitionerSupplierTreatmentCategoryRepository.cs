using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface IPracitionerSupplierTreatmentCategoryRepository : IBaseRepository<PracitionerSupplierTreatmentCategory>
    {
        IEnumerable<PracitionerSupplierTreatmentCategory> GetPracitionersByTreatmentCategoryIDAndSupplierID(int supplierID, int treatmentCategoryID);
    }
}
