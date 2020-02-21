using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
            : base()
        {
            HasKey(patient => patient.PatientID);
            ToTable(Global.Table.global.Patient, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}