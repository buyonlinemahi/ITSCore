using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class InjuredRepresentativeOptionImpl : IInjuredRepresentativeOption
    {
        private readonly IInjuredRepresentativeOptionRepository _iInjuredRepresentativeOptionRepository;
        public InjuredRepresentativeOptionImpl(IInjuredRepresentativeOptionRepository iInjuredRepresentativeOptionRepository)
        {
            _iInjuredRepresentativeOptionRepository = iInjuredRepresentativeOptionRepository;
        }
        public IEnumerable<InjuredRepresentativeOption> GetAllInjuredRepresentativeOption()
        {
            return _iInjuredRepresentativeOptionRepository.GetAll();
        }
    }
}
