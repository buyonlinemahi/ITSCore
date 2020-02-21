using ITS.Core.Data;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{
    public class AffectedAreaImpl : IAffectedArea
    {
        private readonly IAffectedAreaRepository _AffectedAreaRepository;

        public AffectedAreaImpl(IAffectedAreaRepository AffectedAreaRepository)
        {
            _AffectedAreaRepository = AffectedAreaRepository;
        }

        public IEnumerable<Data.Model.AffectedArea> GetAllAffectedArea()
        {
            return _AffectedAreaRepository.GetAll();
        }
        public string GetAffectedAreaDesciptionByID(int _affectedAreaID)
        {
            return _AffectedAreaRepository.GetById(_affectedAreaID).AffectedAreaDescription;
        }
    }
}
