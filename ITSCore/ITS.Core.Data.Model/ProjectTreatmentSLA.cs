
namespace ITS.Core.Data.Model
{
    /*
 Page Name:  ProjectTreatmentSLA.cs                      
  Version:  1.0                                              
  Purpose: create ProjectTreatmentSLA model class                                                      
  Revision History:                                        
                                                           
    1.0 – 11/09/2012 Satya 

 */
    /// <summary>
    /// 
    /// </summary>
    public class ProjectTreatmentSLA
    {
        public int ProjectTreatmentSLAID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public int ServiceLevelAgreementID { get; set; }
        public int NumberOfDays { get; set; }
        public bool Enabled { get; set; }
    }
}
