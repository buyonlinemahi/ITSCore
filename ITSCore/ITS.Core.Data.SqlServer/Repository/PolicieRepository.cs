using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;
namespace ITS.Core.Data.SqlServer.Repository
{
    public class PolicieRepository : BaseRepository<Policie, ITSDBContext>, IPolicieRepository
    {
        public PolicieRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public Policie GetPolicyByPolicyID(int _policyId)
        {
            SqlParameter policyId = new SqlParameter("@PolicyID", _policyId);
            return Context.Database.SqlQuery<Policie>(Global.StoredProcedureConst.PolicieRepositoryProcedure.GetPolicyByPolicyId, policyId).FirstOrDefault();
        }

        public int AddPolicie(Policie policie)
        {
            SqlParameter _PolicyTypeId = new SqlParameter("@PolicyTypeId", policie.PolicyTypeId == null ? System.DBNull.Value : (object)policie.PolicyTypeId);
            SqlParameter _TypeCoverId = new SqlParameter("@TypeCoverId", policie.TypeCoverId == null ? System.DBNull.Value : (object)policie.TypeCoverId);
            SqlParameter _PolicyCriteriaId = new SqlParameter("@PolicyCriteriaId", policie.PolicyCriteriaId == null ? System.DBNull.Value :  (object)policie.PolicyCriteriaId);
            SqlParameter _RehabProportionateBenefit = new SqlParameter("@RehabProportionateBenefit", policie.RehabProportionateBenefit == null ? System.DBNull.Value :  (object)policie.RehabProportionateBenefit);
            SqlParameter _FitForWorkId = new SqlParameter("@FitForWorkId", policie.FitForWorkId == null ? System.DBNull.Value :  (object)policie.FitForWorkId);
            SqlParameter _ReInsuredId = new SqlParameter("@ReInsuredId", policie.ReInsuredId == null ? System.DBNull.Value :  (object)policie.ReInsuredId);
            SqlParameter _ReferenceNo = new SqlParameter("@ReferenceNo", !string.IsNullOrEmpty(policie.ReferenceNo) ? (object)policie.ReferenceNo : System.DBNull.Value);
            SqlParameter _AdmittedId = new SqlParameter("@AdmittedId", policie.AdmittedId == null ? System.DBNull.Value :  (object)policie.AdmittedId);
            SqlParameter _BenefitDate = new SqlParameter("@BenefitDate", policie.BenefitDate == null ? System.DBNull.Value : (object)policie.BenefitDate);
            SqlParameter _MonthlyValue = new SqlParameter("@MonthlyValue",policie.MonthlyValue);
            SqlParameter _WeeklyValue = new SqlParameter("@WeeklyValue", policie.WeeklyValue);
            SqlParameter _EndBenefitDate = new SqlParameter("@EndBenefitDate",  policie.EndBenefitDate == null ? System.DBNull.Value : (object)policie.EndBenefitDate);
            SqlParameter _NameOfReinsurerID = new SqlParameter("@NameOfReinsurerID", policie.NameOfReinsurerID == null ? System.DBNull.Value : (object)policie.NameOfReinsurerID);
            SqlParameter _PolicyWording = new SqlParameter("@PolicyWording", !string.IsNullOrEmpty(policie.PolicyWording) ? (object)policie.PolicyWording : System.DBNull.Value);


            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PolicieRepositoryProcedure.AddPolicie, _PolicyTypeId, _TypeCoverId, _PolicyCriteriaId, _RehabProportionateBenefit, _FitForWorkId, _ReInsuredId, _ReferenceNo, _AdmittedId, _BenefitDate, _MonthlyValue, _WeeklyValue, _EndBenefitDate, _NameOfReinsurerID, _PolicyWording).FirstOrDefault();
        }

        public int UpdatePolicie(Policie policie)
        {
            SqlParameter _PolicyId = new SqlParameter("@PolicyId", policie.PolicyID);
            SqlParameter _PolicyTypeId = new SqlParameter("@PolicyTypeId", policie.PolicyTypeId == null ? System.DBNull.Value : (object)policie.PolicyTypeId);
            SqlParameter _TypeCoverId = new SqlParameter("@TypeCoverId", policie.TypeCoverId == null ? System.DBNull.Value : (object)policie.TypeCoverId);
            SqlParameter _PolicyCriteriaId = new SqlParameter("@PolicyCriteriaId", policie.PolicyCriteriaId == null ? System.DBNull.Value : (object)policie.PolicyCriteriaId);
            SqlParameter _RehabProportionateBenefit = new SqlParameter("@RehabProportionateBenefit", policie.RehabProportionateBenefit == null ? System.DBNull.Value : (object)policie.RehabProportionateBenefit);
            SqlParameter _FitForWorkId = new SqlParameter("@FitForWorkId", policie.FitForWorkId == null ? System.DBNull.Value : (object)policie.FitForWorkId);
            SqlParameter _ReInsuredId = new SqlParameter("@ReInsuredId", policie.ReInsuredId == null ? System.DBNull.Value : (object)policie.ReInsuredId);
            SqlParameter _ReferenceNo = new SqlParameter("@ReferenceNo", !string.IsNullOrEmpty(policie.ReferenceNo) ? (object)policie.ReferenceNo : System.DBNull.Value);
            SqlParameter _AdmittedId = new SqlParameter("@AdmittedId", policie.AdmittedId == null ? System.DBNull.Value : (object)policie.AdmittedId);
            SqlParameter _BenefitDate = new SqlParameter("@BenefitDate", policie.BenefitDate == null ? System.DBNull.Value : (object)policie.BenefitDate);
            SqlParameter _MonthlyValue = new SqlParameter("@MonthlyValue", policie.MonthlyValue);
            SqlParameter _WeeklyValue = new SqlParameter("@WeeklyValue", policie.WeeklyValue);
            SqlParameter _EndBenefitDate = new SqlParameter("@EndBenefitDate", policie.EndBenefitDate == null ? System.DBNull.Value : (object)policie.EndBenefitDate);
            SqlParameter _NameOfReinsurerID = new SqlParameter("@NameOfReinsurerID", policie.NameOfReinsurerID == null ? System.DBNull.Value : (object)policie.NameOfReinsurerID);
            SqlParameter _PolicyWording = new SqlParameter("@PolicyWording", !string.IsNullOrEmpty(policie.PolicyWording) ? (object)policie.PolicyWording : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PolicieRepositoryProcedure.UpdatePolicie, _PolicyTypeId, _TypeCoverId, _PolicyCriteriaId, _RehabProportionateBenefit, _FitForWorkId, _ReInsuredId, _ReferenceNo, _AdmittedId, _BenefitDate, _MonthlyValue, _WeeklyValue, _EndBenefitDate, _NameOfReinsurerID, _PolicyWording, _PolicyId);
        }
    }
}
