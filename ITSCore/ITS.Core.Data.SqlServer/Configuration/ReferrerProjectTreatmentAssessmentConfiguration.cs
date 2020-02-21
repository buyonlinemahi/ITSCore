using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  ReferrerProjectTreatmentAssessmentConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create ReferrerProjectTreatmentAssessment Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentAssessmentConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentAssessment>
    {
        public ReferrerProjectTreatmentAssessmentConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatmentAssessment => referrerProjectTreatmentAssessment.ReferrerProjectTreatmentAssessmentID);
            Property(referrerProjectTreatmentAssessment => referrerProjectTreatmentAssessment.ReferrerProjectTreatmentAssessmentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatmentAssessment => referrerProjectTreatmentAssessment.AssessmentServiceID).IsRequired();
            Property(referrerProjectTreatmentAssessment => referrerProjectTreatmentAssessment.AssessmentTypeID).IsRequired();
            Property(referrerProjectTreatmentAssessment => referrerProjectTreatmentAssessment.ReferrerProjectTreatmentID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentAssessment, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
