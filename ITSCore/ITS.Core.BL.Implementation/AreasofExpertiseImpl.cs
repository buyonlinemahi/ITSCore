using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/* ============================================================================= 
 *  Page Name:  AreasofExpertiseImpl.cs                      
    Version:    1.0 
    Author:     Vishal
 *  Date:       1-01-2013
    Purpose:    created class AreasofExpertiseImpl with a method to GetAll
 * ======================================================================================
 * Author         : harpreet Singh
 * Date           : 07-Jan-2013
 * Version        : 1.1
 * Description    : Added GetAllAreasofExpertiseByTreatmentCategoryID Mehtod for AreasofExpertiseTest
 */

namespace ITS.Core.BL.Implementation
{

    public class AreasofExpertiseImpl : IAreasofExpertise
    {
        private readonly IAreasofExpertiseRepository _areasofExpertiseRepository;

        public AreasofExpertiseImpl(IAreasofExpertiseRepository areasofExpertiseRepository)
        {
            _areasofExpertiseRepository = areasofExpertiseRepository;
        }

        public IEnumerable<AreasofExpertise> GetAllAreasofExpertise()
        {
            return _areasofExpertiseRepository.GetAll();
        }

        
    }
}
