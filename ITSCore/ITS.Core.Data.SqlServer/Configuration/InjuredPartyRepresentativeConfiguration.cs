using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class InjuredPartyRepresentativeConfiguration : EntityTypeConfiguration<InjuredPartyRepresentative>
    {
        public InjuredPartyRepresentativeConfiguration()
            : base()
        {
            HasKey(injured => injured.InjuredID);
            ToTable(Global.Table.global.InjuredPartyRepresentative, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
