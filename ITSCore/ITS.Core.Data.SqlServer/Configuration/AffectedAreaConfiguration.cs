using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class AffectedAreaConfiguration : EntityTypeConfiguration<AffectedArea>
    {
        public AffectedAreaConfiguration()
            : base()
        {
            HasKey(AffectedArea => AffectedArea.AffectedAreaID);
            Property(AffectedArea => AffectedArea.AffectedAreaDescription).IsRequired();
            ToTable(Global.Table.lookup.AffectedArea, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
