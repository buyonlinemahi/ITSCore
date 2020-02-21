using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class AdmittedConfiguration : EntityTypeConfiguration<Admitted>
    {
        public AdmittedConfiguration()
            : base()
        {
            HasKey(admitted => admitted.AdmittedID);
            ToTable(Global.Table.lookup.Admitted, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
