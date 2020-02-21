using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Latest Version : 1.0
    * Page Name: TreatmentType.cs
    * Created By : Robin Singh
    * Reason :- Implement interface Treatment Type
    * Created on: 01-01-2013    
*/
#endregion

namespace ITS.Core.BL.Implementation
{
    public class TreatmentTypeImpl : ITreatmentType
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;

        public TreatmentTypeImpl(ITreatmentTypeRepository treatmentTypeRepository)
        {
            _treatmentTypeRepository = treatmentTypeRepository;
        }

        public IEnumerable<TreatmentType> GetAllTreatmentType()
        {
            return _treatmentTypeRepository.GetAll();
        }

    }
}
