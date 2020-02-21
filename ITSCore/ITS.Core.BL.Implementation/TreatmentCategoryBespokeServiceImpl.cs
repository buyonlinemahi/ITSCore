using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class TreatmentCategoryBespokeServiceImpl : ITreatmentCategoryBespokeService
    {
        private readonly ITreatmentCategoryBespokeServiceRepository _treatmentCategoryBespokeServiceRepository;

        public TreatmentCategoryBespokeServiceImpl(ITreatmentCategoryBespokeServiceRepository treatmentCategoryBespokeServiceRepository)
        {
            _treatmentCategoryBespokeServiceRepository = treatmentCategoryBespokeServiceRepository;
        }



        public IEnumerable<TreatmentCategoryBespokeService> GetTreatmentCategoryBespokeServicesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoryBespokeServiceRepository.GetAll(o => o.TreatmentCategoryID == treatmentCategoryID);
        }
    }
}
