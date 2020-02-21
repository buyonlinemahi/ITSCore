using ITS.Core.Data.Model;
using System.Collections.Generic;


/* ============================================================================= 
 *  Page Name:  IDelegatedAuthorisationTypes.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    create IDelegatedAuthorisationTypes Interface
 * ======================================================================================
    Revision History:                                        
    Version:    1.0, Vijay Kumar  
 *  Date:       12-06-2012
 *  Created Method to select all DelegatedAuthorisationTypes 
    

   */
/// <summary>
/// 
/// </summary>

namespace ITS.Core.BL
{
    public interface IDelegatedAuthorisationTypes
    {
        IEnumerable<DelegatedAuthorisationTypes> GetAllDelegatedAuthorisationTypes();
    }
}
