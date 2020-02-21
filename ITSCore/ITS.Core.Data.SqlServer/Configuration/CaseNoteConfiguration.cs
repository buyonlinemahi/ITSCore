using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseNoteConfiguration : EntityTypeConfiguration<CaseNote>
    {
        public CaseNoteConfiguration()
            : base()
        {
            HasKey(_caseNote => _caseNote.CaseNoteID);
            ToTable(Global.Table.global.CaseNote, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
