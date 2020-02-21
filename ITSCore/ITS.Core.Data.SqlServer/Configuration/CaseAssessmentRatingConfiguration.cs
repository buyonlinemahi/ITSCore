using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  CaseAssessmentRatingConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create CaseAssessmentRatingConfiguration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 04/30/2013 Robin   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentRatingConfiguration : EntityTypeConfiguration<CaseAssessmentRating>
    {
        public CaseAssessmentRatingConfiguration()
            : base()
        {
            HasKey(caseAssessmentRating => caseAssessmentRating.CaseAssessmentRatingID);
            Property(caseAssessmentRating => caseAssessmentRating.CaseID).IsRequired();
            Property(caseAssessmentRating => caseAssessmentRating.AssessmentServiceID).IsRequired();
            Property(caseAssessmentRating => caseAssessmentRating.Rating).IsRequired();
            Property(caseAssessmentRating => caseAssessmentRating.RatingDate).IsRequired();
            ToTable(Global.Table.global.CaseAssessmentRating, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
