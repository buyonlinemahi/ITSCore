using System.Data.Entity.ModelConfiguration;
using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class CaseAppointmentDateConfiguration : EntityTypeConfiguration<CaseAppointmentDate>
    {
        public CaseAppointmentDateConfiguration()
        {
            HasKey(caseAppointmentDate => caseAppointmentDate.CaseID);
            Property(caseAppointmentDate => caseAppointmentDate.AppointmentDateTime).IsRequired();
            Property(caseAppointmentDate => caseAppointmentDate.FirstAppointmentOfferedDate);
            ToTable(Global.Table.global.CaseAppointmentDate, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
