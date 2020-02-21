using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PractitionerTreatmentRegistrationConfiguration : EntityTypeConfiguration<PractitionerTreatmentRegistration>
    {

        public PractitionerTreatmentRegistrationConfiguration()
            : base()
        {
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.PractitionerFirstName);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.TreatmentCategoryName);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.PractitionerRegistrationID);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.PractitionerLastName);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.PractitionerID);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.RegistrationTypeName);
            Property(practitionerTreatmentRegistration => practitionerTreatmentRegistration.IsActive);
            HasKey(practitionerTreatmentRegistration => practitionerTreatmentRegistration.PractitionerRegistrationID);
            ToTable(Global.View.lookup.PractitionerTreatmentRegistration, Global.GlobalConst.Schema.LOOKUP);

        }
    }
}
