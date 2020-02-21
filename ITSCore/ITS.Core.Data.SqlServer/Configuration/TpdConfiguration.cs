using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TpdConfiguration : EntityTypeConfiguration<Tpd>
    {
        public TpdConfiguration()
            : base()
        {
            HasKey(tpd => tpd.TpdID);
            ToTable(Global.Table.lookup.Tpd, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
