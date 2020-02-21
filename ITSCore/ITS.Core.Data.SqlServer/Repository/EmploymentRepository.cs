using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class EmploymentRepository : BaseRepository<Employment, ITSDBContext>, IEmploymentRepository
    {
        public EmploymentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public Employment GetEmploymentByEmploymentID(int _employmentID)
        {
            SqlParameter employmentID = new SqlParameter("@EmploymentID", _employmentID);
            return Context.Database.SqlQuery<Employment>(Global.StoredProcedureConst.EmploymentRepositoryProcedure.GetEmploymentByEmploymentID, employmentID).FirstOrDefault();
        }

        public int AddEmployment(Employment employment)
        {
            SqlParameter _EmploymentTypeId = new SqlParameter("@EmploymentTypeId", employment.EmploymentTypeId.HasValue ? (object)employment.EmploymentTypeId.HasValue : System.DBNull.Value);
            SqlParameter _CompanyName = new SqlParameter("@CompanyName", !string.IsNullOrEmpty(employment.CompanyName) ? (object)employment.CompanyName : System.DBNull.Value);
            SqlParameter _JobRole = new SqlParameter("@JobRole", !string.IsNullOrEmpty(employment.JobRole) ? (object)employment.JobRole : System.DBNull.Value);
            SqlParameter _Address = new SqlParameter("@Address", !string.IsNullOrEmpty(employment.Address) ? (object)employment.Address : System.DBNull.Value);
            SqlParameter _ContactName = new SqlParameter("@ContactName", !string.IsNullOrEmpty(employment.ContactName) ? (object)employment.ContactName : System.DBNull.Value);
            SqlParameter _PrimaryPhone = new SqlParameter("@PrimaryPhone", !string.IsNullOrEmpty(employment.PrimaryPhone) ? (object)employment.PrimaryPhone : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(employment.Email) ? (object)employment.Email : System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.EmploymentRepositoryProcedure.AddEmployment, _EmploymentTypeId, _CompanyName, _JobRole, _Address, _ContactName, _PrimaryPhone, _Email).FirstOrDefault();
        }

        public int UpdateEmployment(Employment employment)
        {
            SqlParameter _EmploymentId = new SqlParameter("@EmploymentId", employment.EmploymentId);
            SqlParameter _EmploymentTypeId = new SqlParameter("@EmploymentTypeId", employment.EmploymentTypeId.HasValue ? (object)employment.EmploymentTypeId.HasValue : System.DBNull.Value);
            SqlParameter _CompanyName = new SqlParameter("@CompanyName", !string.IsNullOrEmpty(employment.CompanyName) ? (object)employment.CompanyName : System.DBNull.Value);
            SqlParameter _JobRole = new SqlParameter("@JobRole", !string.IsNullOrEmpty(employment.JobRole) ? (object)employment.JobRole : System.DBNull.Value);
            SqlParameter _Address = new SqlParameter("@Address", !string.IsNullOrEmpty(employment.Address) ? (object)employment.Address : System.DBNull.Value);
            SqlParameter _ContactName = new SqlParameter("@ContactName", !string.IsNullOrEmpty(employment.ContactName) ? (object)employment.ContactName : System.DBNull.Value);
            SqlParameter _PrimaryPhone = new SqlParameter("@PrimaryPhone", !string.IsNullOrEmpty(employment.PrimaryPhone) ? (object)employment.PrimaryPhone : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(employment.Email) ? (object)employment.Email : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.EmploymentRepositoryProcedure.UpdateEmployment, _EmploymentId, _EmploymentTypeId, _CompanyName, _JobRole, _Address, _ContactName, _PrimaryPhone, _Email);
        }
    }
}
