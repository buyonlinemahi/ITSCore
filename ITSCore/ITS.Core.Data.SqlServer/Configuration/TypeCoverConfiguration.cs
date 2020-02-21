using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TypeCoverConfiguration : EntityTypeConfiguration<TypeCover>
    {
        public TypeCoverConfiguration()
            : base()
        {
            HasKey(typecover => typecover.TypeCoverID);
            Property(typecover => typecover.TypeCoverName);
            ToTable(Global.Table.lookup.TypeCover, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
