using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#region Comments

/*
 * Latest Version : 1.0
 * 
 * Author      : Pardeep Kumar
 * Date        : 24-Dec-2012
 * Version     : 1.0
 * Description : Added methods AddSupplierInsurance,UpdateSupplierInsurance and GetSupplierInsuranceBySupplierID
 * 
 */

#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierInsuranceRepository : BaseRepository<SupplierInsurance, ITSDBContext>, ISupplierInsuranceRepository
    {
        public SupplierInsuranceRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddSupplierInsurance(SupplierInsurance supplierInsurance)
        {
            SqlParameter LevelOfCover = new SqlParameter("@LevelOfCover", supplierInsurance.LevelOfCover);
            SqlParameter RenewalDate = new SqlParameter("@RenewalDate", supplierInsurance.RenewalDate);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierInsurance.SupplierID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierInsurance.SupplierDocumentID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierInsuranceRepositoryProcedure.AddSupplierInsurance, LevelOfCover, RenewalDate, SupplierDocumentID, SupplierID).SingleOrDefault();
        }

        public int UpdateSupplierInsurance(SupplierInsurance supplierInsurance)
        {
            SqlParameter LevelOfCover = new SqlParameter("@LevelOfCover", supplierInsurance.LevelOfCover);
            SqlParameter RenewalDate = new SqlParameter("@RenewalDate", supplierInsurance.RenewalDate);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierInsurance.SupplierID);
            SqlParameter SupplierDocumentID = new SqlParameter("@SupplierDocumentID", supplierInsurance.SupplierDocumentID);
            SqlParameter SupplierInsuredID = new SqlParameter("@SupplierInsuredID", supplierInsurance.SupplierInsuredID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierInsuranceRepositoryProcedure.UpdateSupplierInsurance, SupplierInsuredID, LevelOfCover, RenewalDate, SupplierDocumentID, SupplierID);
        }

        public IEnumerable<SupplierInsurance> GetSupplierInsuranceBySupplierID(int supplierID)
        {
            SqlParameter _supplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierInsurance>(Global.StoredProcedureConst.SupplierInsuranceRepositoryProcedure.GetSupplierInsuranceBySupplierID, _supplierID);
        }


        public int DeleteSupplierInsuranceBySupplierInsuredID(int supplierInsuredID)
        {
            SqlParameter _supplierInsuredID = new SqlParameter("@SupplierInsuredID", supplierInsuredID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierInsuranceRepositoryProcedure.DeleteSupplierInsuranceBySupplierInsuredID, _supplierInsuredID);

        }
    }
}
