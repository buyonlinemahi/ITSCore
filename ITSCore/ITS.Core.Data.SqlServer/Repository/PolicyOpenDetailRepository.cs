  using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class PolicyOpenDetailRepository : BaseRepository<PolicyOpenDetail, ITSDBContext>, IPolicyOpenDetailRepository
    {
        public PolicyOpenDetailRepository(IContextFactory<ITSDBContext> contextFactory) :
             base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddPolicieOpenDetail(PolicyOpenDetail policyOpenDetail)
        {
            SqlParameter _PolicyType = new SqlParameter("@PolicyType", !string.IsNullOrEmpty(policyOpenDetail.PolicyType) ? (object)policyOpenDetail.PolicyType : System.DBNull.Value);
            SqlParameter _TypeCover =  new SqlParameter("@TypeCover", !string.IsNullOrEmpty(policyOpenDetail.TypeCover) ? (object)policyOpenDetail.TypeCover : System.DBNull.Value);
            SqlParameter _PolicyCriteria = new SqlParameter("@PolicyCriteria", !string.IsNullOrEmpty(policyOpenDetail.PolicyCriteria) ? (object)policyOpenDetail.PolicyCriteria : System.DBNull.Value);
            SqlParameter _RehabORProportionate = new SqlParameter("@RehabORProportionate", !string.IsNullOrEmpty(policyOpenDetail.RehabORProportionate) ? (object)policyOpenDetail.RehabORProportionate : System.DBNull.Value);
            SqlParameter _FitforWork = new SqlParameter("@FitforWork",  !string.IsNullOrEmpty(policyOpenDetail.FitforWork) ? (object)policyOpenDetail.FitforWork : System.DBNull.Value);
            SqlParameter _ReInsured = new SqlParameter("@ReInsured", !string.IsNullOrEmpty(policyOpenDetail.ReInsured) ? (object)policyOpenDetail.ReInsured : System.DBNull.Value);
            SqlParameter _ReferenceNo = new SqlParameter("@ReferenceNo", !string.IsNullOrEmpty(policyOpenDetail.ReferenceNo) ? (object)policyOpenDetail.ReferenceNo : System.DBNull.Value);
            SqlParameter _Admitted = new SqlParameter("@Admitted",!string.IsNullOrEmpty(policyOpenDetail.Admitted) ? (object)policyOpenDetail.Admitted : System.DBNull.Value);
            SqlParameter _BenefitDate = new SqlParameter("@OpenBenefitDate", policyOpenDetail.OpenBenefitDate == null ? System.DBNull.Value : (object)policyOpenDetail.OpenBenefitDate);
            SqlParameter _MonthlyValue = new SqlParameter("@OpenMonthlyValue", policyOpenDetail.OpenMonthlyValue);
            SqlParameter _EndBenefitDate = new SqlParameter("@OpenEndBenefitDate", policyOpenDetail.OpenEndBenefitDate == null ? System.DBNull.Value : (object)policyOpenDetail.OpenEndBenefitDate);
            SqlParameter _NameofReinsurer = new SqlParameter("@NameofReinsurer", !string.IsNullOrEmpty(policyOpenDetail.NameofReinsurer) ? (object)policyOpenDetail.NameofReinsurer : System.DBNull.Value);
            SqlParameter _PolicyWording = new SqlParameter("@OpenPolicyWording", !string.IsNullOrEmpty(policyOpenDetail.OpenPolicyWording) ? (object)policyOpenDetail.OpenPolicyWording : System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PolicyOpenDetailProcrdure.AddPolicyOpenDetail,_TypeCover, _PolicyType, _PolicyCriteria, _RehabORProportionate,
                _FitforWork, _ReInsured, _ReferenceNo, _Admitted, _BenefitDate, _MonthlyValue, _EndBenefitDate, _NameofReinsurer, _PolicyWording).FirstOrDefault();
        }
         public int UpdatePolicieOpenDetail(PolicyOpenDetail policyOpenDetail)
        {
            SqlParameter _Id = new SqlParameter("@PolicyOpenDetailID", policyOpenDetail.PolicyOpenDetailID);
            SqlParameter _PolicyType = new SqlParameter("@PolicyType", !string.IsNullOrEmpty(policyOpenDetail.PolicyType) ? (object)policyOpenDetail.PolicyType : System.DBNull.Value);
            SqlParameter _TypeCover = new SqlParameter("@TypeCover", !string.IsNullOrEmpty(policyOpenDetail.TypeCover) ? (object)policyOpenDetail.TypeCover : System.DBNull.Value);
            SqlParameter _PolicyCriteria = new SqlParameter("@PolicyCriteria", !string.IsNullOrEmpty(policyOpenDetail.PolicyCriteria) ? (object)policyOpenDetail.PolicyCriteria : System.DBNull.Value);
            SqlParameter _RehabORProportionate = new SqlParameter("@RehabORProportionate", !string.IsNullOrEmpty(policyOpenDetail.RehabORProportionate) ? (object)policyOpenDetail.RehabORProportionate : System.DBNull.Value);
            SqlParameter _FitforWork = new SqlParameter("@FitforWork", !string.IsNullOrEmpty(policyOpenDetail.FitforWork) ? (object)policyOpenDetail.FitforWork : System.DBNull.Value);
            SqlParameter _ReInsured = new SqlParameter("@ReInsured", !string.IsNullOrEmpty(policyOpenDetail.ReInsured) ? (object)policyOpenDetail.ReInsured : System.DBNull.Value);
            SqlParameter _ReferenceNo = new SqlParameter("@ReferenceNo", !string.IsNullOrEmpty(policyOpenDetail.ReferenceNo) ? (object)policyOpenDetail.ReferenceNo : System.DBNull.Value);
            SqlParameter _Admitted = new SqlParameter("@Admitted", !string.IsNullOrEmpty(policyOpenDetail.Admitted) ? (object)policyOpenDetail.Admitted : System.DBNull.Value);
            SqlParameter _BenefitDate = new SqlParameter("@OpenBenefitDate", policyOpenDetail.OpenBenefitDate == null ? System.DBNull.Value : (object)policyOpenDetail.OpenBenefitDate);
            SqlParameter _MonthlyValue = new SqlParameter("@OpenMonthlyValue", policyOpenDetail.OpenMonthlyValue);
            SqlParameter _EndBenefitDate = new SqlParameter("@OpenEndBenefitDate", policyOpenDetail.OpenEndBenefitDate == null ? System.DBNull.Value : (object)policyOpenDetail.OpenEndBenefitDate);
            SqlParameter _NameofReinsurer = new SqlParameter("@NameofReinsurer", !string.IsNullOrEmpty(policyOpenDetail.NameofReinsurer) ? (object)policyOpenDetail.NameofReinsurer : System.DBNull.Value);
            SqlParameter _PolicyWording = new SqlParameter("@OpenPolicyWording", !string.IsNullOrEmpty(policyOpenDetail.OpenPolicyWording) ? (object)policyOpenDetail.OpenPolicyWording : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PolicyOpenDetailProcrdure.UpdatePolicyOpenDetail, _PolicyType,_TypeCover, _PolicyCriteria,
                _RehabORProportionate, _FitforWork, _ReInsured, _ReferenceNo, _Admitted, _BenefitDate, _MonthlyValue, _EndBenefitDate, _NameofReinsurer, _PolicyWording, _Id);
        }


         public PolicyOpenDetail GetPolicyOpenDetailById(int _openDetailID)
        {
            SqlParameter _OpenID = new SqlParameter("@PolicyOpenDetailID", _openDetailID);
            return Context.Database.SqlQuery<PolicyOpenDetail>(Global.StoredProcedureConst.PolicyOpenDetailProcrdure.GetPolicyOpenDetailById, _OpenID).FirstOrDefault();
        }

    }
}
