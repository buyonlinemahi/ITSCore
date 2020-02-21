using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PatientImpactOnWorkConfiguration : EntityTypeConfiguration<PatientImpactOnWork>
    {
        public PatientImpactOnWorkConfiguration()
            : base()
        {
            HasKey(patientImpactOnWork => patientImpactOnWork.PatientImpactOnWorkID);
            Property(patientImpactOnWork => patientImpactOnWork.PatientImpactOnWorkID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(patientImpactOnWork => patientImpactOnWork.PatientImpactOnWorkName).IsRequired();
            ToTable(Global.Table.lookup.PatientImpactOnWork, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
