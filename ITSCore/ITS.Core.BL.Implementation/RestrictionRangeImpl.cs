using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class RestrictionRangeImpl : IRestrictionRange
    {
        private readonly IRestrictionRangeRepository _RestrictionRangeRepository;

        public RestrictionRangeImpl(IRestrictionRangeRepository RestrictionRangeRepository)
        {
            _RestrictionRangeRepository = RestrictionRangeRepository;
        }

        public IEnumerable<Data.Model.RestrictionRange> GetAllRestrictionRange()
        {
            return _RestrictionRangeRepository.GetAll();
        }
        public string GetRestrictionRangeDesciptionByID(int _restrictionRangeID)
        {
            return _RestrictionRangeRepository.GetById(_restrictionRangeID).RestrictionRangeDescription;
        }
    }
}
