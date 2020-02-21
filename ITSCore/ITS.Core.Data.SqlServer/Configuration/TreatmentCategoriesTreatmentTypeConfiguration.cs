using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

/*
Page Name:  TreatmentCategoriesTreatmentTypeConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create treatment categories treatment types configuration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/25/2013 Robin   
* 
*/

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentCategoriesTreatmentTypeConfiguration : EntityTypeConfiguration<TreatmentCategoriesTreatmentType>
    {
        public TreatmentCategoriesTreatmentTypeConfiguration()
            : base()
        {
            HasKey(treatmentCategoryTreatmentTypeID => treatmentCategoryTreatmentTypeID.TreatmentCategoryTreatmentTypeID);
            Property(treatmentTypeID => treatmentTypeID.TreatmentTypeID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            Property(treatmentTypeName => treatmentTypeName.TreatmentTypeName).IsRequired();
            ToTable(Global.View.lookup.TreatmentCategoriesTreatmentType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
