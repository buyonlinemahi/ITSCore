using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Author : Vishal Sen
    * Latest Version : 1.0
    * Reason :- class For Pricing Type    
    * Created on 11-07-2012 
 
 Revision History
 Version : 1.0 ,Vishal Sen, 11-07-2012 
 Description: Add Method For Getall Pricing Types
*/
#endregion

namespace ITS.Core.BL.Implementation
{
    public class PricingTypesImpl : IPricingTypes
    {

        private readonly IPricingTypesRepository _PricingTypesRepository;

        public PricingTypesImpl(IPricingTypesRepository PricingTypesRepository)
        {
            _PricingTypesRepository = PricingTypesRepository;
        }
        

   

        public IEnumerable<PricingType> GetAllPricingType()
        {
            return _PricingTypesRepository.GetAll();
        }
    }
}
