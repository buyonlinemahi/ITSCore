using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SymptomDescriptionConfiguration : EntityTypeConfiguration<SymptomDescription>
    {
        public SymptomDescriptionConfiguration()
            : base()
        {
            HasKey(SymptomDescription => SymptomDescription.SymptomDescriptionID);
            Property(SymptomDescription => SymptomDescription.SymptomDescriptionName).IsRequired();
            ToTable(Global.Table.lookup.SymptomDescription, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
