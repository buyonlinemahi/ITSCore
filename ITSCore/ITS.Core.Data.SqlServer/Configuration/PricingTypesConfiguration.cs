using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;



#region Comment
/*
    * Author : Vishal Sen
    * Latest Version : 1.0
    * Reason :-Create Configuration For Pricing Type to ingrtate with ITS       
    * Created on 11-07-2012 
 
 Revision History
 Version : 1.0 ,Vishal Sen, 11-07-2012 
 Description: Create Configuration For Pricing Type to ingrtate with ITS         
*/
#endregion

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PricingTypesConfiguration : EntityTypeConfiguration<PricingType>
    {

        public PricingTypesConfiguration()
            : base()
        {
            HasKey(PricingTypes => PricingTypes.PricingTypeID);
            Property(PricingTypes => PricingTypes.PricingTypeName);
            ToTable(Global.Table.lookup.PricingTypes, Global.GlobalConst.Schema.LOOKUP);

        }

    }


}
