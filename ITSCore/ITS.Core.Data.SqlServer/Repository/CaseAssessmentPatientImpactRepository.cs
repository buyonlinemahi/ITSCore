using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data.SqlServer.Repository
{

    public class CaseAssessmentPatientImpactRepository : BaseRepository<CaseAssessmentPatientImpact, ITSDBContext>, ICaseAssessmentPatientImpactRepository
    {
        public CaseAssessmentPatientImpactRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessmentPatientImpact(CaseAssessmentPatientImpact caseAssessmentPatientImpact)
        {

            SqlParameter PatientImpactID = new SqlParameter("@PatientImpactID", caseAssessmentPatientImpact.PatientImpactID);
            SqlParameter PatientImpactValueID = new SqlParameter("@PatientImpactValueID", caseAssessmentPatientImpact.PatientImpactValueID);
            SqlParameter Comment = new SqlParameter("@Comment",!string.IsNullOrEmpty(caseAssessmentPatientImpact.Comment) ? (object)caseAssessmentPatientImpact.Comment : System.DBNull.Value); 
            SqlParameter CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentPatientImpact.CaseAssessmentDetailID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.AddCaseAssessmentPatientImpact, PatientImpactID, PatientImpactValueID, Comment, CaseAssessmentDetailID);

        }

        public int UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(CaseAssessmentPatientImpact caseAssessmentPatientImpact)
        {

            SqlParameter CaseAssessmentPatientImpactID = new SqlParameter("@CaseAssessmentPatientImpactID", caseAssessmentPatientImpact.CaseAssessmentPatientImpactID);
            SqlParameter PatientImpactID = new SqlParameter("@PatientImpactID", caseAssessmentPatientImpact.PatientImpactID);
            SqlParameter PatientImpactValueID = new SqlParameter("@PatientImpactValueID", caseAssessmentPatientImpact.PatientImpactValueID);
            SqlParameter Comment = new SqlParameter("@Comment", !string.IsNullOrEmpty(caseAssessmentPatientImpact.Comment) ? (object)caseAssessmentPatientImpact.Comment : System.DBNull.Value); 
            SqlParameter CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentPatientImpact.CaseAssessmentDetailID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID, CaseAssessmentPatientImpactID, PatientImpactID, PatientImpactValueID, Comment, CaseAssessmentDetailID);

        }

        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(int CaseAssessmentDetailID)
        {
            SqlParameter _CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", CaseAssessmentDetailID);
            return Context.Database.SqlQuery<CaseAssessmentPatientImpact>(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID, _CaseAssessmentDetailID);

        }
        
      

        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactID(int patientImpactID)
        {
            SqlParameter PatientImpactID = new SqlParameter("@PatientImpactID", patientImpactID);
            return Context.Database.SqlQuery<CaseAssessmentPatientImpact>(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.GetCaseAssessmentPatientImpactsByPatientImpactID, PatientImpactID);
        }

        public IEnumerable<CaseAssessmentPatientImpact> GetCaseAssessmentPatientImpactsByPatientImpactValueID(int patientImpactValueID)
        {
            SqlParameter PatientImpactValueID = new SqlParameter("@PatientImpactValueID", patientImpactValueID);
            return Context.Database.SqlQuery<CaseAssessmentPatientImpact>(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.GetCaseAssessmentPatientImpactsByPatientImpactValueID, PatientImpactValueID);
        }

        public IEnumerable<ReportModels.CaseAssessmentPatientImpactAndCaseAssessment> GetCaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID(int CaseAssessmentDetailID)
        {
            SqlParameter _CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", CaseAssessmentDetailID);
            return Context.Database.SqlQuery<ReportModels.CaseAssessmentPatientImpactAndCaseAssessment>(Global.StoredProcedureConst.CaseAssessmentPatientImpactRepositoryProcedure.GetCaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID, _CaseAssessmentDetailID);

        }







    }
}