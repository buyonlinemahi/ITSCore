using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
   public class CaseBespokeServicePricingConfiguration :EntityTypeConfiguration<CaseBespokeServicePricing>
    {
       public CaseBespokeServicePricingConfiguration()
        {
            HasKey(caseBespokeServicePricingObj => caseBespokeServicePricingObj.CaseBespokeServiceID);
            ToTable(Global.Table.global.CaseBespokeServicePricing, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
