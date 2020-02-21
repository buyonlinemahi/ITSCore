using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class ProposedTreatmentMethodImpl : IProposedTreatmentMethod
    {
        private readonly IProposedTreatmentMethodRepository _proposedTreatmentMethodRepository;

        public ProposedTreatmentMethodImpl(IProposedTreatmentMethodRepository proposedTreatmentMethodRepository)
        {
            _proposedTreatmentMethodRepository = proposedTreatmentMethodRepository;
        }

        public IEnumerable<ProposedTreatmentMethod> GetAllProposedTreatmentMethod()
        {
            return _proposedTreatmentMethodRepository.GetAll();
        }
    }
}
