using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  IAreasofExpertise.cs                      
  Version:  1.0                                              
  Purpose: Added a interface to GetAll AreasofExpertise                                               
  Revision History:                                        
                                                           
    1.0 – 01/01/2013 Vishal  
 * 
 * Author         : harpreet Singh
 * Date           : 07-Jan-2013
 * Version        : 1.1
 * Description    : Added GetAllAreasofExpertiseByTreatmentCategoryID Mehtod for AreasofExpertiseTest
 */
namespace ITS.Core.BL
{
   public interface IAreasofExpertise
    {
       IEnumerable<AreasofExpertise> GetAllAreasofExpertise();
   
    }
}
