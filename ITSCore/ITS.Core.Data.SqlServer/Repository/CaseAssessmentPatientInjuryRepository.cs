using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentPatientInjuryRepository : BaseRepository<ITS.Core.BL.Model.CaseAssessmentPatientInjuryBL, ITSDBContext>, ICaseAssessmentPatientInjuryRepository
    {
        public CaseAssessmentPatientInjuryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }



        public int AddCaseAssessmentPatientInjury(CaseAssessmentPatientInjury caseAssessmentPatientInjury)
        {
            SqlParameter _CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentPatientInjury.CaseAssessmentDetailID);
            SqlParameter _AffectedArea = new SqlParameter("@AffectedArea", caseAssessmentPatientInjury.AffectedArea == null ? "" :caseAssessmentPatientInjury.AffectedArea);
            SqlParameter _Score = new SqlParameter("@Score", caseAssessmentPatientInjury.Score);
            SqlParameter _Restriction = new SqlParameter("@Restriction", caseAssessmentPatientInjury.Restriction == null ? "" : caseAssessmentPatientInjury.Restriction);
            SqlParameter _SymptomDescriptionID = new SqlParameter("@SymptomDescriptionID", caseAssessmentPatientInjury.SymptomDescriptionID);
            SqlParameter _StrengthTestingID = new SqlParameter("@StrengthTestingID", caseAssessmentPatientInjury.StrengthTestingID);
            SqlParameter _AffectedAreaID = new SqlParameter("@AffectedAreaID", caseAssessmentPatientInjury.AffectedAreaID);
            SqlParameter _RestrictionRangeID = new SqlParameter("@RestrictionRangeID", caseAssessmentPatientInjury.RestrictionRangeID);
            SqlParameter _OtherSymptomDesciption = new SqlParameter("@OtherSymptomDesciption", caseAssessmentPatientInjury.OtherSymptomDesciption == null ? "" : caseAssessmentPatientInjury.OtherSymptomDesciption);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientInjuryRepositoryProcedures.AddCaseAssessmentPatientInjury, _CaseAssessmentDetailID, _AffectedArea, _Score, _Restriction, _SymptomDescriptionID, _StrengthTestingID, _AffectedAreaID, _RestrictionRangeID, _OtherSymptomDesciption);

        }

        public int UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(CaseAssessmentPatientInjury caseAssessmentPatientInjury)
        {
            SqlParameter _caseAssessmentPatientInjuryID = new SqlParameter("@CaseAssessmentPatientInjuryID", caseAssessmentPatientInjury.CaseAssessmentPatientInjuryID);
            SqlParameter _CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentPatientInjury.CaseAssessmentDetailID);
            SqlParameter _AffectedArea = new SqlParameter("@AffectedArea", caseAssessmentPatientInjury.AffectedArea == null ? "" : caseAssessmentPatientInjury.AffectedArea);
            SqlParameter _Score = new SqlParameter("@Score", caseAssessmentPatientInjury.Score);
            SqlParameter _Restriction = new SqlParameter("@Restriction", caseAssessmentPatientInjury.Restriction == null ? "" : caseAssessmentPatientInjury.Restriction);
            SqlParameter _SymptomDescriptionID = new SqlParameter("@SymptomDescriptionID", caseAssessmentPatientInjury.SymptomDescriptionID);
            SqlParameter _StrengthTestingID = new SqlParameter("@StrengthTestingID", caseAssessmentPatientInjury.StrengthTestingID);
            SqlParameter _AffectedAreaID = new SqlParameter("@AffectedAreaID", caseAssessmentPatientInjury.AffectedAreaID);
            SqlParameter _RestrictionRangeID = new SqlParameter("@RestrictionRangeID", caseAssessmentPatientInjury.RestrictionRangeID);
            SqlParameter _OtherSymptomDesciption = new SqlParameter("@OtherSymptomDesciption", caseAssessmentPatientInjury.OtherSymptomDesciption == null ? "" : caseAssessmentPatientInjury.OtherSymptomDesciption);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientInjuryRepositoryProcedures.UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID, _caseAssessmentPatientInjuryID, _CaseAssessmentDetailID, _AffectedArea, _Score, _Restriction, _SymptomDescriptionID, _StrengthTestingID, _AffectedAreaID, _RestrictionRangeID,_OtherSymptomDesciption);
        }

        public IEnumerable<CaseAssessmentPatientInjury> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(int caseAssessmentDetailID)
        {
            return
                 Context.Database.SqlQuery<CaseAssessmentPatientInjury>(
                     Global.StoredProcedureConst.CaseAssessmentPatientInjuryRepositoryProcedures.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID, new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetailID));
        }


        public System.Collections.Generic.IEnumerable<ReportModels.CaseAssessmentPatientInjuryAndCaseAssessment> GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailIDReports(int caseAssessmentDetailID)
        {
            return
                 Context.Database.SqlQuery<ReportModels.CaseAssessmentPatientInjuryAndCaseAssessment>(
                     Global.StoredProcedureConst.CaseAssessmentPatientInjuryRepositoryProcedures.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailIDReports, new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetailID));
        }
        public void DeleteCaseAssessmentPatientInjuryByCaseAssessmentDetailID(int caseAssessmentDetailID)
        {
            SqlParameter _caseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetailID);
            Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientInjuryRepositoryProcedures.DeleteCaseAssessmentPatientInjuryByCaseAssessmentDetailID, _caseAssessmentDetailID);
        }
    }
}
