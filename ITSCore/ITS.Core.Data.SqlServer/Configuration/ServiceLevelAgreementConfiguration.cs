using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
/*
Page Name:  ServiceLevelAgreementConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Service LevelAgreement Configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ServiceLevelAgreementConfiguration : EntityTypeConfiguration<ServiceLevelAgreement>
    {
        public ServiceLevelAgreementConfiguration()
            : base()
        {
            HasKey(serviceLevelAgreement => serviceLevelAgreement.ServiceLevelAgreementID);
            Property(serviceLevelAgreement => serviceLevelAgreement.ServiceLevelAgreementName).IsRequired();
            ToTable(Global.Table.lookup.ServiceLevelAgreement, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
