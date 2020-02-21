using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ElRehabConfiguration : EntityTypeConfiguration<ElRehab>
    {
        public ElRehabConfiguration()
            : base()
        {
            HasKey(elrehab => elrehab.ElRehabID);
            ToTable(Global.Table.lookup.ElRehab, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
