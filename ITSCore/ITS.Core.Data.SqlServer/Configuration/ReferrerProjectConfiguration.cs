using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
/*
Page Name:  ReferrerProjectConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Referrer Project Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectConfiguration : EntityTypeConfiguration<ReferrerProject>
    {
        public ReferrerProjectConfiguration()
            : base()
        {
            HasKey(referrerProject => referrerProject.ReferrerProjectID);
            Property(referrerProject => referrerProject.ReferrerProjectID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProject => referrerProject.ProjectName);
            Property(referrerProject => referrerProject.ReferrerID).IsRequired();
            Property(referrerProject => referrerProject.StatusID).IsRequired();
            Property(referrerProject => referrerProject.FirstAppointmentOffered).IsRequired();
            Property(referrerProject => referrerProject.Enabled).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProject, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
