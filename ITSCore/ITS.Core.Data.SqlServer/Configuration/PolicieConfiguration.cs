using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PolicieConfiguration : EntityTypeConfiguration<Policie>
    {
        public PolicieConfiguration()
            : base()
        {
            HasKey(Policie => Policie.PolicyID);
            ToTable(Global.Table.global.Policie, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
