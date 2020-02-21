using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentCategoryAreasofExpetiseConfiguration.cs                      
 Version:  1.1                                              
 Purpose: create TreatmentCategoryAreasofExpetiseConfiguration  to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/30/2012 robin,pardeep,vijay   
*
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class TreatmentCategoryAreasofExpetiseConfiguration : EntityTypeConfiguration<TreatmentCategoryAreasofExpetise>
    {
        public TreatmentCategoryAreasofExpetiseConfiguration()
            : base()
        {
            HasKey(treatmentCategoryAreasofExpertiseID => treatmentCategoryAreasofExpertiseID.TreatmentCategoryAreasofExpertiseID);
            Property(areasofExpertiseID => areasofExpertiseID.AreasofExpertiseID).IsRequired();
            Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID).IsRequired();
            ToTable(Global.Table.lookup.TreatmentCategoryAreasofExpetise, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
