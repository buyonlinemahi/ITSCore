using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;



#region Comment
/*
    * Author : Satya
    * Latest Version : 1.0
    * Reason :-Create Configuration For InvoiceMethod to ingrtate with ITS       
    * Created on 11-22-2012 
  
*/
#endregion

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class InvoiceMethodConfiguration : EntityTypeConfiguration<InvoiceMethod>
    {

        public InvoiceMethodConfiguration()
            : base()
        {
            HasKey(invoiceMethod => invoiceMethod.InvoiceMethodID);
            Property(invoiceMethod => invoiceMethod.InvoiceMethodName);
            ToTable(Global.Table.lookup.InvoiceMethod, Global.GlobalConst.Schema.LOOKUP);

        }

    }


}
