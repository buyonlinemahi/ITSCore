using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


#region Comment
/*
 Author : Vishal
 created date : 11/17/2012
 Purpose : Addd Configuration For Supplier
 Version : 1.0
 
 
 */
#endregion

namespace ITS.Core.Data.SqlServer.Configuration
{
   public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
       public SupplierConfiguration()
            : base()
        {
            HasKey(Supplier => Supplier.SupplierID);
           ToTable(Global.Table.supplier.Suppliers, Global.GlobalConst.Schema.SUPPLIER);
          
         

        }

    }
}
