
using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class PatientWorkstatusConfiguration : EntityTypeConfiguration<PatientWorkstatus>
    {
        public PatientWorkstatusConfiguration()
            : base()
        {
            HasKey(patientWorkstatus => patientWorkstatus.PatientWorkstatusID);
            Property(patientWorkstatus => patientWorkstatus.PatientWorkstatusName).IsRequired();
            ToTable(Global.Table.lookup.PatientWorkstatus, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
