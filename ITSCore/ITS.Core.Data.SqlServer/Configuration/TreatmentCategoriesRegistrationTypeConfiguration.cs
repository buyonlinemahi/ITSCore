using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentCategoriesRegistrationTypeConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create TreatmentCategoriesRegistrationTypeConfiguration  to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/30/2012 robin,pardeep,vijay   
*
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class TreatmentCategoriesRegistrationTypeConfiguration : EntityTypeConfiguration<TreatmentCategoriesRegistrationType>
    {
        public TreatmentCategoriesRegistrationTypeConfiguration()
            : base()
        {
            HasKey(treatmentCategoryRegistrationTypeID => treatmentCategoryRegistrationTypeID.TreatmentCategoryRegistrationTypeID);
            Property(registrationTypeID => registrationTypeID.RegistrationTypeID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            Property(registrationTypeName => registrationTypeName.RegistrationTypeName).IsRequired();
            Property(treatmentCategoryName => treatmentCategoryName.TreatmentCategoryName);
            ToTable(Global.View.lookup.TreatmentCategoriesRegistrationType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
