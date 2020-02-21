using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


#region Comment
/*Latest Version : 1.1

    * Author : Vijay Kumar
    * Reason :-Create SupplierPractitionersRepository    
    * Created on 03-jan-2013 
 * 
 *Description : Implement Interface For AddSupplierPractitioner
  Description : Implement Interface For UpdateSupplierPractitioner
  Description : Implement Interface For GetSupplierPractitionerByPractitionerID
  Description : Implement Interface For GetSupplierPractitionerBySupplierID
  Description : Implement Interface For DeleteSupplierPractitionerByPractitionerID
====================================================================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Update the repository because of changes in table design.


      
*/
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SupplierPractitionersRepository : BaseRepository<SupplierPractitioners, ITSDBContext>, ISupplierPractitionersRepository
    {

        public SupplierPractitionersRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }



        public int AddSupplierPractitionerRegistration(SupplierPractitioners supplierPractitioner)
        {
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierPractitioner.SupplierID);
            SqlParameter _PractitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", supplierPractitioner.PractitionerRegistrationID);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.AddSupplierPractitionerRegistration, _SupplierID, _PractitionerRegistrationID).SingleOrDefault();
        }

        public int UpdateSupplierPractitioner(SupplierPractitioners supplierPractitioner)
        {

            SqlParameter _SupplierPractitionerID = new SqlParameter("@SupplierPractitionerID", supplierPractitioner.SupplierPractitionerID);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierPractitioner.SupplierID);
            SqlParameter _PractitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", supplierPractitioner.PractitionerRegistrationID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.UpdateSupplierPractitionerBySupplierPractitionerID, _SupplierPractitionerID, _SupplierID, _PractitionerRegistrationID);

        }


        public IEnumerable<SupplierPractitioners> GetSupplierPractitionerByPractitionerRegistrationID(int practitionerRegistrationID)
        {
            SqlParameter _PractitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", practitionerRegistrationID);


            return Context.Database.SqlQuery<SupplierPractitioners>(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.GetSupplierPractitionerByPractitionerRegistrationID, _PractitionerRegistrationID);

        }


        public int DeleteSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID)
        {
            SqlParameter _SupplierPractitionerID = new SqlParameter("@SupplierPractitionerID", supplierPractitionerID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.DeleteSupplierPractitionerBySupplierPractitionerID, _SupplierPractitionerID);

        }

        public SupplierPractitioners GetSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID)
        {
            SqlParameter _SupplierPractitionerID = new SqlParameter("@SupplierPractitionerID", supplierPractitionerID);
            return Context.Database.SqlQuery<SupplierPractitioners>(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.GetSupplierPractitionerBySupplierPractitionerID, _SupplierPractitionerID).SingleOrDefault();

        }





        public IEnumerable<SupplierPractitionerSupplier> GetSupplierPractitionerSupplierByPractitionerID(int practitionerID)
        {
            SqlParameter _PractitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.SqlQuery<SupplierPractitionerSupplier>(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.GetSupplierPractitionerSupplierByPractitionerID, _PractitionerID);
        }


        public SupplierPractitioners GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID(SupplierPractitioners SupplierPractitioner)
        {
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", SupplierPractitioner.SupplierID);
            SqlParameter _PractitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", SupplierPractitioner.PractitionerRegistrationID);

            return Context.Database.SqlQuery<SupplierPractitioners>(Global.StoredProcedureConst.SupplierPractitionersRepositoryProcedure.GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID, _SupplierID, _PractitionerRegistrationID).SingleOrDefault();

        
        }
    }
}
