using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  ReferrerProjectTreatmentPricingConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Referrer Project Treatment Pricing Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentPricingConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentPricing>
    {
        public ReferrerProjectTreatmentPricingConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatmentPricing => referrerProjectTreatmentPricing.PricingID);
            Property(referrerProjectTreatmentPricing => referrerProjectTreatmentPricing.PricingID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatmentPricing => referrerProjectTreatmentPricing.PricingTypeID).IsRequired();
            Property(referrerProjectTreatmentPricing => referrerProjectTreatmentPricing.Price);
            Property(referrerProjectTreatmentPricing => referrerProjectTreatmentPricing.ReferrerProjectTreatmentID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentPricing, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
