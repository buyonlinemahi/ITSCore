using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class TreatmentCategoriesBespokeServiceImpl : ITreatmentCategoriesBespokeService
    {
        private readonly ITreatmentCategoriesBespokeServiceRepository _treatmentCategoriesBespokeServiceRepository;

        public TreatmentCategoriesBespokeServiceImpl(ITreatmentCategoriesBespokeServiceRepository treatmentCategoriesBespokeServiceRepository)
        {
            _treatmentCategoriesBespokeServiceRepository = treatmentCategoriesBespokeServiceRepository;
        }


        public IEnumerable<TreatmentCategoriesBespokeService> GetTreatmentCategoriesBespokeServicesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesBespokeServiceRepository.GetAll(o => o.TreatmentCategoryID == treatmentCategoryID);
        }
    }
}
