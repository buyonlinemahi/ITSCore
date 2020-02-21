using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

/*
Latest Version:1.0
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add solicitor Repository Implementation
 * Description : Add implement Method AddSolicitor

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class SolicitorRepository : BaseRepository<Solicitor, ITSDBContext>, ISolicitorRepository
    {
        public SolicitorRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddSolicitor(Solicitor solicitor)
        {
            SqlParameter CompanyName = new SqlParameter("@CompanyName", !string.IsNullOrEmpty(solicitor.CompanyName) ? (object)solicitor.CompanyName : System.DBNull.Value); 
            SqlParameter Address = new SqlParameter("@Address", !string.IsNullOrEmpty(solicitor.Address) ? (object)solicitor.Address : System.DBNull.Value); 
            SqlParameter Phone = new SqlParameter("@Phone", !string.IsNullOrEmpty(solicitor.Phone) ? (object)solicitor.Phone : System.DBNull.Value);
            SqlParameter Email = new SqlParameter("@Email", !string.IsNullOrEmpty(solicitor.Email) ? (object)solicitor.Email : System.DBNull.Value);
            SqlParameter FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(solicitor.FirstName) ? (object)solicitor.FirstName : System.DBNull.Value);
            SqlParameter LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(solicitor.LastName) ? (object)solicitor.LastName : System.DBNull.Value);
            SqlParameter PostCode = new SqlParameter("@PostCode", !string.IsNullOrEmpty(solicitor.PostCode) ? (object)solicitor.PostCode : System.DBNull.Value);
            SqlParameter Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(solicitor.Fax) ? (object)solicitor.Fax : System.DBNull.Value);
            SqlParameter ReferenceNumber = new SqlParameter("@ReferenceNumber", !string.IsNullOrEmpty(solicitor.ReferenceNumber) ? (object)solicitor.ReferenceNumber : System.DBNull.Value);
            SqlParameter City = new SqlParameter("@City", !string.IsNullOrEmpty(solicitor.City) ? (object)solicitor.City : System.DBNull.Value);
            SqlParameter Region = new SqlParameter("@Region", !string.IsNullOrEmpty(solicitor.Region) ? (object)solicitor.Region : System.DBNull.Value);
            SqlParameter IsReferralUnderJointInstruction = new SqlParameter("@IsReferralUnderJointInstruction",(object)solicitor.IsReferralUnderJointInstruction ?? System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.SolicitorRepositoryProcedure.Add_Solicitor, CompanyName, Address, Phone, Email, FirstName, LastName, PostCode, Fax, ReferenceNumber, City, Region, IsReferralUnderJointInstruction).SingleOrDefault();
        }

        public int UpdateSolicitorBySolicitorID(Solicitor solicitor)
        {
            SqlParameter SolicitorID = new SqlParameter("@SolicitorID", solicitor.SolicitorID);
            SqlParameter CompanyName = new SqlParameter("@CompanyName", !string.IsNullOrEmpty(solicitor.CompanyName) ? (object)solicitor.CompanyName : System.DBNull.Value); 
            SqlParameter Address = new SqlParameter("@Address", !string.IsNullOrEmpty(solicitor.Address) ? (object)solicitor.Address : System.DBNull.Value);
            SqlParameter Phone = new SqlParameter("@Phone", !string.IsNullOrEmpty(solicitor.Phone) ? (object)solicitor.Phone : System.DBNull.Value);
            SqlParameter Email = new SqlParameter("@Email", !string.IsNullOrEmpty(solicitor.Email) ? (object)solicitor.Email : System.DBNull.Value);
            SqlParameter FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(solicitor.FirstName) ? (object)solicitor.FirstName : System.DBNull.Value);
            SqlParameter LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(solicitor.LastName) ? (object)solicitor.LastName : System.DBNull.Value);
            SqlParameter PostCode = new SqlParameter("@PostCode", !string.IsNullOrEmpty(solicitor.PostCode) ? (object)solicitor.PostCode : System.DBNull.Value);
            SqlParameter Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(solicitor.Fax) ? (object)solicitor.Fax : System.DBNull.Value);
            SqlParameter ReferenceNumber = new SqlParameter("@ReferenceNumber", !string.IsNullOrEmpty(solicitor.ReferenceNumber) ? (object)solicitor.ReferenceNumber : System.DBNull.Value);
            SqlParameter City = new SqlParameter("@City", !string.IsNullOrEmpty(solicitor.City) ? (object)solicitor.City : System.DBNull.Value);
            SqlParameter Region = new SqlParameter("@Region", !string.IsNullOrEmpty(solicitor.Region) ? (object)solicitor.Region : System.DBNull.Value);
            SqlParameter IsReferralUnderJointInstruction = new SqlParameter("@IsReferralUnderJointInstruction", (object)solicitor.IsReferralUnderJointInstruction ?? System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.SolicitorRepositoryProcedure.UpdateSolicitorBySolicitorID, SolicitorID, CompanyName, Address, Phone, Email, FirstName, LastName, PostCode, Fax, ReferenceNumber, City, Region, IsReferralUnderJointInstruction);
        }

        public Solicitor GetSolicitorBySolicitorID(int solicitorID)
        {
            SqlParameter SolicitorID = new SqlParameter("@SolicitorID", solicitorID);

            return Context.Database.SqlQuery<Solicitor>(Global.StoredProcedureConst.SolicitorRepositoryProcedure.GetSolicitorBySolicitorID, SolicitorID).SingleOrDefault();
        }

        public Solicitor GetSolicitorByPatientID(int patientID)
        {
            SqlParameter PatientID = new SqlParameter("@PatientID", patientID);

            return Context.Database.SqlQuery<Solicitor>(Global.StoredProcedureConst.SolicitorRepositoryProcedure.GetSolicitorByPatientID, PatientID).SingleOrDefault();
        }
    }
}