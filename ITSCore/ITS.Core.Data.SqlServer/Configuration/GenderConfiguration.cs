using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer
{
    public class GenderConfiguration : EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
            : base()
        {
            HasKey(g => g.GenderID);
            ToTable(Global.Table.lookup.Gender, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
