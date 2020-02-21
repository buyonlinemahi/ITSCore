using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
   public class PractitionerExpertiseConfiguration : EntityTypeConfiguration<PractitionerExpertise>
    {
       public PractitionerExpertiseConfiguration()
            : base()
        {
            HasKey(practitionerExpertise => practitionerExpertise.PractitionerExpertiseID);
            ToTable(Global.Table.global.PractitionerExpertise, Global.GlobalConst.Schema.GLOBAL);

        }

    }
}
