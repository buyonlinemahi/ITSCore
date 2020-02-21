using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{


    public class CaseTreatmentPricingConfiguration : EntityTypeConfiguration<CaseTreatmentPricing>
    {
        public CaseTreatmentPricingConfiguration()
        {
            HasKey(caseTreatmentPricingObj => caseTreatmentPricingObj.CaseTreatmentPricingID);
            ToTable(Global.Table.global.CaseTreatmentPricing, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
