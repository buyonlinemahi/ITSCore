using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class ServiceLevelAgreementImpl : IServiceLevelAgreement
    {
        private readonly IServiceLevelAgreementRepository _serviceLevelAgreementRepository;

        public ServiceLevelAgreementImpl(IServiceLevelAgreementRepository serviceLevelAgreementRepository)
        {
            _serviceLevelAgreementRepository = serviceLevelAgreementRepository;
        }




        public IEnumerable<ServiceLevelAgreement> GetAllServiceLevelAgreement()
        {
            return _serviceLevelAgreementRepository.GetAll();
        }
    }
}
