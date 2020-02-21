using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PractitionerRegistrationConfiguration : EntityTypeConfiguration<PractitionerRegistration>
    {
        public PractitionerRegistrationConfiguration()
            : base()
        {
            HasKey(practitionerRegistration => practitionerRegistration.PractitionerRegistrationID);
            ToTable(Global.Table.global.PractitionerRegistration, Global.GlobalConst.Schema.GLOBAL);

        }

    }
}
