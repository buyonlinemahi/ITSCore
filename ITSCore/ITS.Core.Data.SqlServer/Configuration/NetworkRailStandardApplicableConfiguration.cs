using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
   public class NetworkRailStandardApplicableConfiguration:EntityTypeConfiguration<NetworkRailStandardApplicable>
    {
       public NetworkRailStandardApplicableConfiguration()
            : base()
        {
            HasKey(network => network.NetworkRailStandardApplicableID);
            ToTable(Global.Table.lookup.NetworkRailStandardApplicable, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
