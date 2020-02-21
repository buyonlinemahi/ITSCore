using Core.Base.Data;
using ITS.Core.Data.Model;
namespace ITS.Core.Data
{
    public interface IPolicyOpenDetailRepository : IBaseRepository<PolicyOpenDetail>
    {

        
        int AddPolicieOpenDetail(PolicyOpenDetail policyOpenDetail);
        int UpdatePolicieOpenDetail(PolicyOpenDetail policyOpenDetail);
        PolicyOpenDetail GetPolicyOpenDetailById(int _openDetailID);
    }
}
