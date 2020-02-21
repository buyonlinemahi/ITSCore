using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL
{
    public interface IPracitionerSupplierTreatmentCategory
    {
        IEnumerable<PracitionerSupplierTreatmentCategory> GetPracitionersByTreatmentCategoryIDAndSupplierID(int supplierID, int treatmentCategoryID);
    }
}
