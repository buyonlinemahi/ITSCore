using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerGroupConfiguration : EntityTypeConfiguration<ReferrerGroup>
    {
        public ReferrerGroupConfiguration()
            : base()
        {
            HasKey(groupTest => groupTest.GroupID);
            ToTable(Global.Table.referrer.ReferrerGroup, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
