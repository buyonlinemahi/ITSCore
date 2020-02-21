using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class IipConfiguration : EntityTypeConfiguration<Iip>
    {
        public IipConfiguration()
            : base()
        {
            HasKey(iip => iip.IipID);
            ToTable(Global.Table.lookup.Iip, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
