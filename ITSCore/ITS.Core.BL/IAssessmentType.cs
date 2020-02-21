using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
   
    * Author : Vijay Kumar
    * Latest Version : 1.0       
    * Created on 11-19-2012  
    * Reason :- Created Interface for IAssessmentType
 * 
 * 
 *  Revised Version: 1.0 
 * Created on 11-19-2012 
 * Reason :- Add Interface Method that use the code first Approch.    
   1) GetAllAssessmentType
*/
#endregion

namespace ITS.Core.BL
{
    public interface IAssessmentType
    {
        IEnumerable<AssessmentType> GetAllAssessmentType();
    }
}
