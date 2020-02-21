using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PrimaryConditionConfiguration : EntityTypeConfiguration<PrimaryCondition>
    {
        public PrimaryConditionConfiguration()
            : base()
        {
            HasKey(primary => primary.PrimaryConditionID);
            ToTable(Global.Table.lookup.PrimaryCondition, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
