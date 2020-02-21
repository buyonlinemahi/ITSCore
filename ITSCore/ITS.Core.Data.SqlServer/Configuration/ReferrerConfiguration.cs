using System.Data.Entity.ModelConfiguration;
using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;

/*
Page Name:  ReferrerConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create referrer configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 10/26/2012 Satya   
 
 *  Modified By --harpreet singh
     Purpose : added the phone and fax fields
     Modified date: 27-feb-2013
     
     version 1.1
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerConfiguration: EntityTypeConfiguration<Referrer>
    {
        
        public ReferrerConfiguration()
            : base()
        {
            HasKey(referrer => referrer.ReferrerID);
            Property(referrer => referrer.ReferrerID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrer => referrer.ReferrerName).IsRequired();
            Property(referrer => referrer.ReferrerContactFirstName).IsRequired();
            Property(referrer => referrer.ReferrerContactLastName).IsRequired();           
            Property(referrer => referrer.ReferrerMainContactEmail).IsOptional();         
            Property(referrer => referrer.ReferrerMainContactFax).IsOptional();
            Property(referrer => referrer.ReferrerMainContactPhone).IsRequired();
            ToTable(Global.Table.referrer.Referrer, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
