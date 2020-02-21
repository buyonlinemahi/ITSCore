using System;
/*
Page Name:  CaseAssessmentRating.cs                      
Version:  1.0                                              
Purpose: create CaseAssessmentRating model class                                                      
Revision History:                                        
                                                           
1.0 – 04/30/2013 Robin  

*/
/// <summary>
/// 
/// </summary>
namespace ITS.Core.Data.Model
{
    public class CaseAssessmentRating
    {
        public int CaseAssessmentRatingID { get; set; }
        public int CaseID { get; set; }
        public int AssessmentServiceID { get; set; }
        public decimal Rating { get; set; }
        public DateTime RatingDate { get; set; }

    }
}
