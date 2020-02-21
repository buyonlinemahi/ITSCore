using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
#region Comment
/*
 Page Name:  ISupplierComplaint.cs                      
 Latest Version:  1.2
 Author : Harpreet Singh
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Harpreet Singh
  Date : 12-15-2012
  Version : 1.0
  Description : Implement Interface For AddSupplierComplaint
  Description : Implement Interface For UpdateSupplierComplaintBySupplierComplaintID
  Description : Implement Interface For GetSupplierComplaintBySupplierID
===================================================================================
  Updated By : Anuj Batra
  Date : 12-17-2012
  Version : 1.1
  Description : Updated the namespace as "Repository" was missing from the same.
 ===================================================================================
  Version : 1.2
 Updated By : vishal
 Date : 12/21/2012
 Task : #333
 Description : Implement interface For DeleteSupplierComplaintBySupplierComplaintID
 =============================================================
 * */
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierComplaintRepository : BaseRepository<SupplierComplaint, ITSDBContext>, ISupplierComplaintRepository
    {
        public SupplierComplaintRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {


        }

        public int AddSupplierComplaint(SupplierComplaint supplierComplaint)
        {

            SqlParameter ComplaintTypeID = new SqlParameter("@ComplaintTypeID", supplierComplaint.ComplaintTypeID);
            SqlParameter ComplaintStatusID = new SqlParameter("@ComplaintStatusID", supplierComplaint.ComplaintStatusID);
            SqlParameter ComplaintDescription = new SqlParameter("@ComplaintDescription", supplierComplaint.ComplaintDescription);
            SqlParameter ComplaintDate = new SqlParameter("@ComplaintDate", supplierComplaint.ComplaintDate);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierComplaint.SupplierID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierComplaintRepositoryProcedure.Add_SupplierComplaint, ComplaintTypeID, ComplaintStatusID, ComplaintDescription, ComplaintDate, SupplierID).SingleOrDefault();
        }

        public int UpdateSupplierComplaintBySupplierComplaintID(SupplierComplaint supplierComplaint)
        {
            SqlParameter SupplierComplaintID = new SqlParameter("@SupplierComplaintID", supplierComplaint.SupplierComplaintID);
            SqlParameter ComplaintTypeID = new SqlParameter("@ComplaintTypeID", supplierComplaint.ComplaintTypeID);
            SqlParameter ComplaintStatusID = new SqlParameter("@ComplaintStatusID", supplierComplaint.ComplaintStatusID);
            SqlParameter ComplaintDescription = new SqlParameter("@ComplaintDescription", supplierComplaint.ComplaintDescription);
            SqlParameter ComplaintDate = new SqlParameter("@ComplaintDate", supplierComplaint.ComplaintDate);
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierComplaint.SupplierID);
            return  Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierComplaintRepositoryProcedure.Update_SupplierComplaint, SupplierComplaintID, ComplaintTypeID, ComplaintStatusID, ComplaintDescription, ComplaintDate, SupplierID);
        }

        public IEnumerable<SupplierComplaint> GetSupplierComplaintBySupplierID(int supplierId)
        {
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierId);
            return Context.Database.SqlQuery<SupplierComplaint>(Global.StoredProcedureConst.SupplierComplaintRepositoryProcedure.Get_SupplierComplaintBySupplierID, SupplierID);

        }

        public IEnumerable<SupplierComplaintAndStatusAndType> GetSupplierComplaintAndStatusAndTypesBySupplierID(int supplierId)
        {
            SqlParameter SupplierID = new SqlParameter("@SupplierID", supplierId);
            return Context.Database.SqlQuery<SupplierComplaintAndStatusAndType>(Global.StoredProcedureConst.SupplierComplaintRepositoryProcedure.Get_SupplierComplaintAndStatusAndTypesBySupplierID, SupplierID);

        }

        public int DeleteSupplierComplaintBySupplierComplaintID(int supplierComplaintID)
        {
            SqlParameter _supplierComplaintID = new SqlParameter("@SupplierComplaintID", supplierComplaintID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierComplaintRepositoryProcedure.Delete_SupplierComplaintBySupplierComplaintID, _supplierComplaintID);
     
        }
    }
}
