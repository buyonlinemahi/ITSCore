using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class TypeCoverImpl : ITypeCover
    {
        private readonly ITypeCoverRepository _ITypeCoverRepository;

        public TypeCoverImpl(ITypeCoverRepository ITypeCoverRepository)
        {
            _ITypeCoverRepository = ITypeCoverRepository;
        }

        public IEnumerable<Data.Model.TypeCover> GetAllTypeCover()
        {
            return _ITypeCoverRepository.GetAll();
        }
    }
}
