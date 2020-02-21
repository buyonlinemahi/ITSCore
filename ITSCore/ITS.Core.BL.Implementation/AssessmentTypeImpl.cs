using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
   Revised Version: 1.1 
   Edited by: Vijay Kumar
   Reason :- Implement Interface Method for IAssessmentService(GetAllAssessmentService)
 * ======================================================================
 * 
 *  Revised Version: 1.1 
   Edited by: Vijay Kumar
   Reason :- Implement Interface Method for IAssessmentType(GetAllAssessmentType)

  */
namespace ITS.Core.BL.Implementation
{

    public class AssessmentTypeImpl : IAssessmentType
    {
        private readonly IAssessmentTypeRepository _assessmentTypeRepository;

        public AssessmentTypeImpl(IAssessmentTypeRepository assessmentTypeRepository)
        {
            _assessmentTypeRepository = assessmentTypeRepository;
        }




        public IEnumerable<AssessmentType> GetAllAssessmentType()
        {
            return _assessmentTypeRepository.GetAll();
        }
    }
}
