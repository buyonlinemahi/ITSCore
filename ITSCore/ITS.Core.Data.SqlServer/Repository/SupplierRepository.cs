using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#region Comment
/*Latest Version : 1.1

    * Author : Vishal Sen
    * Reason :-Create SupplierRepository    
    * Created on 11-17-2012 
 
 Revision HistoryISupplierRepository
 
 * Updated by : Anuj Batra
 * Version:     1.1
 * Date:        12-18-2012
 * Desc:        Added method for GetSuppliersLikePostCode.
      
*/
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierRepository : BaseRepository<Supplier, ITSDBContext>, ISupplierRepository
    {
        public SupplierRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public Supplier GetSupplierBySupplierID(int supplierID)
        {
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<Supplier>(Global.StoredProcedureConst.SupplierRepositoryProcedure.Get_SupplierBySupplierID, _SupplierID).SingleOrDefault<Supplier>();


        }


        public IEnumerable<SuppliersName> GetAllSuppliers()
        {
            return Context.Database.SqlQuery<SuppliersName>(Global.StoredProcedureConst.SupplierRepositoryProcedure.GetAllSuppliers);
        }

        public int AddSupplier(Supplier supplier)
        {
            SqlParameter _SupplierName = new SqlParameter("@SupplierName", supplier.SupplierName);
            SqlParameter _Address = new SqlParameter("@Address", supplier.Address);
            SqlParameter _City = new SqlParameter("@City", supplier.City);
            SqlParameter _Region = new SqlParameter("@Region", supplier.Region);
            SqlParameter _PostCode = new SqlParameter("@PostCode", supplier.PostCode);
            SqlParameter _Phone = new SqlParameter("@Phone", supplier.Phone);
            SqlParameter _Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(supplier.Fax) ? (object)supplier.Fax : System.DBNull.Value);
            SqlParameter _Website = new SqlParameter("@Website", !string.IsNullOrEmpty(supplier.Website) ? (object)supplier.Website : System.DBNull.Value);
            SqlParameter _Ranking = new SqlParameter("@Ranking", supplier.Ranking.HasValue ? (object)supplier.Ranking.Value : System.DBNull.Value);
            SqlParameter _Notes = new SqlParameter("@Notes", !string.IsNullOrEmpty(supplier.Notes) ? (object)supplier.Notes : System.DBNull.Value);
            SqlParameter _IsWheelChairAccessibility = new SqlParameter("@IsWheelChairAccessibility", supplier.IsWheelChairAccessibility);
            SqlParameter _IsWeekends = new SqlParameter("@IsWeekends", supplier.IsWeekends);
            SqlParameter _IsEvenings = new SqlParameter("@IsEvenings", supplier.IsEvenings);
            SqlParameter _IsParking = new SqlParameter("@IsParking", supplier.IsParking);
            SqlParameter _IsHomeVisit = new SqlParameter("@IsHomeVisit", supplier.IsHomeVisit);
            SqlParameter _Email = new SqlParameter("@Email", supplier.Email);
            SqlParameter _IsTriage = new SqlParameter("@IsTriage", supplier.IsTriage);
            
            //SqlParameter _Status = new SqlParameter("@Status", supplier.Status);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierRepositoryProcedure.Add_Supplier, _SupplierName, _Address, _City, _Region, _PostCode, _Phone, _Fax, _Website, _Ranking, _Notes, _IsWheelChairAccessibility, _IsWeekends, _IsEvenings, _IsParking, _IsHomeVisit, _Email, _IsTriage).SingleOrDefault();

        }

        public int UpdateSupplierBySupplierID(Supplier supplier)
        {

            SqlParameter _SupplierID = new SqlParameter("@SupplierID ", supplier.SupplierID);
            SqlParameter _SupplierName = new SqlParameter("@SupplierName", supplier.SupplierName);
            SqlParameter _Address = new SqlParameter("@Address", supplier.Address);
            SqlParameter _City = new SqlParameter("@City", supplier.City);
            SqlParameter _Region = new SqlParameter("@Region", supplier.Region);
            SqlParameter _PostCode = new SqlParameter("@PostCode", supplier.PostCode);
            SqlParameter _Phone = new SqlParameter("@Phone", supplier.Phone);
            SqlParameter _Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(supplier.Fax) ? (object)supplier.Fax : System.DBNull.Value);
            SqlParameter _Website = new SqlParameter("@Website", !string.IsNullOrEmpty(supplier.Website) ? (object)supplier.Website : System.DBNull.Value);
            SqlParameter _Ranking = new SqlParameter("@Ranking", supplier.Ranking.HasValue ? (object)supplier.Ranking.Value : System.DBNull.Value);
            SqlParameter _Notes = new SqlParameter("@Notes", !string.IsNullOrEmpty(supplier.Notes) ? (object)supplier.Notes : System.DBNull.Value);
            SqlParameter _IsWheelChairAccessibility = new SqlParameter("@IsWheelChairAccessibility", supplier.IsWheelChairAccessibility);
            SqlParameter _IsWeekends = new SqlParameter("@IsWeekends", supplier.IsWeekends);
            SqlParameter _IsEvenings = new SqlParameter("@IsEvenings", supplier.IsEvenings);
            SqlParameter _IsParking = new SqlParameter("@IsParking", supplier.IsParking);
            SqlParameter _IsHomeVisit = new SqlParameter("@IsHomeVisit", supplier.IsHomeVisit);
            SqlParameter _Email = new SqlParameter("@Email", supplier.Email);
            SqlParameter _IsTriage = new SqlParameter("@IsTriage", supplier.IsTriage);
            //SqlParameter _Status = new SqlParameter("@Status", supplier.Status);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierRepositoryProcedure.Update_SupplierBySupplierID, _SupplierID, _SupplierName, _Address, _City, _Region, _PostCode, _Phone, _Fax, _Website, _Ranking, _Notes, _IsWheelChairAccessibility, _IsWeekends, _IsEvenings, _IsParking, _IsHomeVisit, _Email, _IsTriage);

        }

        public int UpdateSupplierStatusBySupplierID(int supplierID, int statusID)
        {
            SqlParameter _StatusID = new SqlParameter("@StatusID", statusID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierRepositoryProcedure.Update_SupplierStatusBySupplierID, _StatusID, _SupplierID);
        }


        public bool GetSupplierExistsByName(string supplierName)
        {
            SqlParameter _supplierNameparameter = new SqlParameter("@SupplierName", supplierName);
            return Context.Database.SqlQuery<bool>(Global.StoredProcedureConst.SupplierRepositoryProcedure.GetSupplierExistsByName, _supplierNameparameter).SingleOrDefault();
        }


        public IEnumerable<Supplier> GetSuppliersRecentlyAdded()
        {
            return Context.Database.SqlQuery<Supplier>(Global.StoredProcedureConst.SupplierRepositoryProcedure.GetSuppliersRecentlyAdded);
        }





        public bool GetSupplierExistsByEmail(string email)
        {
            SqlParameter _supplierEmailparameter = new SqlParameter("@Email", email);
            return Context.Database.SqlQuery<bool>(Global.StoredProcedureConst.SupplierRepositoryProcedure.GetSupplierExistsByEmail, _supplierEmailparameter).SingleOrDefault();
        }
    }
}
