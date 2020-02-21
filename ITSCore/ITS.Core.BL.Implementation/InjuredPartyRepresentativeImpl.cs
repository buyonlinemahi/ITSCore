using ITS.Core.Data;
using DLModel = ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class InjuredPartyRepresentativeImpl : IInjuredPartyRepresentative
    {
        private readonly IInjuredPartyRepresentativeRepository _injuredPartyRepresentativeRepository;
        public InjuredPartyRepresentativeImpl(IInjuredPartyRepresentativeRepository injuredPartyRepresentativeRepository)
        {
            _injuredPartyRepresentativeRepository = injuredPartyRepresentativeRepository;
        }

        public int AddInjuredPartyRepresentative(DLModel.InjuredPartyRepresentative objInjuredPartyRepresentative)
        {
            return _injuredPartyRepresentativeRepository.AdditionInjuredPartyRepresentative(objInjuredPartyRepresentative);
        }
        public int UpdateInjuredPartyRepresentative(DLModel.InjuredPartyRepresentative objInjuredPartyRepresentative)
        {
            return _injuredPartyRepresentativeRepository.UpdationInjuredPartyRepresentative(objInjuredPartyRepresentative);
        }

        public DLModel.InjuredPartyRepresentative GetInjuredPartyRepresentativesByReferralID(int referralID)
        {
            return _injuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByReferralID(referralID);
        }


        public DLModel.InjuredPartyRepresentative GetInjuredPartyRepresentativesByID(int injuredID)
        {
            return _injuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByID(injuredID);
        }

    }
}
