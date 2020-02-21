using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comment
/*   
    * Author : Vijay Kumar
    * Latest Version : 1.1       
    * Created on 11-15-2012  
    * Reason :- Created Interface for IAssessmentService
 * ===============================================================
 * 
 *  Revised Version: 1.0 
 *  Edited By : Vijay Kumar
 * Created on 11-17-2012 
 * Reason :- Add Interface Method that use the code first Approch.    
   1) Add_AssessmentService
 * 2) GetAll_AssessmentService
 * 3) Update_AssessmentService
 * 4) Delete_AssessmentService
 *======================================================
 *
 *  Revised Version: 1.1
 *  Edited By : Vijay Kumar
 * Created on 11-19-2012 
 * Reason :- Remove all the above method and add only GetAllAssessmentService(without underscore Character) 
 * 
*/
#endregion

namespace ITS.Core.BL
{
    public interface IAssessmentService
    {     
        IEnumerable<AssessmentService> GetAllAssessmentService();
    }
}