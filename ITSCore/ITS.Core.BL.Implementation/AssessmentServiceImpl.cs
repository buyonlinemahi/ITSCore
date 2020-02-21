using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


/* Author : Vijay Kumar
   * Latest Version : 1.1       
   * Created on 11-17-2012  
   * Reason :- Implement Interface Method for IAssessmentService
 =====================================================================================
   Revised Version: 1.1 
   Edited by: Vijay Kumar
   Reason :- Implement Interface Method for IAssessmentService(GetAllAssessmentService)
 */
namespace ITS.Core.BL.Implementation
{

    public class AssessmentServiceImpl : IAssessmentService
    {
       
        private readonly IAssessmentServiceRepository _assessmentServiceRepository;

        public AssessmentServiceImpl(IAssessmentServiceRepository assessmentServiceRepository)
        {
            _assessmentServiceRepository = assessmentServiceRepository;
        }


        public IEnumerable<AssessmentService> GetAllAssessmentService()
        {
            return _assessmentServiceRepository.GetAll();
        }

    }
}
