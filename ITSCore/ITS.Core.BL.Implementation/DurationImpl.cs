using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL.Implementation
{

    public class DurationImpl : IDuration
    {
       
        private readonly IDurationRepository _durationRepository;

        public DurationImpl(IDurationRepository durationRepository)
        {
            _durationRepository = durationRepository;
        }


        public IEnumerable<Duration> GetAllDuration()
        {
            return _durationRepository.GetAll();
        }

    }
}
