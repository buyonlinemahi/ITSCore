using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentPeriodTypeConfiguration : EntityTypeConfiguration<TreatmentPeriodType>
    {
        public TreatmentPeriodTypeConfiguration()
            : base()
        {
            HasKey(treatmentPeriodType => treatmentPeriodType.TreatmentPeriodTypeID);
            Property(treatmentPeriodType => treatmentPeriodType.TreatmentPeriodTypeDesc);
            ToTable(Global.Table.lookup.TreatmentPeriodType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
