using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class PracitionerSupplierTreatmentCategoryImpl : IPracitionerSupplierTreatmentCategory
    {
        private readonly IPracitionerSupplierTreatmentCategoryRepository _pracitionerSupplierTreatmentCategoryRepository;

        public PracitionerSupplierTreatmentCategoryImpl(IPracitionerSupplierTreatmentCategoryRepository pracitionerSupplierTreatmentCategoryRepository)
        {
            _pracitionerSupplierTreatmentCategoryRepository = pracitionerSupplierTreatmentCategoryRepository;
        }

        public IEnumerable<PracitionerSupplierTreatmentCategory> GetPracitionersByTreatmentCategoryIDAndSupplierID(int supplierID, int treatmentCategoryID)
        {
           return  _pracitionerSupplierTreatmentCategoryRepository.GetPracitionersByTreatmentCategoryIDAndSupplierID(supplierID, treatmentCategoryID);
        }
    }
}
