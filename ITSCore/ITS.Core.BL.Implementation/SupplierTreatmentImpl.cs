using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
   public class SupplierTreatmentImpl : ISupplierTreatment
    {

       private readonly ISupplierTreatmentRepository _supplierTreatmentRepository;

       public SupplierTreatmentImpl(ISupplierTreatmentRepository supplierTreatmentRepository)
        {
            _supplierTreatmentRepository = supplierTreatmentRepository;
        }

       public int AddSupplierTreatment(SupplierTreatment supplierTreatment)
       {
           return _supplierTreatmentRepository.GetSupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID(supplierTreatment) != null ? -1 : _supplierTreatmentRepository.AddSupplierTreatment(supplierTreatment);
       }

       public int UpdateSupplierTreatmentBySupplierTreatmentID(SupplierTreatment supplierTreatment)
       {
           return _supplierTreatmentRepository.UpdateSupplierTreatmentBySupplierTreatmentID(supplierTreatment);
       }

       public IEnumerable<SupplierTreatment> GetSupplierTreatmentBySupplierID(int supplierId)
       {
           return _supplierTreatmentRepository.GetSupplierTreatmentBySupplierID(supplierId);
       }
    }
}
