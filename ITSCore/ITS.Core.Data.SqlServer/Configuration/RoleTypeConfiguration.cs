using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer
{
    public class RoleTypeConfiguration : EntityTypeConfiguration<RoleType>
    {
        public RoleTypeConfiguration()
            : base()
        {
            HasKey(w => w.RoleTypeID);
            ToTable(Global.Table.lookup.RoleType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
