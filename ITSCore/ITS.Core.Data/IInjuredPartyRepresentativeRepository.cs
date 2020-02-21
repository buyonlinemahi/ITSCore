using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface IInjuredPartyRepresentativeRepository : IBaseRepository<InjuredPartyRepresentative>
    {
        int AdditionInjuredPartyRepresentative(InjuredPartyRepresentative objInjuredPartyRepresentative);
        int UpdationInjuredPartyRepresentative(InjuredPartyRepresentative objInjuredPartyRepresentative);
        InjuredPartyRepresentative GetInjuredPartyRepresentativesByReferralID(int ReferralID);

        InjuredPartyRepresentative GetInjuredPartyRepresentativesByID(int injuredID);
    }
}
