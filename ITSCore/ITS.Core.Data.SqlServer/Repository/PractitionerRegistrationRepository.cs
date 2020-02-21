using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PractitionerRegistrationRepository : BaseRepository<PractitionerRegistration, ITSDBContext>, IPractitionerRegistrationRepository
    {
        public PractitionerRegistrationRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public int AddPractitionerRegistration(PractitionerRegistration practitionerRegistration)
        {
            SqlParameter _PractitionerID = new SqlParameter("@PractitionerID", practitionerRegistration.PractitionerID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", practitionerRegistration.TreatmentCategoryID);
            SqlParameter _RegistrationTypeID = new SqlParameter("@RegistrationTypeID", (object)practitionerRegistration.RegistrationTypeID ?? System.DBNull.Value);
            SqlParameter _RegistrationNumber = new SqlParameter("@RegistrationNumber", practitionerRegistration.RegistrationNumber);
            SqlParameter _Qualification = new SqlParameter("@Qualification", practitionerRegistration.Qualification);
            SqlParameter _QualificationDate = new SqlParameter("@QualificationDate", practitionerRegistration.QualificationDate);
            SqlParameter _ExpiryDate = new SqlParameter("@ExpiryDate", practitionerRegistration.ExpiryDate);
            SqlParameter _YearsQualified = new SqlParameter("@YearsQualified", practitionerRegistration.YearsQualified);


            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.AddPractitionerRegistration, _PractitionerID, _TreatmentCategoryID, _RegistrationTypeID, _RegistrationNumber, _Qualification, _QualificationDate, _ExpiryDate, _YearsQualified).SingleOrDefault();
        }

        public int DeletePractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID)
        {

            SqlParameter _practitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", practitionerRegistrationID);


            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.DeletePractitionerRegistrationByPractitionerRegistrationID, _practitionerRegistrationID);
        }

        public PractitionerRegistration GetPractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID)
        {
            SqlParameter _practitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", practitionerRegistrationID);
            return Context.Database.SqlQuery<PractitionerRegistration>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.GetPractitionerRegistrationByPractitionerRegistrationID, _practitionerRegistrationID).SingleOrDefault();
        }

        public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByPractitionerID(int practitionerID)
        {
            SqlParameter _practitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.SqlQuery<PractitionerRegistration>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.GetPractitionerRegistrationsByPractitionerID, _practitionerID);
        }

        public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByTreatmentCategoryID(int treatmentCategoryID)
        {
            SqlParameter _treatmentCategoryID = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return Context.Database.SqlQuery<PractitionerRegistration>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.GetPractitionerRegistrationsByTreatmentCategoryID, _treatmentCategoryID);
        }

        public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByRegistrationTypeID(int registrationTypeID)
        {
            SqlParameter _registrationTypeID = new SqlParameter("@RegistrationTypeID", (object)registrationTypeID ?? System.DBNull.Value);
            return Context.Database.SqlQuery<PractitionerRegistration>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.GetPractitionerRegistrationsByRegistrationTypeID, _registrationTypeID);

        }

        public int UpdatePractitionerRegistrationByPractitionerRegistrationID(PractitionerRegistration practitionerRegistration)
        {
            SqlParameter _PractitionerID = new SqlParameter("@PractitionerID", practitionerRegistration.PractitionerID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", practitionerRegistration.TreatmentCategoryID);
            SqlParameter _RegistrationTypeID = new SqlParameter("@RegistrationTypeID", (object)practitionerRegistration.RegistrationTypeID ?? System.DBNull.Value);
            SqlParameter _RegistrationNumber = new SqlParameter("@RegistrationNumber", practitionerRegistration.RegistrationNumber);
            SqlParameter _Qualification = new SqlParameter("@Qualification", practitionerRegistration.Qualification);
            SqlParameter _QualificationDate = new SqlParameter("@QualificationDate", practitionerRegistration.QualificationDate);
            SqlParameter _ExpiryDate = new SqlParameter("@ExpiryDate", practitionerRegistration.ExpiryDate);
            SqlParameter _YearsQualified = new SqlParameter("@YearsQualified", practitionerRegistration.YearsQualified);
            SqlParameter _PractitionerRegistrationID = new SqlParameter("@PractitionerRegistrationID", practitionerRegistration.PractitionerRegistrationID);


            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.UpdatePractitionerRegistrationByPractitionerRegistrationID, _PractitionerID, _TreatmentCategoryID, _RegistrationTypeID, _RegistrationNumber, _Qualification, _QualificationDate, _ExpiryDate, _YearsQualified, _PractitionerRegistrationID);
        }


        public PractitionerRegistration GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID(PractitionerRegistration practitionerRegistration)
        {
            SqlParameter _PractitionerID = new SqlParameter("@PractitionerID", practitionerRegistration.PractitionerID);
            SqlParameter _TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", practitionerRegistration.TreatmentCategoryID);
            SqlParameter _RegistrationTypeID = new SqlParameter("@RegistrationTypeID", (object)practitionerRegistration.RegistrationTypeID ?? System.DBNull.Value);

            return Context.Database.SqlQuery<PractitionerRegistration>(Global.StoredProcedureConst.PractitionerRegistrationRepositoryProcedures.GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID, _PractitionerID, _TreatmentCategoryID, _RegistrationTypeID).SingleOrDefault();

        }
        
    }
}
