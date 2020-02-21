using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierSearchRepository : BaseRepository<SupplierSearch, ITSDBContext>, ISupplierSearchRepository
    {
        public SupplierSearchRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierSearch> GetSuppliersLikeSupplierName(string supplierName, int skip, int take)
        {
            SqlParameter _supplierName = new SqlParameter("@SupplierName ", supplierName);
            SqlParameter _skip = new SqlParameter("@Skip ", skip);
            SqlParameter _take = new SqlParameter("@Take ", take);
            return Context.Database.SqlQuery<SupplierSearch>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.Get_SuppliersLikeSupplierName, _supplierName, _skip, _take);
        }


        public IEnumerable<SupplierSearch> GetSuppliersLikePostCode(string postCode, int skip, int take)
        {
            SqlParameter _postCode = new SqlParameter("@PostCode ", postCode);
            SqlParameter _skip = new SqlParameter("@Skip ", skip);
            SqlParameter _take = new SqlParameter("@Take ", take);
            return Context.Database.SqlQuery<SupplierSearch>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.Get_SuppliersLikePostCode, _postCode,_skip,_take);

        }

        public IEnumerable<SupplierSearch> GetSupplierLikeTreatmentCategoryType(string treatmentType, int skip, int take)
        {
            SqlParameter _treatmentType = new SqlParameter("@TreatmentCategoryType", treatmentType);
            SqlParameter _skip = new SqlParameter("@Skip ", skip);
            SqlParameter _take = new SqlParameter("@Take ", take);
            return Context.Database.SqlQuery<SupplierSearch>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.Get_SupplierLikeTreatmentCategoryType, _treatmentType,_skip, _take);

        }



        public int GetSuppliersLikeSupplierNameCount(string supplierName)
        {
            SqlParameter _supplierName = new SqlParameter("@SupplierName ", supplierName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.GetSuppliersLikeSupplierNameCount, _supplierName).SingleOrDefault();
        }

        public int GetSuppliersLikePostCodeCount(string postcode)
        {
            SqlParameter _PostCode = new SqlParameter("@PostCode ", postcode);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.GetSuppliersLikePostCodeCount, _PostCode).SingleOrDefault();
        }

        public int GetSupplierLikeTreatmentCategoryTypeCount(string treatmentCategoryType)
        {
            SqlParameter _treatmentCategoryType = new SqlParameter("@TreatmentCategoryType ", treatmentCategoryType);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.SupplierSearchRepositoryProcedure.GetSupplierLikeTreatmentCategoryTypeCount, _treatmentCategoryType).SingleOrDefault();
        }



    }
}
