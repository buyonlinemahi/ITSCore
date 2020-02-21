using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
   public class PractitionerConfiguration : EntityTypeConfiguration<Practitioner>
    {
       public PractitionerConfiguration()
            : base()
        {
            HasKey(practitioner => practitioner.PractitionerID);
            ToTable(Global.Table.global.Practitioner, Global.GlobalConst.Schema.GLOBAL);
          
         

        }

    }
}
