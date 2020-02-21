using System.Collections.Generic;
using ITS.Core.Data.Model;
using Core.Base.Data;


namespace ITS.Core.Data
{
    public interface ISupplierSearchRepository : IBaseRepository<SupplierSearch>
    {
         IEnumerable<SupplierSearch> GetSuppliersLikeSupplierName(string supplierName,int skip,int take);
         IEnumerable<SupplierSearch> GetSuppliersLikePostCode(string postCode, int skip, int take);
         int GetSuppliersLikePostCodeCount(string postcode);
         int GetSuppliersLikeSupplierNameCount(string supplierName);
         int GetSupplierLikeTreatmentCategoryTypeCount(string treatmentCategoryType);
         IEnumerable<SupplierSearch> GetSupplierLikeTreatmentCategoryType(string treatmentType, int skip, int take);

    }
}
