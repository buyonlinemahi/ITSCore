using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

/*
Page Name:  ReferrerLocationConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create referrer location configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 10/30/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerLocationConfiguration : EntityTypeConfiguration<ReferrerLocation>
    {

        public ReferrerLocationConfiguration()
            : base()
        {
            HasKey(referrer => referrer.ReferrerLocationID);
            Property(referrer => referrer.ReferrerLocationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrer => referrer.Name).IsRequired();
            Property(referrer => referrer.Address).IsRequired();
            Property(referrer => referrer.PostCode).IsRequired();
            Property(referrer => referrer.ReferrerID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerLocation, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
