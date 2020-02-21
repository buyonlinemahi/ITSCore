using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseWorkflowPatientReferrerProjectConfiguration : EntityTypeConfiguration<CaseWorkflowPatientReferrerProject>
    {
        public CaseWorkflowPatientReferrerProjectConfiguration()
            : base()
        {
        }
    }
}