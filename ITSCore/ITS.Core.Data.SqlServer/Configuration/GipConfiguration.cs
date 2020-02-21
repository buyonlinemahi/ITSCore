using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class GipConfiguration : EntityTypeConfiguration<Gip>
    {
        public GipConfiguration()
            : base()
        {
            HasKey(gip => gip.GipID);
            ToTable(Global.Table.lookup.Gip, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
