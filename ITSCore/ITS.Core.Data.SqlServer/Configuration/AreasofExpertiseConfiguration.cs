using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  AreasofExpertiseConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create AreasofExpertise to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 01/01/2013 Vishal   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{

    public class AreasofExpertiseConfiguration : EntityTypeConfiguration<AreasofExpertise>
    {
        public AreasofExpertiseConfiguration()
            : base()
        {
            HasKey(areasofExpertise => areasofExpertise.AreasofExpertiseID);
            Property(areasofExpertise => areasofExpertise.AreasofExpertiseName);
            ToTable(Global.Table.lookup.AreasofExpertise, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
