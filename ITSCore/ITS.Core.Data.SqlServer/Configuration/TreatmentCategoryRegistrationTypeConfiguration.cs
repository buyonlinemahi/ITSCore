using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
 Page Name:  TreatmentCategoryRegistrationTypeConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create TreatmentCategoryRegistrationType Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/30/2012 robin,pardeep,vijay   
*
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class TreatmentCategoryRegistrationTypeConfiguration : EntityTypeConfiguration<TreatmentCategoryRegistrationType>
    {
        public TreatmentCategoryRegistrationTypeConfiguration()
            : base()
        {
            HasKey(treatmentCategoryRegistrationTypeID => treatmentCategoryRegistrationTypeID.TreatmentCategoryRegistrationTypeID);
            Property(registrationTypeID => registrationTypeID.RegistrationTypeID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            ToTable(Global.Table.lookup.TreatmentCategoryRegistrationType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
