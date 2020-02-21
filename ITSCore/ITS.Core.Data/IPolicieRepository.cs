using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface IPolicieRepository : IBaseRepository<Policie>
    {
        Policie GetPolicyByPolicyID(int _policyId);
        int AddPolicie(Policie policie);
        int UpdatePolicie(Policie policie);
    }
}
