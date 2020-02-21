using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
/*
 Page Name:  TreatmentCategoryImpl.cs          
                                                           
    1.0 – 11/07/2012 Satya   
 * Created class TreatmentCategoryImpl with a method to GetAll
 * 
 */
namespace ITS.Core.BL.Implementation
{
    public class TreatmentCategoryImpl : ITreatmentCategory
    {
        private readonly ITreatmentCategoryRepository _treatmentCategoryRepository;

        public TreatmentCategoryImpl(ITreatmentCategoryRepository treatmentCategoryRepository)
        {
            _treatmentCategoryRepository = treatmentCategoryRepository;
        }





        public IEnumerable<TreatmentCategory> GetAllTreatmentCategory()
        {
            return _treatmentCategoryRepository.GetAll().OrderBy(obj => obj.TreatmentCategoryName);
        }
    }
}

