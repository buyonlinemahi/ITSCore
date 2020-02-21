using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentProposedTreatmentMethodRepository : BaseRepository<CaseAssessmentProposedTreatmentMethod, ITSDBContext>, ICaseAssessmentProposedTreatmentMethodRepository
    {
        public CaseAssessmentProposedTreatmentMethodRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessmentProposedTreatmentMethod(int caseID, int proposedTreatmentMethodID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter ProposedTreatmentMethodID = new SqlParameter("@ProposedTreatmentMethodID", proposedTreatmentMethodID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodRepositoryProcedure.AddCaseAssessmentProposedTreatmentMethod, CaseID, ProposedTreatmentMethodID);
        }

        public int DeleteCaseAssessmentProposedTreatmentMethodByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodRepositoryProcedure.DeleteCaseAssessmentProposedTreatmentMethodByCaseID, CaseID);
        }

        public int UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID(int caseID, int AssessmentServiceID, System.DateTime AssessmentDate)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", AssessmentServiceID);
            SqlParameter _AssessmentDate = new SqlParameter("@AssessmentDate", AssessmentDate);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodRepositoryProcedure.UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID, _CaseID, _AssessmentServiceID, _AssessmentDate);
        }

        public System.Collections.Generic.IEnumerable<CaseAssessmentProposedTreatmentMethod> GetCaseAssessmentProposedTreatmentMethodsByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);

            return Context.Database.SqlQuery<CaseAssessmentProposedTreatmentMethod>(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodRepositoryProcedure.GetCaseAssessmentProposedTreatmentMethodsByCaseID, CaseID);
        }

        public System.Collections.Generic.IEnumerable<ReportModels.CaseAssessmentProposedTreatmentMethodsAndValues> GetCaseAssessmentProposedTreatmentMethodsAndValuesByCaseID(int caseID, string reportType)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter ReportType = new SqlParameter("@ReportType", reportType);

            return Context.Database.SqlQuery<ReportModels.CaseAssessmentProposedTreatmentMethodsAndValues>(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodRepositoryProcedure.GetCaseAssessmentProposedTreatmentMethodsAndValuesByCaseID, CaseID, ReportType);
        }

    }
}