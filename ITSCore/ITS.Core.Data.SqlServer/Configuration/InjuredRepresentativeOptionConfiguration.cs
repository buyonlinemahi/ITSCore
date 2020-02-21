using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class InjuredRepresentativeOptionConfiguration : EntityTypeConfiguration<InjuredRepresentativeOption>
    {
        public InjuredRepresentativeOptionConfiguration()
            : base()
        {
            HasKey(injObj => injObj.InjuredRepresentativeOptionID);
            Property(injObj => injObj.InjuredRepresentativeOptionName).IsRequired();
            ToTable(Global.Table.lookup.InjuredRepresentativeOption, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
