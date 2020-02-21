using ITS.Core.Data.Model;
using System.Collections.Generic;

/*  
    * Author : Vijay Kumar
    * Latest Version : 1.0       
    * Created on 11-19-2012  
    * Reason :- Created Interface for IDelegatedAuthorisation
 * 
 * 
 *  Revised Version: 1.0 
 * Created on 11-19-2012 
 * Reason :- Add Interface Method that use the code first Approch.    
   1) GetAllDelegatedAuthorisation
*/
namespace ITS.Core.BL
{
    public interface IDelegatedAuthorisation
    {
        IEnumerable<DelegatedAuthorisation> GetAllDelegatedAuthorisation();
    }
}
