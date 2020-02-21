using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer
{
    public class WorkTypeConfiguration : EntityTypeConfiguration<WorkType>
    {
        public WorkTypeConfiguration()
            : base()
        {
            HasKey(w => w.WorkTypeID);
            ToTable(Global.Table.lookup.WorkType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
