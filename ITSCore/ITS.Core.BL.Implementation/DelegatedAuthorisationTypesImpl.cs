using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/* ============================================================================= 
 *  Page Name:  DelegatedAuthorisationTypesImpl.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    created class DelegatedAuthorisationTypesImpl with a method to GetAll
 * ======================================================================================
 */

namespace ITS.Core.BL.Implementation
{
   public class DelegatedAuthorisationTypesImpl:IDelegatedAuthorisationTypes
    {


       private readonly IDelegatedAuthorisationTypesRepository _delegatedAuthorisationTypesRepository;

       public DelegatedAuthorisationTypesImpl(IDelegatedAuthorisationTypesRepository delegatedAuthorisationTypesRepository)
        {
            _delegatedAuthorisationTypesRepository = delegatedAuthorisationTypesRepository;
        }


        public IEnumerable<DelegatedAuthorisationTypes> GetAllDelegatedAuthorisationTypes()
        {
            return _delegatedAuthorisationTypesRepository.GetAll();
        }
    }
}
