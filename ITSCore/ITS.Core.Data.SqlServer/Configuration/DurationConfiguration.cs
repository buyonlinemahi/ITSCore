using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class DurationConfiguration : EntityTypeConfiguration<Duration>
    {
        public DurationConfiguration()
            : base()
        {
            HasKey(duration => duration.DurationID);
            Property(duration => duration.DurationName);
            ToTable(Global.Table.lookup.Duration, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
