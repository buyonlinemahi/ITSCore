using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  PatientRepository.cs
 Latest Version:  1.0
 Author : Anuj Batra

 * Revision History:

Updated By: Anuj Batra
Date:       01-01-2013
Version     1.0
Desc:       Added method to GetPatientByPatientID.
===================================================================================
*/

namespace ITS.Core.Data.SqlServer.Repository
{
    public class PatientRepository : BaseRepository<Patient, ITSDBContext>, IPatientRepository
    {
        public PatientRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddPatient(Patient patient)
        {
            SqlParameter _Title = new SqlParameter("@Title", !string.IsNullOrEmpty(patient.Title) ? (object)patient.Title : System.DBNull.Value);
            SqlParameter _FirstName = new SqlParameter("@FirstName", patient.FirstName);
            SqlParameter _LastName = new SqlParameter("@LastName", patient.LastName);
            SqlParameter _Address = new SqlParameter("@Address", patient.Address);
            SqlParameter _City = new SqlParameter("@City", !string.IsNullOrEmpty(patient.City) ? (object)patient.City : System.DBNull.Value);
            SqlParameter _Region = new SqlParameter("@Region", patient.Region);
            SqlParameter _PostCode = new SqlParameter("@PostCode", patient.PostCode);
            SqlParameter _InjuryDate = new SqlParameter("@InjuryDate", patient.InjuryDate);
            SqlParameter _BirthDate = new SqlParameter("@BirthDate", patient.BirthDate.HasValue ? (object)patient.BirthDate.Value : System.DBNull.Value);
            SqlParameter _HomePhone = new SqlParameter("@HomePhone", !string.IsNullOrEmpty(patient.HomePhone) ? (object)patient.HomePhone : System.DBNull.Value);
            SqlParameter _WorkPhone = new SqlParameter("@WorkPhone", !string.IsNullOrEmpty(patient.WorkPhone) ? (object)patient.WorkPhone : System.DBNull.Value);
            SqlParameter _MobilePhone = new SqlParameter("@MobilePhone", !string.IsNullOrEmpty(patient.MobilePhone) ? (object)patient.MobilePhone : System.DBNull.Value);
            SqlParameter _GenderID = new SqlParameter("@GenderID", patient.GenderID);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(patient.Email) ? (object)patient.Email : System.DBNull.Value);
            SqlParameter _HasLegalRep = new SqlParameter("@HasLegalRep", patient.HasLegalRep);
            SqlParameter _SolicitorID = new SqlParameter("@SolicitorID", patient.SolicitorID.HasValue ? (object)patient.SolicitorID.Value : System.DBNull.Value);
            SqlParameter _HasInjuredPartyRepresentative = new SqlParameter("@HasInjuredPartyRepresentative", patient.HasInjuredPartyRepresentative);
            SqlParameter _InjuredID = new SqlParameter("@InjuredID", patient.InjuredID.HasValue ? (object)patient.InjuredID.Value : System.DBNull.Value);
            SqlParameter _PolicyID = new SqlParameter("@PolicyID", patient.PolicyID.HasValue ? (object)patient.PolicyID.Value : System.DBNull.Value);
            SqlParameter _EmploymentID = new SqlParameter("@EmploymentID", patient.EmploymentID.HasValue ? (object)patient.EmploymentID.Value : System.DBNull.Value);
            SqlParameter _PrimaryConditionID = new SqlParameter("@PrimaryConditionID", patient.PrimaryConditionID.HasValue ? (object)patient.PrimaryConditionID.Value : System.DBNull.Value);
            SqlParameter _PolicyOpenDetailID = new SqlParameter("@PolicyOpenDetailID", patient.PolicyOpenDetailID.HasValue ? (object)patient.PolicyOpenDetailID : System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PatientRepositoryProcedures.AddPatient, _Title, _FirstName, _LastName, _Address, _City, _Region, _PostCode, _InjuryDate, _BirthDate, _HomePhone, _WorkPhone, _MobilePhone, _GenderID, _Email, _HasLegalRep, _SolicitorID, _HasInjuredPartyRepresentative, _InjuredID, _PolicyID, _EmploymentID, _PrimaryConditionID, _PolicyOpenDetailID).FirstOrDefault();
        }

        public Patient GetPatientByPatientID(int patientID)
        {
            SqlParameter _PatientID = new SqlParameter("@PatientID", patientID);
            return Context.Database.SqlQuery<Patient>(Global.StoredProcedureConst.PatientRepositoryProcedures.GetPatientByPatientID, _PatientID).SingleOrDefault<Patient>();
        }

        public int UpdatePatientByPatientID(Patient patient)
        {
            SqlParameter[] _patient = {                        
                        new SqlParameter("@PatientID", patient.PatientID),
                        new SqlParameter("@Title", !string.IsNullOrEmpty(patient.Title) ? (object)patient.Title : System.DBNull.Value),
                        new SqlParameter("@FirstName", patient.FirstName),
                        new SqlParameter("@LastName", patient.LastName),
                        new SqlParameter("@Address", patient.Address),
                        new SqlParameter("@City", !string.IsNullOrEmpty(patient.City) ? (object)patient.City : System.DBNull.Value),
                        new SqlParameter("@Region", patient.Region),
                        new SqlParameter("@PostCode", patient.PostCode),
                        new SqlParameter("@InjuryDate", patient.InjuryDate),
                        new SqlParameter("@BirthDate", patient.BirthDate.HasValue ? (object)patient.BirthDate.Value : System.DBNull.Value),
                        new SqlParameter("@HomePhone", !string.IsNullOrEmpty(patient.HomePhone) ? (object)patient.HomePhone : System.DBNull.Value),
                        new SqlParameter("@WorkPhone", !string.IsNullOrEmpty(patient.WorkPhone) ? (object)patient.WorkPhone : System.DBNull.Value),
                        new SqlParameter("@MobilePhone", !string.IsNullOrEmpty(patient.MobilePhone) ? (object)patient.MobilePhone : System.DBNull.Value),
                        new SqlParameter("@GenderID", patient.GenderID),
                        new SqlParameter("@Email", !string.IsNullOrEmpty(patient.Email) ? (object)patient.Email : System.DBNull.Value),
                        new SqlParameter("@HasLegalRep", patient.HasLegalRep),
                        new SqlParameter("@SolicitorID", patient.SolicitorID.HasValue ? (object)patient.SolicitorID.Value : System.DBNull.Value),
                        new SqlParameter("@HasInjuredPartyRepresentative", patient.HasInjuredPartyRepresentative),
                        new SqlParameter("@InjuredID", patient.InjuredID.HasValue ? (object)patient.InjuredID.Value : System.DBNull.Value),
                        new SqlParameter("@SpecialInstructionNotes",  !string.IsNullOrEmpty(patient.SpecialInstructionNotes) ? (object)patient.SpecialInstructionNotes : System.DBNull.Value),
                        new SqlParameter("@PolicyID",  patient.PolicyID.HasValue ? (object)patient.PolicyID.Value : System.DBNull.Value),
                        new SqlParameter("@EmploymentID",  patient.EmploymentID.HasValue ? (object)patient.EmploymentID.Value : System.DBNull.Value),
                        new SqlParameter("@PrimaryConditionID",  patient.PrimaryConditionID.HasValue ? (object)patient.PrimaryConditionID.Value : System.DBNull.Value),
                        new SqlParameter ("@PolicyOpenDetailID", patient.PolicyOpenDetailID.HasValue ? (object)patient.PolicyOpenDetailID : System.DBNull.Value)

                                      };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PatientRepositoryProcedures.UpdatePatientByPatientID, _patient);            
        }
    }
}