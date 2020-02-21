using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comment
/*
    * Page Name: IPricingTypes.cs
    * Author : Vishal Sen
    * Latest Version : 1.0
    * Reason :- Interface For Pricing Type    
    * Created on 11-07-2012   
  
 Revision History
 Version : 1.0 ,Vishal Sen, 11-07-2012 
 Description : Create A Method For Get all Price Types
  
*/
#endregion

namespace ITS.Core.BL
{
   public interface IPricingTypes
    {
       IEnumerable<PricingType> GetAllPricingType();
    }
}
