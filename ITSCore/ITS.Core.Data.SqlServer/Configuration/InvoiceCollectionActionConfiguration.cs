using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class InvoiceCollectionActionConfiguration : EntityTypeConfiguration<InvoiceCollectionAction>
    {
        public InvoiceCollectionActionConfiguration()
            : base()
        {
            HasKey(InvoiceCollectionActionObj => InvoiceCollectionActionObj.InvoiceCollectionActionID);
            ToTable(Global.Table.global.InvoiceCollectionAction, Global.GlobalConst.Schema.GLOBAL);
          
         

        }

    }
}
