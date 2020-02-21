using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentCategoryTreatmentTypes.cs                      
 Version:  1.0                                              
 Purpose: create treatment category treatment types configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/25/2013 Robin   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
  public  class TreatmentCategoryTreatmentTypeConfiguration: EntityTypeConfiguration<TreatmentCategoryTreatmentType>
    {
      public TreatmentCategoryTreatmentTypeConfiguration()
            : base()
        {
            HasKey(treatmentCategoryTreatmentTypeID => treatmentCategoryTreatmentTypeID.TreatmentCategoryTreatmentTypeID);
            Property(treatmentTypeID => treatmentTypeID.TreatmentTypeID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            ToTable(Global.Table.lookup.TreatmentCategoryTreatmentType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
