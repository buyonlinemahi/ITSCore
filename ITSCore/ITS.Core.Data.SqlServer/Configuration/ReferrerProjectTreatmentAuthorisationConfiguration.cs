using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  ReferrerProjectTreatmentAuthorisation.cs                      
 Latest Version:  1.1                                              
 Purpose: Remove unwanted properties and add the latest fields                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   

 Version:  1.1      
Modified By : Anuj Batra
Purpose: Updated ReferrerProjectTreatmentAuthorisationConfiguration class, Remove unwanted properties and add the latest fields.
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentAuthorisationConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentAuthorisation>
    {
        public ReferrerProjectTreatmentAuthorisationConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentAuthorisationID);
            Property(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentAuthorisationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.TreatmentCategoryID).IsRequired();
            Property(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.DelegatedAuthorisationTypeID).IsRequired();
            Property(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.Amount).IsRequired();
            Property(referrerProjectTreatmentAuthorisation => referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentAuthorisation, Global.GlobalConst.Schema.REFERRER);

        }
    }
}
