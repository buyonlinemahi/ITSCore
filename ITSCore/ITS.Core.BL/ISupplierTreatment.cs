using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL
{
    public interface ISupplierTreatment
    {
        int AddSupplierTreatment(SupplierTreatment supplierTreatment);
        int UpdateSupplierTreatmentBySupplierTreatmentID(SupplierTreatment supplierTreatment);
        IEnumerable<SupplierTreatment> GetSupplierTreatmentBySupplierID(int supplierId);

    }
}
