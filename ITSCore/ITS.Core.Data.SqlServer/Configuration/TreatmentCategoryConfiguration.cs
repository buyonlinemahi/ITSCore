using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentCategoryConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create treatment category configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
  public  class TreatmentCategoryConfiguration: EntityTypeConfiguration<TreatmentCategory>
    {
      public TreatmentCategoryConfiguration()
            : base()
        {
            HasKey(treatmentCategory => treatmentCategory.TreatmentCategoryID);
            Property(treatmentCategory => treatmentCategory.TreatmentCategoryName);
            ToTable(Global.Table.lookup.TreatmentCategory, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
