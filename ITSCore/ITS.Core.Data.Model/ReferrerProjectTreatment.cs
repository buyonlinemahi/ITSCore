namespace ITS.Core.Data.Model
{
    /*
 Page Name:  ReferrerProjectTreatment.cs                      
  Version:  1.0                                              
  Purpose: create ReferrerProjectTreatment model class                                                      
  Revision History:                                        
                                                           
    1.0 – 11/09/2012 Satya 

 */
    /// <summary>
    /// 
    /// </summary>
    public class ReferrerProjectTreatment
    {
        public int ReferrerProjectTreatmentID { get; set; }
        public int ReferrerProjectID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public int? AccountReceivableChasingPoint { get; set; }
        public int? AccountReceivableCollection { get; set; }
        public bool Enabled { get; set; }
        //public string TreatmentCategoryName { get; set; }
    }
}
