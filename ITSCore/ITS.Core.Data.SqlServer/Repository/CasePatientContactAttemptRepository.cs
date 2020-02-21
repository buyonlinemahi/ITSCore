using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CasePatientContactAttemptRepository : BaseRepository<CasePatientContactAttempt, ITSDBContext>, ICasePatientContactAttemptRepository
    {
        public CasePatientContactAttemptRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddPatientContactAttempt(CasePatientContactAttempt casePatientContactAttempt)
        {
            SqlParameter _patientID = new SqlParameter("@PatientID", casePatientContactAttempt.PatientID);
            SqlParameter _caseID = new SqlParameter("@CaseID", casePatientContactAttempt.CaseID);
            SqlParameter _contactAttemptDate = new SqlParameter("@ContactAttemptDate", casePatientContactAttempt.ContactAttemptDate);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CasePatientContactAttemptRepositoryProcedures.AddPatientContactAttempt, _patientID, _caseID, _contactAttemptDate).SingleOrDefault();
        }


        public IEnumerable<CasePatientContactAttempt> GetPatientContactAttemptsByCaseID(int caseID)
        {

            var _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientContactAttempt>(Global.StoredProcedureConst.CasePatientContactAttemptRepositoryProcedures.GetPatientContactAttemptsByCaseID, _caseID);
        }

        public int DeletePatientContactAttemptByID(int CasePatientContactAttemptID)
        {
            SqlParameter _CasePatientContactAttemptID = new SqlParameter("@CasePatientContactAttemptID", CasePatientContactAttemptID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CasePatientContactAttemptRepositoryProcedures.DeletePatientContactAttemptByID, _CasePatientContactAttemptID);
        }

        
    }
}
