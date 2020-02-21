using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    class CaseDocumentConfiguration : EntityTypeConfiguration<CaseDocument>
    {
        public CaseDocumentConfiguration()
            : base()
        {
            //HasKey(caseDocumentTypeID => new { caseDocumentTypeID.CaseID, caseDocumentTypeID.DocumentTypeID });
            HasKey(caseID => caseID.CaseID);
            HasKey(documentTypeId => documentTypeId.DocumentTypeID);
            Property(caseID => caseID.CaseID).IsRequired();
            Property(documentTypeId => documentTypeId.DocumentTypeID).IsRequired();
            ToTable(Global.Table.global.CaseDocuments,Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
