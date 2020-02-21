using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseWorkflowPatientReferrerProjectRepository : BaseRepository<CaseWorkflowPatientReferrerProject, ITSDBContext>, ICaseWorkflowPatientReferrerProjectRepository
    {
        public CaseWorkflowPatientReferrerProjectRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(int workflowID, int treatmentCategoryID, int skip, int take)
        {
            SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", workflowID);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<CaseWorkflowPatientReferrerProject>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID, workflowIDParam, treatmentCategoryIDParam, SkipParam, TakeParam);

        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseWorkflowPatientReferrerProjectsByWorkflowID(string workflowID, int skip, int take)
        {
            SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", workflowID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CaseWorkflowPatientReferrerProject>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseWorkflowPatientReferrerProjectByWorkflowID, workflowIDParam, SkipParam, TakeParam);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralWorkflowPatientReferrerProjects(int skip, int take)
        {
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CaseWorkflowPatientReferrerProject>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseReferralWorkflowPatientReferrerProjects, SkipParam, TakeParam).ToList();
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            SqlParameter SkipParam = new SqlParameter("@Skip", skip);
            SqlParameter TakeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CaseWorkflowPatientReferrerProject>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID, treatmentCategoryIDParam, SkipParam, TakeParam);
        }

        public int GetCaseReferralWorkflowPatientReferrerProjectsCount()
        {
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseReferralWorkflowPatientReferrerProjectsCount).SingleOrDefault();
        }

        public int GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount, treatmentCategoryIDParam).SingleOrDefault();
        }


        public int GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(string workflowID)
        {
            SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", workflowID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount, workflowIDParam).SingleOrDefault();
        }

        public int GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(int workflowID, int treatmentCategoryID)
        {
            SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", workflowID);
            SqlParameter treatmentCategoryIDParam = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.CaseWorkflowPatientReferrerPrrojectProcedure.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount, workflowIDParam, treatmentCategoryIDParam).SingleOrDefault();
        }
    }
}

