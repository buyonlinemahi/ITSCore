using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class UKPostCodeConfiguration : EntityTypeConfiguration<UKPostCode>
    {
        public UKPostCodeConfiguration()
            : base()
        {
            HasKey(postCode => postCode.PostCode);
            ToTable(Global.Table.lookup.UKPostCode, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}