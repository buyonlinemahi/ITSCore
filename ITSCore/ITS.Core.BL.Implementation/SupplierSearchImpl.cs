using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierSearchImpl : ISupplierSearch
    {

        private readonly ISupplierSearchRepository _supplierSearchRepository;


        public SupplierSearchImpl(ISupplierSearchRepository supplierSearchRepository)
        {
            _supplierSearchRepository = supplierSearchRepository;

        }

        public IEnumerable<SupplierSearch> GetSuppliersLikeSupplierName(string supplierName,int skip, int take)
        {
            return _supplierSearchRepository.GetSuppliersLikeSupplierName(supplierName,skip,take);
        }

        public IEnumerable<SupplierSearch> GetSuppliersLikePostCode(string postCode,int skip, int take)
        {
            return _supplierSearchRepository.GetSuppliersLikePostCode(postCode, skip, take);
        }

   

        public int GetSuppliersLikePostCodeCount(string postcode)
        {
            return _supplierSearchRepository.GetSuppliersLikePostCodeCount(postcode);
        }

        public int GetSuppliersLikeSupplierNameCount(string supplierName)
        {
            return _supplierSearchRepository.GetSuppliersLikeSupplierNameCount(supplierName);
        }

        public int GetSupplierLikeTreatmentCategoryTypeCount(string treatmentCategoryType)
        {
            return _supplierSearchRepository.GetSupplierLikeTreatmentCategoryTypeCount(treatmentCategoryType);
        }

        public IEnumerable<SupplierSearch> GetSupplierLikeTreatmentCategoryType(string treatmentType, int skip, int take)
        {
            return _supplierSearchRepository.GetSupplierLikeTreatmentCategoryType(treatmentType, skip, take);
        }
    }
}
