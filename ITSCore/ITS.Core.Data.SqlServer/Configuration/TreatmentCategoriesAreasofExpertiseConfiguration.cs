using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentCategoriesAreasofExpertiseConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create TreatmentCategoriesAreasofExpertiseConfiguration  to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/30/2012 robin,pardeep,vijay   
*
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class TreatmentCategoriesAreasofExpertiseConfiguration : EntityTypeConfiguration<TreatmentCategoriesAreasofExpertise>
    {
        public TreatmentCategoriesAreasofExpertiseConfiguration()
            : base()
        {
            HasKey(treatmentCategoryAreasofExpertiseID => treatmentCategoryAreasofExpertiseID.TreatmentCategoryAreasofExpertiseID);
            Property(areasofExpertiseID => areasofExpertiseID.AreasofExpertiseID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            Property(areasofExpertiseName => areasofExpertiseName.AreasofExpertiseName).IsRequired();
            Property(treatmentCategoryName => treatmentCategoryName.TreatmentCategoryName);
            ToTable(Global.View.lookup.TreatmentCategoriesAreasofExpertise, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
