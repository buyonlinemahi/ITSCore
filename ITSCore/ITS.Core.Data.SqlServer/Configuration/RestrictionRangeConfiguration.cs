using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class RestrictionRangeConfiguration : EntityTypeConfiguration<RestrictionRange>
    {
        public RestrictionRangeConfiguration()
            : base()
        {
            HasKey(RestrictionRange => RestrictionRange.RestrictionRangeID);
            Property(RestrictionRange => RestrictionRange.RestrictionRangeDescription).IsRequired();
            ToTable(Global.Table.lookup.RestrictionRange, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
