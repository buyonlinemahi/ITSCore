using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  ReferrerProjectTreatmentConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Referrer Project Treatment Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentConfiguration : EntityTypeConfiguration<ReferrerProjectTreatment>
    {
        public ReferrerProjectTreatmentConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatment => referrerProjectTreatment.ReferrerProjectTreatmentID);
            Property(referrerProjectTreatment => referrerProjectTreatment.ReferrerProjectTreatmentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatment => referrerProjectTreatment.ReferrerProjectID).IsRequired();
            Property(referrerProjectTreatment => referrerProjectTreatment.TreatmentCategoryID).IsRequired();
            Property(referrerProjectTreatment => referrerProjectTreatment.AccountReceivableChasingPoint);
            Property(referrerProjectTreatment => referrerProjectTreatment.AccountReceivableCollection);
            Property(referrerProjectTreatment => referrerProjectTreatment.Enabled);
            ToTable(Global.Table.referrer.ReferrerProjectTreatment, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
