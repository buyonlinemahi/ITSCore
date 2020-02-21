using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class StrengthTestingConfiguration : EntityTypeConfiguration<StrengthTesting>
    {
        public StrengthTestingConfiguration()
            : base()
        {
            HasKey(StrengthTesting => StrengthTesting.StrengthTestingID);
            Property(StrengthTesting => StrengthTesting.StrengthTestingDescription).IsRequired();
            ToTable(Global.Table.lookup.StrengthTesting, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
