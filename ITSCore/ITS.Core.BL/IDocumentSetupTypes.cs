using ITS.Core.Data.Model;
using System.Collections.Generic;


/* ============================================================================= 
 *  Page Name:  IDocumentSetupTypes.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    create IDocumentSetupTypes Interface
 * ======================================================================================
    Revision History:                                        
    Version:    1.0, Vijay Kumar  
 *  Date:       12-06-2012
 *  Created Method to select All DocumentSetupTypes 
    

   */
/// <summary>
/// 
/// </summary>


namespace ITS.Core.BL
{
    public interface IDocumentSetupTypes
    {
        IEnumerable<DocumentSetupTypes> GetAllDocumentSetupTypes();
    }
}
