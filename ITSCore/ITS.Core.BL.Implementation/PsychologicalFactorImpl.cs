using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
     public class PsychologicalFactorImpl : IPsychologicalFactor
    {

        private readonly IPsychologicalFactorRepository _psychologicalFactorRepository;

        public PsychologicalFactorImpl(IPsychologicalFactorRepository psychologicalFactorRepository)
        {
            _psychologicalFactorRepository = psychologicalFactorRepository;
        }

        public IEnumerable<Data.Model.PsychologicalFactor> GetAllPsychologicalFactors()
        {
            return _psychologicalFactorRepository.GetAll();
        }
    }
}
