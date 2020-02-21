using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



/* Author : Vijay Kumar
   * Latest Version : 1.1      
   * Created on 11-17-2012  
   * Reason :- Implement Interface Method for IDelegatedAuthorisation 
 ===================================================================================
 * 
 Revised Version: 1.1 
   Edited by: Vijay Kumar
   Reason :- Implement Interface Method for IDelegatedAuthorisation(GetAllDelegatedAuthorisation)
 */


namespace ITS.Core.BL.Implementation
{

    public class DelegatedAuthorisationImpl:IDelegatedAuthorisation
    {

         private readonly IDelegatedAuthorisationRepository _delegatedAuthorisationRepository;

         public DelegatedAuthorisationImpl(IDelegatedAuthorisationRepository delegatedAuthorisationRepository)
        {
            _delegatedAuthorisationRepository = delegatedAuthorisationRepository;
        }



         public IEnumerable<DelegatedAuthorisation> GetAllDelegatedAuthorisation()
         {
             return _delegatedAuthorisationRepository.GetAll();
         }
    }
}
