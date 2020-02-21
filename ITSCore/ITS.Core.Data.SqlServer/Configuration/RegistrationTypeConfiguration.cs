using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  RegistrationTypeConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create Registration Type  Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 12/21/2012 Vishal   
* 
 *Modified By: Robin, pardeep, vijay
 *Version:  1.1                                              
  Purpose: remove Property TreatmentCategoryID from RegistrationTypeConfiguration 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class RegistrationTypeConfiguration : EntityTypeConfiguration<RegistrationType>
    {
        public RegistrationTypeConfiguration()
            : base()
        {
            HasKey(registrationType => registrationType.RegistrationTypeID);
            Property(registrationType => registrationType.RegistrationTypeName).IsRequired();
            ToTable(Global.Table.lookup.RegistrationType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
