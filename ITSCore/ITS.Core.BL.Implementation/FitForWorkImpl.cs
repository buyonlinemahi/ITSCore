using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class FitForWorkImpl : IFitForWork
    {
        private readonly IFitForWorkRepository _IFitForWorkRepository;

        public FitForWorkImpl(IFitForWorkRepository IFitForWorkRepository)
        {
            _IFitForWorkRepository = IFitForWorkRepository;
        }

        public IEnumerable<Data.Model.FitForWork> GetAllFitForWork()
        {
            return _IFitForWorkRepository.GetAll();
        }
    }
}
