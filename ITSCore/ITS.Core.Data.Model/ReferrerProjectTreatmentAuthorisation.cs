/*
Page Name:  ReferrerProjectTreatmentAuthorisation.cs                      
Version:  1.1
Purpose: Remove unwanted properties and add the latest fields                                                      

Revision History:                                                                                                   
1.0 – 11/10/2012 Satya 

Version:  1.1      
Modified By : Anuj Batra
Purpose: Updated ReferrerProjectTreatmentAuthorisation model class, Remove unwanted properties and add the latest fields.                                                       

 * 
*/
/// <summary>
/// 
/// </summary>
namespace ITS.Core.Data.Model
{
    public class ReferrerProjectTreatmentAuthorisation
    {
        public int ReferrerProjectTreatmentAuthorisationID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public int DelegatedAuthorisationTypeID { get; set; }
        public decimal? Amount{ get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public bool Enabled { get; set; }
        public int? Quantity { get; set; }

    }
}
