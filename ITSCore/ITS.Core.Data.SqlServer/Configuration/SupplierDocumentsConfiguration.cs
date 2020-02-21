using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
 Page Name:  SupplierDocumentConfiguration.cs                      
 Version:  1.0                                            
  
  ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0
  Purpose : to create SupplierDocumentConfiguration to ingrtate with ITS 
  ============================================================================================================================================================
 */

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierDocumentConfiguration : EntityTypeConfiguration<SupplierDocument>
    {
        public SupplierDocumentConfiguration()
            : base()
        {
            HasKey(SupplierDocument => SupplierDocument.SupplierDocumentID);
            ToTable(Global.Table.supplier.SupplierDocument, Global.GlobalConst.Schema.SUPPLIER);
        }
    }
}
