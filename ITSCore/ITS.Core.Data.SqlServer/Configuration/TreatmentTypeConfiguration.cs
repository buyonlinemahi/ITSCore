using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  TreatmentTypeConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Treatment Type Configuration  to integrate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/01/2013 Robin Singh   
* 
*/

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentTypeConfiguration : EntityTypeConfiguration<TreatmentType>
    {
        public TreatmentTypeConfiguration()
            : base()
        {
            HasKey(treatmentType => treatmentType.TreatmentTypeID);
            Property(treatmentType => treatmentType.TreatmentTypeName).IsRequired();
            ToTable(Global.Table.lookup.TreatmentType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
