/*
Page Name:  ReferrerProjectTreatmentAssessment.cs                      
Version:  1.0                                              
Purpose: create ReferrerProjectTreatmentAssessment model class                                                      
Revision History:                                        
                                                           
1.0 – 11/10/2012 Satya 

*/
/// <summary>
/// 
/// </summary>
namespace ITS.Core.Data.Model
{
    public class ReferrerProjectTreatmentAssessment
    {
        public int ReferrerProjectTreatmentAssessmentID { get; set; }
        public int AssessmentServiceID { get; set; }
        public int AssessmentTypeID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
    }
}
