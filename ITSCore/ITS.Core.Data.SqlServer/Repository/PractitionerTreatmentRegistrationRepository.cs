using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PractitionerTreatmentRegistrationRepository : BaseRepository<PractitionerTreatmentRegistration, ITSDBContext>, IPractitionerTreatmentRegistrationRepository
    {

        public PractitionerTreatmentRegistrationRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<SupplierPractitionerTreatmentRegistration> GetSupplierPractitionerTreatmentRegistrationsBySupplierID(int supplierID)
        {
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", supplierID);
            return Context.Database.SqlQuery<SupplierPractitionerTreatmentRegistration>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GettSupplierPractitionerTreatmenRegistrationsBySupplierID, _SupplierID);
        }


        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier(string searchKey)
        {
            SqlParameter _practitionerName = new SqlParameter("@PractitionerName", searchKey);
            return Context.Database.SqlQuery<PractitionerTreatmentRegistration>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier, _practitionerName);
        }

        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName(string treatmentCategoryName, int skip, int take)
        {
            return Context.Database.SqlQuery<PractitionerTreatmentRegistration>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName,
                        new SqlParameter("@TreatmentCategoryName", treatmentCategoryName),
                        new SqlParameter("@Skip", skip),
                        new SqlParameter("@Take", take));
        }

        public int GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount(string treatmentCategoryName)
        {
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount,
                        new SqlParameter("@TreatmentCategoryName", treatmentCategoryName)).SingleOrDefault();

        }



        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerName(string practitionerName, int skip, int take)
        {
            return Context.Database.SqlQuery<PractitionerTreatmentRegistration>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GetPractitionerTreatmentRegistrationsLikePractitionerName,
                new SqlParameter("@PractitionerName", practitionerName),
                new SqlParameter("@Skip", skip),
                new SqlParameter("@Take", take));
        }

        public int GetPractitionerTreatmentRegistrationsLikePractitionerNameCount(string practitionerName)
        {
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.PractitionerTreatmentRegistrationRepositoryProcedure.GetPractitionerTreatmentRegistrationsLikePractitionerNameCount,
                         new SqlParameter("@PractitionerName", practitionerName)).SingleOrDefault();
        }
    }
}
