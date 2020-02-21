
namespace ITS.Core.Data.Model
{
    /*
     Latest Version:  1.2
     Page Name:  ReferrerLocation.cs      
     Purpose: create referrer location model class
     
     Revision History:                                        
                                                           
     1.0 – 10/26/2012 Satya 
      
     Modified By --harpreet singh
     Purpose : deleted the phone and fax fields
     Modified date: 27-feb-2013     
     version 1.1
      
     Modified By --Manjit Singh
     Purpose : Add field for IsActive
     Modified date: 05-March-2013     
     version 1.2
    */

    /// <summary>
    /// 
    /// </summary>
    public class ReferrerLocation
    {
        public int ReferrerLocationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostCode { get; set; } 
        public bool IsMainOffice { get; set; }
        public int ReferrerID { get; set; }
        public bool IsActive { get; set; }
    }
}