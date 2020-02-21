using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  ReferrerProjectTreatmentInvoiceConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Referrer Project Treatment Invoice to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/22/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentInvoiceConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentInvoice>
    {
        public ReferrerProjectTreatmentInvoiceConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.ReferrerProjectTreatmentInvoiceID);
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.ReferrerProjectTreatmentInvoiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.InvoicePrice);
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.ManagementPrice);
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.ManagementFeeEnabled);
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.InvoiceMethodID).IsRequired();
            Property(referrerProjectTreatmentInvoice => referrerProjectTreatmentInvoice.ReferrerProjectTreatmentID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentInvoice, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
