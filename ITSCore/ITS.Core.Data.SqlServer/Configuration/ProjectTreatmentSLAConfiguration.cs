using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
/*
Page Name:  ProjectTreatmentSLAConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Project TreatmentSLA Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ProjectTreatmentSLAConfiguration: EntityTypeConfiguration<ProjectTreatmentSLA>
    {
        public ProjectTreatmentSLAConfiguration()
            : base()
        {
            HasKey(projectTreatmentSLA => projectTreatmentSLA.ProjectTreatmentSLAID);
            Property(projectTreatmentSLA => projectTreatmentSLA.ProjectTreatmentSLAID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(projectTreatmentSLA => projectTreatmentSLA.ReferrerProjectTreatmentID).IsRequired();
            Property(projectTreatmentSLA => projectTreatmentSLA.ServiceLevelAgreementID).IsRequired();
            Property(projectTreatmentSLA => projectTreatmentSLA.NumberOfDays).IsRequired();
            Property(projectTreatmentSLA => projectTreatmentSLA.Enabled).IsRequired();
            ToTable(Global.Table.referrer.ProjectTreatmentSLA, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
