using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierTreatmentRepository : BaseRepository<SupplierTreatment, ITSDBContext>, ISupplierTreatmentRepository
    {
        public SupplierTreatmentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierTreatment> GetSupplierTreatmentBySupplierID(int supplierId)
        {
            SqlParameter _SupplierId = new SqlParameter("@SupplierId ", supplierId);
            return Context.Database.SqlQuery<SupplierTreatment>(Global.StoredProcedureConst.SupplierTreatmentRepositoryProcedure.GetSupplierTreatmentBySupplierID, _SupplierId);
        }


        public int AddSupplierTreatment(SupplierTreatment supplierTreatment)
        {
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", supplierTreatment.TreatmentCategoryID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierTreatment.SupplierID);
            SqlParameter _Enabled = new SqlParameter("@Enabled", supplierTreatment.Enabled);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierTreatmentRepositoryProcedure.AddSupplierTreatment, _TreatmentCategoryID, _SupplierID, _Enabled).SingleOrDefault();

        }

        public int UpdateSupplierTreatmentBySupplierTreatmentID(SupplierTreatment supplierTreatment)
        {

            SqlParameter _SupplierTreatmentID = new SqlParameter("@SupplierTreatmentID", supplierTreatment.SupplierTreatmentID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", supplierTreatment.TreatmentCategoryID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierTreatment.SupplierID);
            SqlParameter _Enabled = new SqlParameter("@Enabled", supplierTreatment.Enabled);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierTreatmentRepositoryProcedure.UpdateSupplierTreatmentBySupplierTreatmentID, _SupplierTreatmentID, _TreatmentCategoryID, _SupplierID, _Enabled);

        }


        public SupplierTreatment GetSupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID(SupplierTreatment supplierTreatment)
        {
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierTreatment.SupplierID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", supplierTreatment.TreatmentCategoryID);

            return Context.Database.SqlQuery<SupplierTreatment>(Global.StoredProcedureConst.SupplierTreatmentRepositoryProcedure.GetSupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID, _SupplierID, _TreatmentCategoryID).SingleOrDefault();

        }


        public IEnumerable<PriceAverage> GetSupplierPriceAverage(int supplierID, int treatmentCategoryID)
        {
            SqlParameter _SupplierId = new SqlParameter("@SupplierId ", supplierID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", treatmentCategoryID);
            return Context.Database.SqlQuery<PriceAverage>(Global.StoredProcedureConst.SupplierTreatmentRepositoryProcedure.GetSupplierPriceAverage, _SupplierId, _TreatmentCategoryID);
        }
    }
}
