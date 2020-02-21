using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SymptomDescriptionImpl : ISymptomDescription
    {
        private readonly ISymptomDescriptionRepository _SymptomDescriptionRepository;

        public SymptomDescriptionImpl(ISymptomDescriptionRepository SymptomDescriptionRepository)
        {
            _SymptomDescriptionRepository = SymptomDescriptionRepository;
        }

        public IEnumerable<Data.Model.SymptomDescription> GetAllSymptomDescription()
        {
            return _SymptomDescriptionRepository.GetAll();
        }
        public string GetSymptomDescriptionDesciptionByID(int _symptomDescriptionID)
        {
            return _SymptomDescriptionRepository.GetById(_symptomDescriptionID).SymptomDescriptionName;
        }
    }
}
