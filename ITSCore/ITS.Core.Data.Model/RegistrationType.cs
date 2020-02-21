/*
Page Name:  RegistrationType.cs                      
Version:  1.1                                              
Purpose: create RegistrationType model class                                                      
Revision History:                                        
                                                           
  1.0 – 12/21/2012 Vishal
 * 
 * modified by: Robin, vijay
 * Description: Remove Foreign Key Coloum TreatmentCategoryID from model RegistrationType
 * Date: 01-30-2013,
 * version: 1.1

*/
namespace ITS.Core.Data.Model
{
  public class RegistrationType
    {
        public int RegistrationTypeID { get; set; }
        public string RegistrationTypeName { get; set; }
    }
}
