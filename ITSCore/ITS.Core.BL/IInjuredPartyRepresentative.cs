using DLModel = ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface IInjuredPartyRepresentative
    {
        int AddInjuredPartyRepresentative(DLModel.InjuredPartyRepresentative objInjuredPartyRepresentative);
        int UpdateInjuredPartyRepresentative(DLModel.InjuredPartyRepresentative objInjuredPartyRepresentative);
        DLModel.InjuredPartyRepresentative GetInjuredPartyRepresentativesByReferralID(int referralID);
        DLModel.InjuredPartyRepresentative GetInjuredPartyRepresentativesByID(int injuredID);
    }
}
