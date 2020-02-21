using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;


namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentCustomRepository : BaseRepository<CaseAssessmentCustom, ITSDBContext>, ICaseAssessmentCustomRepository
    {
        public CaseAssessmentCustomRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public int AddCaseAssessmentCustom(CaseAssessmentCustom caseAssessmentCustom)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentCustom.CaseID);
            SqlParameter _isAccepted = new SqlParameter("@isAccepted", caseAssessmentCustom.isAccepted);
            SqlParameter _Message = new SqlParameter("@Message", caseAssessmentCustom.Message);
            SqlParameter _IsFurtherTreatment = new SqlParameter("@IsFurtherTreatment", caseAssessmentCustom.IsFurtherTreatment);
           

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.AddCaseAssessmentCustom, _CaseID,_Message,_IsFurtherTreatment, _isAccepted
                );
        }

        public int UpdateCaseAssessmentCustom(CaseAssessmentCustom caseAssessmentCustom)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentCustom.CaseID);
            SqlParameter _IsFurtherTreatment = new SqlParameter("@IsFurtherTreatment", caseAssessmentCustom.IsFurtherTreatment);

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.UpdateCaseAssessmentCustom, _CaseID,_IsFurtherTreatment
                );
        }

        public int UpdateCaseRiewAssessmentMessageCustom(CaseAssessmentCustom caseAssessmentCustom)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentCustom.CaseID);
            SqlParameter _ReviewAssessmentMessage = new SqlParameter("@ReviewAssessmentMessage", caseAssessmentCustom.ReviewAssessmentMessage);

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.UpdateCaseRiewAssessmentMessageCustom, _CaseID, _ReviewAssessmentMessage
                );
        }

        public int UpdateCaseInitialAssessmentMessageCustom(CaseAssessmentCustom caseAssessmentCustom)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentCustom.CaseID);
            SqlParameter _Message = new SqlParameter("@Message", caseAssessmentCustom.Message);

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.UpdateCaseInitialAssessmentMessageCustom, _CaseID, _Message
                );
        }

        public int UpdateCaseFinalAssessmentMessageCustom(CaseAssessmentCustom caseAssessmentCustom)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessmentCustom.CaseID);
            SqlParameter _FinalAssessmentMessage = new SqlParameter("@FinalAssessmentMessage", caseAssessmentCustom.FinalAssessmentMessage);

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.UpdateCaseFinalAssessmentMessageCustom, _CaseID, _FinalAssessmentMessage
                );
        }

        public CaseAssessmentCustom GetCaseAssessmentCustomByCaseID(int CaseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<CaseAssessmentCustom>(Global.StoredProcedureConst.CaseAssessmentCustomRepositoryProcedure.GetCaseAssessmentCustom,_CaseID).SingleOrDefault();
        }
    }
}
