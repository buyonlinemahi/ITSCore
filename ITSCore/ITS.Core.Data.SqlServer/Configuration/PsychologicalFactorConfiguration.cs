using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class PsychologicalFactorConfiguration : EntityTypeConfiguration<PsychologicalFactor>
    {
        public PsychologicalFactorConfiguration()
            : base()
        {
            HasKey(psychologicalFactor => psychologicalFactor.PsychologicalFactorID);
            Property(psychologicalFactor => psychologicalFactor.PsychologicalFactorName).IsRequired();
            ToTable(Global.Table.lookup.PsychologicalFactor, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
