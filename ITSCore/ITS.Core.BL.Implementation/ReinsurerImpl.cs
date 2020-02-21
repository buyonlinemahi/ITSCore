using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class ReinsurerImpl : IReinsurer
    {
       private readonly IReinsurerRepository _IReinsurerRepository;

        public ReinsurerImpl(IReinsurerRepository IReinsurerRepository)
        {
            _IReinsurerRepository = IReinsurerRepository;
        }

        public IEnumerable<Data.Model.Reinsurer> GetAllReinsurer()
        {
            return _IReinsurerRepository.GetAll();
        }
    }
}
